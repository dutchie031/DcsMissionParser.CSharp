using DcsMissionParser.Net;
using DcsMissionParser.Net.Objects.Drawing;

namespace DcsMissionParser.Net.Tests
{
    [TestClass]
    public sealed class MizParser
    {
        static string file = "../../../../.ref/TestDrawings.miz";
        static string parse_output = "../../../../.ref/TestDrawings_ParseOutput.json";
        static string mission_output = "../../../../.ref/TestDrawings_MissionOuput";


        static ParseResult<MizObject> result;

        [AssemblyInitialize]
        public static async Task AssemblyInit(TestContext context)
        {
            byte[] bytes = File.ReadAllBytes(file);
            result = await MissionSerializer.Deserialize(bytes);

            string json = System.Text.Json.JsonSerializer.Serialize(result.Result, new System.Text.Json.JsonSerializerOptions()
            {
                WriteIndented = true,
                IncludeFields = true
            });

            File.WriteAllText(parse_output, json);
        }

        [TestMethod]
        public async Task Parsed_FreePolygon() 
        {
            var drawingObject = result.Result?.Drawings?.Layers
                .FirstOrDefault(x => x.Name == "Author")?
                .Objects
                .FirstOrDefault(x => x.PrimitiveType == PrimitiveType.Polygon && ((Polygon)x).PolygonMode == PolygonMode.Free);

            Assert.IsNotNull(drawingObject);
        }

        [TestMethod]
        public async Task Serialize() 
        {
            MizObject mizObject = result.Result!;

            var parseResult = await MissionSerializer.Serialize(mizObject);
            if (!parseResult.Success) 
            {
                Assert.Fail(parseResult.FailureReason);
            }
            File.WriteAllBytes(mission_output, parseResult.Result!);

        }
    }
}
