namespace DcsMissionParser.CSharp.Tests
{
    public class UnitTest1
    {

        string file = "../../../../.ref/TestDrawings.miz";

        [Fact]
        public async Task FullParse()
        {
            byte[] bytes = File.ReadAllBytes(file);


            var obj = await MizParser.TryParse(bytes);

        }
    }
}
