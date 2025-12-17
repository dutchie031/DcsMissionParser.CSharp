using System.IO.Compression;
using Lua;

namespace DcsMissionParser.CSharp
{
    public class ParseResult
    {
        public bool Success { get; private set; }
        public string FailureReason { get; set; } = string.Empty;

        public MizObject? MizObject { get; set; } = null;

        private ParseResult() { }

        public static ParseResult Ok(MizObject mizObject)
        {
            return new ParseResult
            {
                Success = true,
                MizObject = mizObject
            };
        }
        public static ParseResult Fail(string reason)
        {
            return new ParseResult
            {
                Success = false,
                FailureReason = reason
            };
        }

    }

    public static class MizParser
    {


        public static async Task<ParseResult> TryParse(byte[] mizBytes) 
        {
            if(!GetMissionFile(mizBytes, out byte[] missionBytes, out string failureReason)) 
            {
                return ParseResult.Fail(failureReason);
            }

            LuaTable missionTable = await ParseMissionFile(missionBytes);






            return ParseResult.Ok(parsed);
        }

        private static MizObject MissionTable() 
        {
            
        }


        private static async Task<LuaTable> ParseMissionFile(byte[] mizBytes) 
        {

            var state = LuaState.Create();
            await state.DoStringAsync(System.Text.Encoding.UTF8.GetString(mizBytes));
            LuaTable table = state.Environment["mission"].Read<LuaTable>();

            return table;
        }


        private static bool GetMissionFile(byte[] miz, out byte[] mission, out string failureReason)
        {
            using ZipArchive archive = new ZipArchive(new MemoryStream(miz), ZipArchiveMode.Read);
            ZipArchiveEntry? missionEntry = archive.GetEntry("mission");
            if (missionEntry == null)
            {
                failureReason = "The .miz file does not contain a mission file";
                mission = [];
                return false;
            }

            using Stream missionStream = missionEntry.Open();
            using MemoryStream ms = new MemoryStream();
            missionStream.CopyTo(ms);
            mission = ms.ToArray();
            failureReason = string.Empty;
            return true;
        }

    }
}
