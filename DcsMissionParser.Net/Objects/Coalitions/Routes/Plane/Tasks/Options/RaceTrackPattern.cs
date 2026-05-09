using System;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;

public class RaceTrackPattern : StringEnum
{
    private RaceTrackPattern(string value) : base(value) { }
    public static readonly RaceTrackPattern Circle = new("Circle");
    public static readonly RaceTrackPattern RaceTrack = new("RaceTrack");
    public static readonly RaceTrackPattern Anchored = new("Anchored");
}
