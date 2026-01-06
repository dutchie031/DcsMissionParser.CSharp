using System;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;

public class WeaponExpend : StringEnum
{
    private WeaponExpend(string value) : base(value) { }

    public static readonly WeaponExpend Auto = new("Auto");
    public static readonly WeaponExpend Quarter = new("Quarter");
    public static readonly WeaponExpend Two = new("Two");
    public static readonly WeaponExpend One = new("One");
    public static readonly WeaponExpend Four = new("Four");
    public static readonly WeaponExpend Half = new("Half");
    public static readonly WeaponExpend All = new("All");

}
