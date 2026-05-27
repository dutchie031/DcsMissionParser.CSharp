using System.Text.Json;
using DcsMissionParser.Net.Objects.Commons;
using DcsMissionParser.Net.Objects.Drawing;

namespace DcsMissionParser.Net.Tests;

[TestClass]
public class DrawingObjectJsonSerializationTests
{
    [TestMethod]
    public void DrawingObjectList_RoundTripsWithConcreteTypes()
    {
        var drawings = new List<DrawingObject>
        {
            new Circle
            {
                PrimitiveType = PrimitiveType.Polygon,
                Name = "circle-1",
                Visible = true,
                LayerName = "Author",
                MapX = 10,
                MapY = 20,
                ColorString = "0xff0000ff",
                Style = "solid",
                Thickness = 2,
                Radius = 50
            },
            new Segment
            {
                PrimitiveType = PrimitiveType.Line,
                Name = "segment-1",
                Visible = false,
                LayerName = "Author",
                MapX = 5,
                MapY = 15,
                ColorString = "0xffffffff",
                Style = "dash",
                Closed = false,
                Thickness = 3,
                Points = new List<Vec2>
                {
                    new Vec2 { X = 1, Y = 2 },
                    new Vec2 { X = 3, Y = 4 }
                }
            },
            new TextBox
            {
                PrimitiveType = PrimitiveType.TextBox,
                Name = "textbox-1",
                Visible = true,
                LayerName = "Author",
                MapX = 100,
                MapY = 200,
                ColorString = "0xff00ff00",
                Style = "default",
                Text = "Hello",
                FontSize = 16
            }
        };

        var json = JsonSerializer.Serialize(drawings);

        using var jsonDoc = JsonDocument.Parse(json);
        var serializedItems = jsonDoc.RootElement;
        Assert.AreEqual(JsonValueKind.Array, serializedItems.ValueKind);
        Assert.HasCount(3, serializedItems.EnumerateArray());

        var serializedTypes = serializedItems
            .EnumerateArray()
            .Select(item => item.GetProperty("$type").GetString())
            .ToArray();

        Assert.AreEqual(nameof(PrimitiveType.Polygon) + "_" + nameof(PolygonMode.Circle), serializedTypes[0]);
        Assert.AreEqual(nameof(PrimitiveType.Line) + "_" + nameof(LineMode.Segment), serializedTypes[1]);
        Assert.AreEqual(nameof(PrimitiveType.TextBox), serializedTypes[2]); 

        var roundTripped = JsonSerializer.Deserialize<List<DrawingObject>>(json);

        Assert.IsNotNull(roundTripped);
        Assert.HasCount(3, roundTripped);

        Assert.IsInstanceOfType<Circle>(roundTripped[0]);
        Assert.AreEqual(50, ((Circle)roundTripped[0]).Radius, 0.0001);

        Assert.IsInstanceOfType<Segment>(roundTripped[1]);
        Assert.HasCount(2, ((Segment)roundTripped[1]).Points);

        Assert.IsInstanceOfType<TextBox>(roundTripped[2]);
        Assert.AreEqual("Hello", ((TextBox)roundTripped[2]).Text);
    }
}
