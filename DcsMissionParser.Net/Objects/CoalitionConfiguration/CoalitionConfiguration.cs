using System;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.CoalitionConfiguration;

public class CoalitionConfiguration
{   
    [LuaKey("neutrals")]
    public List<int> Neutrals { get; set; } = [];

    [LuaKey("red")]
    public List<int> Red { get; set; } = [];

    [LuaKey("blue")]
    public List<int> Blue { get; set; } = [];
}
