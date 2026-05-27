using System.Text.Json;
using DcsMissionParser.Net.Annotations.JsonConverters;
using DcsMissionParser.Net.Objects.Commons;

namespace DcsMissionParser.Net.Tests;

[TestClass]
public class IntEnumJsonSerializationTests
{
    [TestMethod]
    public void IntEnum_Serializes_AsJsonNumber()
    {
        var json = JsonSerializer.Serialize(CaucasusAirdromeId.Krymsk);

        Assert.AreEqual("15", json);
    }

    [TestMethod]
    public void IntEnum_Deserializes_ToKnownStaticInstance()
    {
        var value = JsonSerializer.Deserialize<CaucasusAirdromeId>("15");

        Assert.IsNotNull(value);
        Assert.AreSame(CaucasusAirdromeId.Krymsk, value);
    }

    [TestMethod]
    public void IntEnum_Deserialization_Throws_ForUnknownValue()
    {
        Assert.Throws<JsonException>(() =>
        {
            _ = JsonSerializer.Deserialize<CaucasusAirdromeId>("999999");
        });
    }
}
