using System.Text.Json;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Annotations.JsonConverters;
using DcsMissionParser.Net.Objects.Coalitions.Countries.Groups;

namespace DcsMissionParser.Net.Tests;

[TestClass]
public class StringEnumJsonSerializationTests
{
    [TestMethod]
    public void StringEnum_Serializes_AsJsonString()
    {
        var json = JsonSerializer.Serialize(PlaneTasking.CAP);

        Assert.AreEqual("\"CAP\"", json);
    }

    [TestMethod]
    public void StringEnum_Deserializes_ToKnownStaticInstance()
    {
        var value = JsonSerializer.Deserialize<PlaneTasking>("\"Refueling\"");

        Assert.IsNotNull(value);
        Assert.AreSame(PlaneTasking.Refueling, value);
    }

    [TestMethod]
    public void StringEnum_Deserialization_Throws_ForUnknownValue()
    {
        Assert.Throws<JsonException>(() =>
        {
            _ = JsonSerializer.Deserialize<PlaneTasking>("\"NotARealTask\"");
        });
    }
}
