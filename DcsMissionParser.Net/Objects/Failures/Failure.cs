using DcsMissionParser.CSharp.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcsMissionParser.CSharp.Objects.Failures
{
    public class Failure
    {
        [LuaKey("hh")]
        public double HH { get; set; }
        [LuaKey("prob")]
        public double Probability { get; set; }
        [LuaKey("enable")]
        public bool Enable { get; set; }
        [LuaKey("mmint")]
        public double MMint { get; set; }
        [LuaKey("mm")]
        public double MM { get; set; }
        [LuaKey("id")]
        public required string ID { get; set; }

    }
}
