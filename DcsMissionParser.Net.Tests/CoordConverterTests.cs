using System;
using DcsMissionParser.Net.CoordMapping;

namespace DcsMissionParser.Net.Tests;

[TestClass]
public class CoordConverterTests
{

    [TestMethod]
    public void TestLLtoLO_Caucasus()
    {
        LatLong ll = new ()
        {
            Lat = 43.871232926542,
            Lon = 44.117254759615
        };

        var converter = CoordConverter.CreateForMap("Caucasus");
        var lo = converter.LLtoLO(ll);
        Assert.IsNotNull(lo);
        Assert.IsLessThan(1, Math.Abs(-80083 - lo.X));
        Assert.IsLessThan(1, Math.Abs(793924 - lo.Y));
    }

    [TestMethod]
    public void TestLOtoLL_Caucasus()
    {
        DcsCoord lo = new ()
        {
            X = -80083,
            Y = 793924
        };

        var converter = CoordConverter.CreateForMap("Caucasus");
        var ll = converter.LOtoLL(lo);
        Assert.IsNotNull(ll);
        Assert.IsLessThan(0.00001, Math.Abs(43.871232926542 - ll.Lat));
        Assert.IsLessThan(0.00001, Math.Abs(44.117254759615 - ll.Lon));
    }

}
