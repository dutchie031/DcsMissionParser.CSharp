using System;

namespace DcsMissionParser.Net.Objects.Commons;

public class Skill(string value) : StringEnum(value)
{
    public readonly static Skill High = new("High");
    public readonly static Skill Good = new("Good");
    public readonly static Skill Average = new("Average");
    public readonly static Skill Excellent = new("Excellent");
    public readonly static Skill Random = new("Random");
    public readonly static Skill Player = new("Player");
    public readonly static Skill Client = new("Client");
}

