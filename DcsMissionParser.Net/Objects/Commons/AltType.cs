using System;
using System.Text.Json.Serialization;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Annotations.JsonConverters;

namespace DcsMissionParser.Net.Objects.Commons;

[JsonConverter(typeof(StringEnumJsonConverterFactory))]
public class AltType : StringEnum
{
    private AltType(string value) : base(value) { }
    public static readonly AltType RADIO = new("RADIO");
    public static readonly AltType BARO = new("BARO");
}
