using System;
using DcsMissionParser.CSharp.Annotations;

namespace DcsMissionParser.CSharp.Objects.Drawings;

public class Drawings
{
    [LuaKey("layers")]
    public List<Layer> Layers { get; set; } = [];
}
