
namespace DcsMissionParser.Net.Tests;

[TestClass]
public sealed class SaveMissionTest
{
    [TestMethod]
    public async Task ExportDefaultMission()
    {
        var mission = DcsMission.CreateNewMission("Caucasus");
        var miz = MissionSerializer.Serialize(mission);

        if(File.Exists("../../test.miz"))
        {
            File.Delete("../../test.miz");
        }

        await mission.SaveToFileAsync("../../test.miz");

        Assert.IsNotNull(miz);
    }
}
