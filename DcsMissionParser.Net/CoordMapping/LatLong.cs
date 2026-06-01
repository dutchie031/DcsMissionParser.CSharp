using System;
using System.Diagnostics.CodeAnalysis;

namespace DcsMissionParser.Net.CoordMapping;

public class LatLong
{
    public LatLong(){}
    
    [SetsRequiredMembers]
    public LatLong(double lat, double lon)
    {        
        Lat = lat;
        Lon = lon;
    }

    public required double Lat { get; set; }
    public required double Lon { get; set; }
}
