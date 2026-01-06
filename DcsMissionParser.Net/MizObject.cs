using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Coalitions;
using DcsMissionParser.Net.Objects.Drawing;

namespace DcsMissionParser.Net
{
    public class MizObject
    {
        [LuaKey("drawings")]
        public Drawings? Drawings { get; set; }

        [LuaKey("theatre")]
        public string? Theatre { get; set; }

        [LuaKey("coalition")]
        public Coalitions Coalitions { get; set; } = new Coalitions();

        [LuaKey("start_time")]
        public int StartTime { get; set; } = 0;

        //Currently a cursed dictionary that contains integers, strings and strings like "20" as keys.
        //[LuaKey("failures")]
        //public Dictionary<object, Failure> Failures { get; set; } = [];

    }
}
