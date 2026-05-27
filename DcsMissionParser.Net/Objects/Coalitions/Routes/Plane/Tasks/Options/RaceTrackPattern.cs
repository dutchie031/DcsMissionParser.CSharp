using System;
using System.Text.Json.Serialization;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Annotations.JsonConverters;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;

[JsonConverter(typeof(StringEnumJsonConverterFactory))]
public class RaceTrackPattern : StringEnum
{
    private RaceTrackPattern(string value) : base(value) { }
    public static readonly RaceTrackPattern Circle = new("Circle");
    public static readonly RaceTrackPattern RaceTrack = new("RaceTrack");
    public static readonly RaceTrackPattern Anchored = new("Anchored");
}
