using System;
using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.Net.Objects.Commons;

namespace DcsMissionParser.Net.Objects.Coalitions.Units.Plane;

public class PlaneUnit
{
    
    [LuaKey("alt")]
    public double Alt { get; set; }

    [LuaKey("alt_type")]
    public AltType AltType { get; set; } = AltType.BARO;

    [LuaKey("livery_id")]
    public string LiveryId { get; set; } = string.Empty;

    [LuaKey("skill")]
    public Skill Skill { get; set; } = Skill.High;

    [LuaKey("speed")]
    public double Speed { get; set; }

    //TODO: Add AddPropAircraft for some types

    [LuaKey("type")]
    public required PlaneType Type { get; set; }

    [LuaKey("unitId")]
    public int UnitId { get; set; }

    [LuaKey("psi")]
    public double Psi { get; set; }

    [LuaKey("onboard_num")]
    public string BoardNumber { get; set; } = string.Empty;

    [LuaKey("x")]
    public double X { get; set; }

    [LuaKey("y")]
    public double Y { get; set; }

    [LuaKey("heading")]
    public double Heading { get; set; }

    [LuaKey("name")]
    public string Name { get; set; } = "Aerial-1-1";

    //TODO: Payload

    

}
