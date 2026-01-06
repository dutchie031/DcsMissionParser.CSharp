using System;
using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks;
using DcsMissionParser.Net.Objects.Commons;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane;

public class Point
{

    [LuaKey("alt")]
    public double Altitude { get; set; }

    [LuaKey("action")]
    public Action Action { get; set; } = Action.TurningPoint;

    [LuaKey("alt_type")]
    public AltType AltitudeType { get; set; } = AltType.BARO;

    [LuaKey("speed")]
    public double Speed { get; set; }

    //TODO: Verify this is correct
    [LuaKey("type")]
    public Action Type { get; set; } = Action.TurningPoint;

    [LuaKey("ETA")]
    public double ETA { get; set; }

    [LuaKey("ETA_locked")]
    public bool IsETALocked { get; set; }

    [LuaKey("x")]
    public double X { get; set; }

    [LuaKey("y")]
    public double Y { get; set; }

    [LuaKey("speed_locked")]
    public bool IsSpeedLocked { get; set; }

    //TODO: Add formation Template Enum
    [LuaKey("formation_template")]
    public string FormationTemplate { get; set; } = string.Empty; 

    [LuaKey("task")]
    public PointTask Task { get; set; } = new ComboTask();

}

public class Action : StringEnum
{
    private Action(string value) : base(value) { }

    public readonly static Action TurningPoint = new("Turning Point");
    public readonly static Action FlyOverPoint = new("Fly Over Point");
    public readonly static Action FromParkingArea = new("From Parking Area");
    public readonly static Action FromParkingAreaHot = new("From Parking Area Hot");
    public readonly static Action FromRunway = new("From Runway");
    public readonly static Action Landing = new("Landing");
    public readonly static Action FromGround = new("From Ground Area");
    public readonly static Action FromGroundHot = new("From Ground Area Hot");

}
