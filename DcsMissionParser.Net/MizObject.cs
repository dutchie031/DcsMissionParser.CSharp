using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.CSharp.Objects.Drawings;
using DcsMissionParser.CSharp.Objects.Failures;

namespace DcsMissionParser.CSharp
{
    public class MizObject
    {
        [LuaKey("drawings")]
        public Drawings? Drawings { get; set; }

        [LuaKey("theatre")]
        public string? Theatre { get; set; }


        //Currently a cursed dictionary that contains integers, strings and strings like "20" as keys.
        //[LuaKey("failures")]
        //public Dictionary<object, Failure> Failures { get; set; } = [];

    }
}
