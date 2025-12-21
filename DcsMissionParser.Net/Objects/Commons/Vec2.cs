using DcsMissionParser.CSharp.Annotations;

namespace DcsMissionParser.Net.Objects.Commons
{
    public class Vec2
    {
        [LuaKey("x")]
        public double X { get; set; }

        [LuaKey("y")]
        public double Y { get; set; }

    }
}
