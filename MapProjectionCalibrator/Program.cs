// See https://aka.ms/new-console-template for more information
using MapProjectionCalibrator;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System.Globalization;
using System.Text.Json;

Console.WriteLine("MapProjectionCalibrator starting...");


CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

foreach (var jsonFile in Directory.GetFiles("./ExportedPoints", "*.json"))
{
    Console.WriteLine($"Calibrating from {jsonFile}...");

    var text = File.ReadAllText(jsonFile);
    var data = JsonSerializer.Deserialize<DcsExportData>(text);

    if (data == null || data.ReferencePoints.Count < 3)
    {
        Console.WriteLine("  Not enough reference points to calibrate (need at least 3).");
        continue;
    }

    var settings = CalibrateTransverseMercator(data.ReferencePoints);

    Console.WriteLine($"  CentralMeridian: {settings.CentralMeridian:F6} deg");
    Console.WriteLine($"  ScaleFactor:     {settings.ScaleFactor:F8}");
    Console.WriteLine($"  FalseEasting:    {settings.FalseEasting:F3} m");
    Console.WriteLine($"  FalseNorthing:   {settings.FalseNorthing:F3} m");

    if (data.TestPoints.Count > 0)
    {
        var refError = EvaluateRmsError(data.ReferencePoints, settings, "reference");
        var testError = EvaluateRmsError(data.TestPoints, settings, "test");
        Console.WriteLine($"  RMS (reference): {refError:F3} m");
        Console.WriteLine($"  RMS (test):      {testError:F3} m");
    }
}

static TransverseMercatorSettings CalibrateTransverseMercator(IReadOnlyList<DcsPoint> points)
{
    // Initial guesses
    var lonMean = points.Average(p => p.Lon);
    var lonMin = points.Min(p => p.Lon);
    var lonMax = points.Max(p => p.Lon);

    // Search ranges around observed longitudes and typical TM scales
    var best = new TransverseMercatorSettings
    {
        CentralMeridian = lonMean,
        ScaleFactor = 1.0,
        FalseEasting = 0.0,
        FalseNorthing = 0.0
    };

    var bestError = double.MaxValue;

    // Coarse grid search over central meridian and scale factor
    // Stage 1: Coarse search (current)

    void processRange(double start, double end, double step)
    {
        for (var cm = start; cm <= end; cm += step) 
        {
            for (var k0 = 0.9990; k0 <= 1.0010; k0 += 0.0001)
            {
                // For each (cm, k0), solve best linear offsets (false easting/northing)
                // by least squares between projected TM and DCS coordinates.
                CreateProjection(cm, k0, out var toProj);

                var eastProj = new double[points.Count];
                var northProj = new double[points.Count];
                var eastObs = new double[points.Count];   // DCS z
                var northObs = new double[points.Count];  // DCS x

                for (var i = 0; i < points.Count; i++)
                {
                    var p = points[i];
                    eastObs[i] = p.Z; // DCS east
                    northObs[i] = p.X; // DCS north
                    var projected = toProj.MathTransform.Transform(new[] { p.Lon, p.Lat });
                    eastProj[i] = projected[0];
                    northProj[i] = projected[1];
                }

                // Fit offsets: eastObs ≈ eastProj + E0, northObs ≈ northProj + N0
                FitOffset(eastProj, eastObs, out var e0);
                FitOffset(northProj, northObs, out var n0);

                var error = ComputeRmsError(eastProj, northProj, eastObs, northObs, e0, n0);
                if (error < bestError)
                {
                    bestError = error;
                    best.CentralMeridian = cm;
                    best.ScaleFactor = k0;
                    best.FalseEasting = e0;
                    best.FalseNorthing = n0;
                }
            }
        }
    }
    Console.WriteLine("LonMin: " + lonMin + " LonMax: " + lonMax);
    processRange(-180, 180, 0.1);
    processRange(best.CentralMeridian - 0.5, best.CentralMeridian + 0.5, 0.05);
    processRange(best.CentralMeridian - 0.2, best.CentralMeridian + 0.2, 0.01);
    processRange(best.CentralMeridian - 0.02, best.CentralMeridian + 0.02, 0.001);

    Console.WriteLine($"  RMS (calibration set): {bestError:F3} m");
    return best;
}

static void CreateProjection(double centralMeridian, double scaleFactor, out ICoordinateTransformation toProj)
{
    var csFactory = new CoordinateSystemFactory();
    var ctFactory = new CoordinateTransformationFactory();

    var wgs84 = GeographicCoordinateSystem.WGS84;

    var parameters = new List<ProjectionParameter>
    {
        new("latitude_of_origin", 0.0),
        new("central_meridian", centralMeridian),
        new("scale_factor", scaleFactor),
        new("false_easting", 0.0),
        new("false_northing", 0.0)
    };

    var projection = csFactory.CreateProjection("Transverse_Mercator", "Transverse_Mercator", parameters);

    var projectedCs = csFactory.CreateProjectedCoordinateSystem(
        "TM_WGS84",
        wgs84,
        projection,
        LinearUnit.Metre,
        new AxisInfo("Easting", AxisOrientationEnum.East),
        new AxisInfo("Northing", AxisOrientationEnum.North)
        );

    toProj = ctFactory.CreateFromCoordinateSystems(wgs84, projectedCs);
}

static void FitOffset(IReadOnlyList<double> model, IReadOnlyList<double> obs, out double offset)
{
    if (model.Count != obs.Count)
    {
        throw new ArgumentException("model and obs must have same length.");
    }

    var n = model.Count;
    double sumDiff = 0;
    for (var i = 0; i < n; i++)
    {
        sumDiff += obs[i] - model[i];
    }

    offset = sumDiff / n;
}

static double ComputeRmsError(
    IReadOnlyList<double> eastProj,
    IReadOnlyList<double> northProj,
    IReadOnlyList<double> eastObs,
    IReadOnlyList<double> northObs,
    double falseEasting,
    double falseNorthing)
{
    var n = eastProj.Count;
    double sumSq = 0;
    for (var i = 0; i < n; i++)
    {
        var de = (eastProj[i] + falseEasting) - eastObs[i];
        var dn = (northProj[i] + falseNorthing) - northObs[i];
        sumSq += de * de + dn * dn;
    }

    return Math.Sqrt(sumSq / n);
}

static double EvaluateRmsError(IReadOnlyList<DcsPoint> points, TransverseMercatorSettings settings, string label)
{
    CreateProjection(settings.CentralMeridian, settings.ScaleFactor, out var toProj);

    var eastProj = new double[points.Count];
    var northProj = new double[points.Count];
    var eastObs = new double[points.Count];
    var northObs = new double[points.Count];

    for (var i = 0; i < points.Count; i++)
    {
        var p = points[i];
        eastObs[i] = p.Z;
        northObs[i] = p.X;
        var projected = toProj.MathTransform.Transform(new[] { p.Lon, p.Lat });
        eastProj[i] = projected[0];
        northProj[i] = projected[1];
    }

    return ComputeRmsError(eastProj, northProj, eastObs, northObs, settings.FalseEasting, settings.FalseNorthing);
}