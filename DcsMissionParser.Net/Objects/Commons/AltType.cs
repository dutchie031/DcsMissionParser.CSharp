using System;

namespace DcsMissionParser.Net.Objects.Commons;

public class AltType(string value) : StringEnum(value)
{
    public static readonly AltType RADIO = new("RADIO");
    public static readonly AltType BARO = new("BARO");
}
