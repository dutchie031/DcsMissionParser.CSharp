using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Routes.Plane;
using DcsMissionParser.Net.Objects.Coalitions.Units.Plane;
using DcsMissionParser.Net.Objects.Commons;
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

        [LuaKey("modulation")]
        public Modulation Modulation { get; set; }

        [LuaKey("radioSet")]
        public bool RadioSet { get; set; }

        [LuaKey("task")]
        public required PlaneTasking Tasking { get; set; }

        [LuaKey("uncontrolled")]
        public bool Uncontrolled { get; set; } = false;

        [LuaKey("groupId")]
        public int GroupId { get; set; }

        [LuaKey("hidden")]
        public bool IsHidden { get; set; }

        [LuaKey("x")]
        public double X { get; set; }

        [LuaKey("y")]
        public double Y { get; set; }

        [LuaKey("communication")]
        public bool Communication { get; set; }

        [LuaKey("start_time")]
        public double StartTime { get; set; }

        [LuaKey("frequency")]
        public double Frequency { get; set; }

        [LuaKey("units")]
        public List<PlaneUnit> Units { get; set; } = [];

        [LuaKey("route")]
        public Route Route { get; set; } = new ();
    }

    
    public class PlaneTasking : StringEnum
    {
        private PlaneTasking(string value) : base(value) {}
        
        public static readonly PlaneTasking AFAC = new("AFAC");
        public static readonly PlaneTasking AntishipStrike = new("Antiship Strike");
        public static readonly PlaneTasking AWACS = new("AWACS");
        public static readonly PlaneTasking CAP = new("CAP");
        public static readonly PlaneTasking CAS = new("CAS");
        public static readonly PlaneTasking Escort = new("Escort");
        public static readonly PlaneTasking FighterSweep = new("Fighter Sweep");
        public static readonly PlaneTasking GroundAttack = new("Ground Attack");
        public static readonly PlaneTasking Intercept = new("Intercept");
        public static readonly PlaneTasking Nothing = new("Nothing");
        public static readonly PlaneTasking PinpointStrike = new("Pinpoint Strike");
        public static readonly PlaneTasking Reconnaissance = new("Reconnaissance");
        public static readonly PlaneTasking Refueling = new("Refueling");
        public static readonly PlaneTasking RunwayAttack = new("Runway Attack");
        public static readonly PlaneTasking SEAD = new("SEAD");
        public static readonly PlaneTasking Transport = new("Transport");
    }
}
