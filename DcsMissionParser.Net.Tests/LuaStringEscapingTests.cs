using System.Text;
using DcsMissionParser.Net.Objects.Drawing;

namespace DcsMissionParser.Net.Tests;

[TestClass]
public class LuaStringEscapingTests
{
    /// <summary>
    /// Helper method to test string serialization by creating a minimal mission with a text property
    /// </summary>
    private async Task<string> SerializeStringValue(string testValue)
    {
        var mission = DcsMission.CreateNewMission("Caucasus");
        mission.Drawings = new Drawings
        {
            Layers = new List<Layer>
            {
                new Layer
                {
                    Name = "TestLayer",
                    Objects = new List<DrawingObject>
                    {
                        new TextBox
                        {
                            PrimitiveType = PrimitiveType.TextBox,
                            Name = "TestBox",
                            Visible = true,
                            LayerName = "TestLayer",
                            MapX = 100,
                            MapY = 200,
                            ColorString = "0xff0000ff",
                            Style = "solid",
                            Text = testValue,
                            FontSize = 12
                        }
                    }
                }
            }
        };

        var serializeResult = await MissionSerializer.Serialize(mission);
        if (!serializeResult.Success)
            throw new Exception($"Serialization failed: {serializeResult.FailureReason}");
            
        return Encoding.UTF8.GetString(serializeResult.Result!);
    }

    [TestMethod]
    public async Task TestBackslashAtEnd()
    {
        var testString = "Stage-2\\";
        var serialized = await SerializeStringValue(testString);
        
        // Verify the serialized output contains properly escaped backslash
        Assert.IsTrue(serialized.Contains("\"Stage-2\\\\\""), 
            "Backslash at end should be escaped as double backslash");

        // Verify round-trip
        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success, $"Deserialization failed: {deserializeResult.FailureReason}");
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.IsNotNull(textBox);
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestBackslashInMiddle()
    {
        var testString = "path\\to\\file";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("\"path\\\\to\\\\file\""), 
            "Backslashes in middle should be escaped");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestDoubleQuotes()
    {
        var testString = "He said \"Hello\"";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("He said \\\"Hello\\\""), 
            "Double quotes should be escaped");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestNewline()
    {
        var testString = "Line1\nLine2";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("\"Line1\\nLine2\""), 
            "Newline should be escaped as \\n");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestCarriageReturn()
    {
        var testString = "Line1\rLine2";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("\"Line1\\rLine2\""), 
            "Carriage return should be escaped as \\r");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestTab()
    {
        var testString = "Col1\tCol2";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("\"Col1\\tCol2\""), 
            "Tab should be escaped as \\t");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestBell()
    {
        var testString = "Alert\a!";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("\"Alert\\a!\""), 
            "Bell character should be escaped as \\a");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestBackspace()
    {
        var testString = "Text\bBack";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("\"Text\\bBack\""), 
            "Backspace should be escaped as \\b");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestFormFeed()
    {
        var testString = "Page1\fPage2";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("\"Page1\\fPage2\""), 
            "Form feed should be escaped as \\f");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestVerticalTab()
    {
        var testString = "Line1\vLine2";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("\"Line1\\vLine2\""), 
            "Vertical tab should be escaped as \\v");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestNullCharacter()
    {
        var testString = "Text\0With\0Nulls";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("Text\\0With\\0Nulls"), 
            "Null characters should be escaped as \\0");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestMultipleEscapes()
    {
        var testString = "Complex\\n\"text\"\twith\nmultiple";
        var serialized = await SerializeStringValue(testString);
        
        // Should contain: Complex\\n\"text\"\twith\nmultiple
        Assert.IsTrue(serialized.Contains("Complex\\\\n\\\"text\\\"\\twith\\nmultiple"), 
            "Multiple escape sequences should all be handled correctly");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestEmptyString()
    {
        var testString = "";
        var serialized = await SerializeStringValue(testString);
        
        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestOnlyBackslashes()
    {
        var testString = "\\\\\\";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("\"\\\\\\\\\\\\\""), 
            "Multiple backslashes should each be doubled");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestWindowsPath()
    {
        var testString = "C:\\Users\\test\\file.txt";
        var serialized = await SerializeStringValue(testString);
        
        Assert.IsTrue(serialized.Contains("C:\\\\Users\\\\test\\\\file.txt"), 
            "Windows paths with backslashes should be properly escaped");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestUnicodeCharacters()
    {
        var testString = "Unicode: 你好 🚀 ñ";
        var serialized = await SerializeStringValue(testString);

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }

    [TestMethod]
    public async Task TestAllEscapeSequences()
    {
        // Test a string containing all Lua 5.1 escape sequences
        var testString = "All escapes:\\\"\n\r\t\a\b\f\v\0";
        var serialized = await SerializeStringValue(testString);
        
        // Verify each escape is present
        Assert.IsTrue(serialized.Contains("\\\\"), "Backslash should be escaped");
        Assert.IsTrue(serialized.Contains("\\\""), "Quote should be escaped");
        Assert.IsTrue(serialized.Contains("\\n"), "Newline should be escaped");
        Assert.IsTrue(serialized.Contains("\\r"), "Carriage return should be escaped");
        Assert.IsTrue(serialized.Contains("\\t"), "Tab should be escaped");
        Assert.IsTrue(serialized.Contains("\\a"), "Bell should be escaped");
        Assert.IsTrue(serialized.Contains("\\b"), "Backspace should be escaped");
        Assert.IsTrue(serialized.Contains("\\f"), "Form feed should be escaped");
        Assert.IsTrue(serialized.Contains("\\v"), "Vertical tab should be escaped");
        Assert.IsTrue(serialized.Contains("\\0"), "Null should be escaped");

        var deserializeResult = await MissionSerializer.Deserialize(Encoding.UTF8.GetBytes(serialized));
        Assert.IsTrue(deserializeResult.Success);
        
        var textBox = deserializeResult.Result!.Drawings?.Layers[0].Objects[0] as TextBox;
        Assert.AreEqual(testString, textBox.Text);
    }
}
