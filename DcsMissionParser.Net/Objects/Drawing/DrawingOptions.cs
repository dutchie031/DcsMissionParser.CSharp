using System;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Drawing;

public class DrawingOptions
{
    [LuaKey("hiddenOnF10Map")]
    public HiddenOnF10Map HiddenOnF10Map { get; set; } = new ();
}

public class HiddenOnF10Map
{
    [LuaKey("Observer")]
    public HiddenOnF10MapSettings Observer { get; set; } = new ();

    [LuaKey("Instructor")]
    public HiddenOnF10MapSettings Instructor { get; set; } = new ();

    [LuaKey("ForwardObserver")]
    public HiddenOnF10MapSettings ForwardObserver { get; set; } = new ();

    [LuaKey("Spectator")]
    public HiddenOnF10MapSettings Spectator { get; set; } = new ();

    [LuaKey("ArtilleryCommander")]
    public HiddenOnF10MapSettings ArtilleryCommander { get; set; } = new ();

    [LuaKey("Pilot")]
    public HiddenOnF10MapSettings Pilot { get; set; } = new ();
}

public class HiddenOnF10MapSettings
{
    [LuaKey("Neutral")]
    public bool Neutral { get; set; }

    [LuaKey("Red")]
    public bool Red { get; set; }

    [LuaKey("Blue")]
    public bool Blue { get; set; }
}
