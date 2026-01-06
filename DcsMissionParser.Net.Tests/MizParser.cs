using System.Diagnostics;
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


        static ParseResult<MizObject>? result;
        static double duration = double.MaxValue;

        [AssemblyInitialize]
        public static async Task AssemblyInit(TestContext context)
        {
            long started = Stopwatch.GetTimestamp();
            byte[] bytes = File.ReadAllBytes(file);
            result = await MissionSerializer.Deserialize(bytes);
            duration =  Stopwatch.GetElapsedTime(started).TotalMilliseconds;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result.Result, new Newtonsoft.Json.JsonSerializerSettings()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });

            File.WriteAllText(parse_output, json);
        }

        [TestMethod]
        public async Task Parsed_FreePolygon() 
        {
            var drawingObject = result?.Result?.Drawings?.Layers
                .FirstOrDefault(x => x.Name == "Author")?
                .Objects
                .FirstOrDefault(x => x.PrimitiveType == PrimitiveType.Polygon && ((Polygon)x).PolygonMode == PolygonMode.Free);

            Assert.IsNotNull(drawingObject);
        }

        [TestMethod]
        public async Task Parsed_Success()
        {
            if (result?.Success != true) 
            {
                Assert.Fail(result?.FailureReason ?? "Unknown parsing failure");
            }
        }

        [TestMethod]
        public async Task Serialize() 
        {
            MizObject mizObject = result?.Result!;

            var parseResult = await MissionSerializer.Serialize(mizObject);
            if (!parseResult.Success) 
            {
                Assert.Fail(parseResult.FailureReason);
            }
            File.WriteAllBytes(mission_output, parseResult.Result!);

        }
    }
}
