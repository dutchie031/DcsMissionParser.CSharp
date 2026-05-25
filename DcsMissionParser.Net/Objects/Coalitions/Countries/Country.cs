using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Countries.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcsMissionParser.Net.Objects.Coalitions.Countries
{
    public class Country
    {
        [LuaKey("id")]
        public int Id { get; set; }

        [LuaKey("name")]
        public string Name { get; set; } = string.Empty;

        [LuaKey("plane")]
        public Planes Planes { get; set; } = new ();

        internal bool IsGroupNameExists(string groupName)
        {
            //TODO: Add other types once they come in.
            return 
                Planes.Groups.Any(g => g.GroupName.Equals(groupName, StringComparison.OrdinalIgnoreCase));
        }

        internal bool IsUnitNameExists(string unitName)
        {
            //TODO: Add other types once they come in.
            return 
                Planes.Groups.Any(g => g.Units.Any(u => u.Name.Equals(unitName, StringComparison.OrdinalIgnoreCase)));
        }

        internal int GetMaxGroupId()
        {
            return Planes.Groups.Max(g => g.GroupId);
        }

        internal int GetMaxUnitId()
        {
            return Planes.Groups.SelectMany(g => g.Units).Max(u => u.UnitId);
        }

    }
}
