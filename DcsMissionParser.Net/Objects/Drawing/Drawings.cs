using System;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Drawing;

public class Drawings
{
    [LuaKey("layers")]
    public List<Layer> Layers { get; set; } = [];
}
