using DcsMissionParser.CSharp.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcsMissionParser.Net.Objects.Coalitions
{
    public class Coalitions
    {
        [LuaKey("neutrals")]
        public Coalition Neutrals { get; set; } = new Coalition();

        [LuaKey("red")]
        public Coalition Red { get; set; } = new Coalition();

        [LuaKey("blue")]
        public Coalition Blue { get; set; } = new Coalition();
    }
}
