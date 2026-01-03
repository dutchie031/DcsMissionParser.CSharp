using System;
using DcsMissionParser.Net.CoordMapping;
using static DcsMissionParser.Net.CoordMapping.ConvertConfig;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;

namespace DcsMissionParser.Net;

public class CoordConverter
{
    private readonly ICoordinateTransformation _wgsToTm;
    private readonly ICoordinateTransformation _tmToWgs;
    private readonly TransverseMercatorSettings _settings;

    private CoordConverter(TransverseMercatorSettings settings)
    {
        _settings = settings;

        var csFactory = new CoordinateSystemFactory();
        var ctFactory = new CoordinateTransformationFactory();

        var wgs84 = GeographicCoordinateSystem.WGS84;
        var parameters = new List<ProjectionParameter>
        {
            new("latitude_of_origin", 0.0),
            new("central_meridian", settings.CentralMeridian),
            new("scale_factor", settings.ScaleFactor),
            new("false_easting", settings.FalseEasting),
            new("false_northing", settings.FalseNorthing)
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

        _wgsToTm = ctFactory.CreateFromCoordinateSystems(wgs84, projectedCs);
        _tmToWgs = ctFactory.CreateFromCoordinateSystems(projectedCs, wgs84);
    }

    public DcsCoord LLtoLO(LatLong ll)
    {
        // Convert to Transverse Mercator
        var tmCoords = _wgsToTm.MathTransform.Transform([ll.Lon, ll.Lat]);
        // Convert from TM (east, north) to DCS (z, x) - assuming Z=east, X=north
        return new DcsCoord { Y = tmCoords[0], X = tmCoords[1] };
    }

    public LatLong LOtoLL(DcsCoord lo)
    {
        // Convert from Transverse Mercator to WGS84
        var wgsCoords = _tmToWgs.MathTransform.Transform([lo.Y, lo.X]);
        return new LatLong { Lon = wgsCoords[0], Lat = wgsCoords[1] };
    }

    /// <summary>
    ///     Create a coordinate converter for the specified map. <br/>
    ///     Currently supported map names: <br/>
    ///     - "Caucasus"<br/>
    ///     - "GermanyCW"
    /// </summary>
    /// <param name="mapName">
    /// Currently supported map names: <br/>
    /// - "Caucasus" <br/>
    /// - "GermanyCW"
    /// </param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static CoordConverter CreateForMap(string mapName)
    {
        var settings = GetSettings(mapName) ?? throw new ArgumentException($"No coordinate conversion settings for map '{mapName}'");
        return new CoordConverter(settings);
    }
}
