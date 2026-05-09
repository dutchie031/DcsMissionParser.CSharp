using System;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Drawing;

public class Drawings
{
    [LuaKey("options")]
    public DrawingOptions Options { get; set; } = new ();

    [LuaKey("layers")]
    public List<Layer> Layers { get; set; } = [];
}
