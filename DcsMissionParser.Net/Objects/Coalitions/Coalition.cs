using DcsMissionParser.Net.Annotations;
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

        internal bool IsGroupNameExists(string groupName)
        {
            return Countries.Any(c => c.IsGroupNameExists(groupName));
        }

        internal bool IsUnitNameExists(string unitName)
        {
            return Countries.Any(c => c.IsUnitNameExists(unitName));
        }

        internal int GetMaxGroupId()
        {
            return Countries.Select(c => c.GetMaxGroupId()).DefaultIfEmpty(0).Max();
        }

        internal int GetMaxUnitId()
        {
            return Countries.Select(c => c.GetMaxUnitId()).DefaultIfEmpty(0).Max();
        }
    }
}
