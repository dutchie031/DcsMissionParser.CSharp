using System;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane;

public class Route
{
    [LuaKey("points")]
    public List<Point> Points { get; set; } = [];
    public Guid RefId { get; set; } = Guid.NewGuid();
}
