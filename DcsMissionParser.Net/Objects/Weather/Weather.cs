using System;
using System.Diagnostics.CodeAnalysis;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Weather;

public class Weather
{
    [LuaKey("atmosphere_type")]
    public int AtmosphereType { get; set; } = 0;

    [LuaKey("groundTurbulence")]
    public int GroundTurbulence { get; set; } = 0;

    [LuaKey("wind")]
    public Wind Wind { get; set; } = new Wind();

    [LuaKey("halo")]
    public Halo Halo { get; set; } = new Halo();

    [LuaKey("visibility")]
    public Visibility Visibility { get; set; } = new ();

    [LuaKey("season")]
    public Season Season { get; set; } = new ();

    [LuaKey("type_weather")]
    public int TypeWeather { get; set; } = 0;

    [LuaKey("qnh")]
    public int Qnh { get; set; } = 760;

    [Experimental("NotImplementedMissionField")]
    [LuaKey("cyclones")]
    public object Cyclones { get; set; } = new object();

    [LuaKey("name")]
    public string Name { get; set; } = "Winter, clean sky";

    [LuaKey("dust_density")]
    public int DustDensity { get; set; } = 0;

    [LuaKey("modifiedTime")]
    public bool ModifiedTime { get; set; } = false;

    [LuaKey("enable_dust")]
    public bool EnableDust { get; set; } = false;

    [LuaKey("clouds")]
    public Clouds Clouds { get; set; } = new();

}

public class Wind
{
    [LuaKey("at8000")]
    public WindSetting At8000 { get; set; } = new WindSetting { Dir = 0, Speed = 0 };

    [LuaKey("atGround")]
    public WindSetting AtGround { get; set; } = new WindSetting { Dir = 0, Speed = 0 };

    [LuaKey("at2000")]
    public WindSetting At2000 { get; set; } = new WindSetting { Dir = 0, Speed = 0 };
}

public class WindSetting
{
    [LuaKey("speed")]
    public double Speed { get; set; }

    [LuaKey("dir")]
    public double Dir { get; set; }
}

public class Halo
{
    [LuaKey("preset")]
    public string Preset { get; set; } = "auto";
}

public class Visibility
{
    [LuaKey("distance")]
    public int Distance { get; set; } = 80000;
}

public class Season
{
    [LuaKey("temperature")]
    public int Temperature { get; set; } = 20;
}

public class Clouds
{
    [LuaKey("density")]
    public int Density { get; set; } = 0;

    [LuaKey("thickness")]
    public int Thickness { get; set; } = 200;

    [LuaKey("base")]
    public int Base { get; set; } = 2500;

    [LuaKey("preset")]
    public string Preset { get; set; } = "Preset2";

    [LuaKey("iprecptns")]
    public int Iprecptns { get; set; } = 0;
}