using DcsMissionParser.CSharp.Annotations;

namespace DcsMissionParser.CSharp.Objects.Drawings
{
    public class Layer
    {
        [LuaKey("visible")]
        public bool Visible { get; set; }

        [LuaKey("name")]
        public string? Name { get; set; }

        [LuaKey("objects")]
        public List<DrawingObject> Objects { get; set; } = [];

    }
}
