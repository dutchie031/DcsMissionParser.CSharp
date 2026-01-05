using System;
using DcsMissionParser.CSharp.Annotations;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane;

public class Route
{
    [LuaKey("points")]
    public List<Point> Points { get; set; } = [];
    
}
