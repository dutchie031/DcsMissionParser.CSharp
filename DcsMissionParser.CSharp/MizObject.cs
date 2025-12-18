using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.CSharp.Objects.Drawings;

namespace DcsMissionParser.CSharp
{
    public class MizObject
    {
        
        [LuaKey("drawings")]
        public Drawings? Drawings { get; set; }

    }
}
