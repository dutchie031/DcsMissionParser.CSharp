using System;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Commons;

public class AltType : StringEnum
{
    private AltType(string value) : base(value) { }
    public static readonly AltType RADIO = new("RADIO");
    public static readonly AltType BARO = new("BARO");
}
