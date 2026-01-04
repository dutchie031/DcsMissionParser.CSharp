using DcsMissionParser.CSharp.Annotations;
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

        [LuaKey("plane")]
        public Planes Planes { get; set; } = new ();


        
    }
}
