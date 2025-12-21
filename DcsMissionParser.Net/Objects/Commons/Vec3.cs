using DcsMissionParser.CSharp.Annotations;

namespace DcsMissionParser.Net.Objects.Commons
{
    public class Vec3
    {
        [LuaKey("x")]
        public double X { get; set; }
        [LuaKey("y")]
        public double Y { get; set; }
        [LuaKey("z")]
        public double Z { get; set; }
    }
}
