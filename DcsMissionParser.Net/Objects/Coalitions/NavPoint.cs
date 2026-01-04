using DcsMissionParser.CSharp.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcsMissionParser.Net.Objects.Coalitions
{
    public class NavPoint
    {
        [LuaKey("type")]
        public string Type { get; set; } = "Default";

        [LuaKey("comment")]
        public string Comment { get; set; } = String.Empty;

        [LuaKey("callSignStr")]
        public required string CallSignString { get; set; }

        [LuaKey("id")]
        public required int Id { get; set; }

        [LuaKey("properties")]
        public NavPointProperties Properties { get; set; } = new();
    }

    public class NavPointProperties
    {
        [LuaKey("vnav")]
        public NavPointVNAV VNAV { get; set; }

        [LuaKey("scale")]
        public NavPointScale Scale { get; set; }


        //TODO: Finalise and verify all values

    }

    public enum NavPointVNAV 
    {
        VNAV_2D = 0,
        VNAV_3D = 1,
        none = 3
    }

    public enum NavPointScale 
    {
        ENROUTE = 0,
        TERMINAL = 1,
        APPROACH = 2,
        HIGH_ACC = 3,
        None = 5
    }
}
