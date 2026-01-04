using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Countries;
using DcsMissionParser.Net.Objects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcsMissionParser.Net.Objects.Coalitions
{
    public class Coalition
    {
        [LuaKey("bullseye")]
        public Vec2 BullsEye { get; set; } = new Vec2 { X = 0, Y = 0 };

        [LuaKey("nav_points")]
        public List<NavPoint> NavPoints { get; set; } = [];

        [LuaKey("name")]
        public string Name { get; set; } = "neutrals";

        [LuaKey("country")]
        public List<Country> Countries { get; set; } = [];
    }
}
