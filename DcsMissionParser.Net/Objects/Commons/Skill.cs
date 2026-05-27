using System;
using System.Text.Json.Serialization;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Annotations.JsonConverters;

namespace DcsMissionParser.Net.Objects.Commons;

[JsonConverter(typeof(StringEnumJsonConverterFactory))]
public class Skill: StringEnum
{
    private Skill(string value) : base(value) { }
    public readonly static Skill High = new("High");
    public readonly static Skill Good = new("Good");
    public readonly static Skill Average = new("Average");
    public readonly static Skill Excellent = new("Excellent");
    public readonly static Skill Random = new("Random");
    public readonly static Skill Player = new("Player");
    public readonly static Skill Client = new("Client");
}

