using System;
using DcsMissionParser.CSharp.Annotations;

namespace DcsMissionParser.Net.Objects.Drawing;

public class Drawings
{
    [LuaKey("layers")]
    public List<Layer> Layers { get; set; } = [];
}
