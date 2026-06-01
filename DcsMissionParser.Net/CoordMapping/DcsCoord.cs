using System;
using System.Diagnostics.CodeAnalysis;

namespace DcsMissionParser.Net.CoordMapping;

public class DcsCoord
{
    public DcsCoord(){}

    [SetsRequiredMembers]
    public DcsCoord(double x, double y)
    {
        X = x;
        Y = y;
    }
    
    public required double X { get; set; }
    public required double Y { get; set; }
}
