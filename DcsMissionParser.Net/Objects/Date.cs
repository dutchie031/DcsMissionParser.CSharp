using DcsMissionParser.CSharp.Annotations;

namespace DcsMissionParser.Net.Objects
{
    public class Date
    {
        [LuaKey("Day")]
        public int Day { get; set; }

        [LuaKey("Month")]
        public int Month { get; set; }

        [LuaKey("Year")]
        public int Year { get; set; }
    }
}
