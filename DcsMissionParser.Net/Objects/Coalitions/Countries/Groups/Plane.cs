using DcsMissionParser.CSharp.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcsMissionParser.Net.Objects.Coalitions.Countries.Groups
{
    public class PlaneGroup
    {


        [LuaKey("dynSpawnTemplate")]
        public bool IsDynamicSpawnTemplate { get; set; }
    }
}
