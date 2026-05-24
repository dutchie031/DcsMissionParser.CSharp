using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.CoalitionConfiguration;
using DcsMissionParser.Net.Objects.Coalitions;
using DcsMissionParser.Net.Objects.Drawing;
using DcsMissionParser.Net.Objects.Weather;

namespace DcsMissionParser.Net
{
    public class DcsMission
    {
        // Internal constructor to prevent external instantiation without using the parser
        public DcsMission() { }

        [LuaKey("drawings")]
        public Drawings? Drawings { get; set; }

        [LuaKey("theatre")]
        public string? Theatre { get; set; }

        [LuaKey("coalition")]
        public Coalitions Coalitions { get; set; } = new Coalitions();

        [LuaKey("coalitions")]
        public CoalitionConfiguration CoalitionConfiguration { get; set; } = new CoalitionConfiguration();

        [LuaKey("start_time")]
        public int StartTime { get; set; } = 0;

        [LuaKey("version")]
        public int Version { get; set; } = 1;

        [LuaKey("currentKey")]
        public int CurrentKey { get; set; } = 1;

        [Experimental("NotImplementedMissionField")]
        [LuaKey("goals")]
        public object? Goals { get; set; } = new object();

        [Experimental("NotImplementedMissionField")]
        [LuaKey("weather")]
        public object? Weather { get; set; } = new Weather();

        /// <summary>
        /// A unique identifier for the parser instance that created this mission object. <br>
        /// It signals a "state" of the identifiers in all other objects. <br>
        /// If the ParserId has changed all other identifiers should be considered invalid and should not be used for comparison or reference.
        /// </summary>
        public Guid ParserId { get; } = Guid.NewGuid();

        //Currently a cursed dictionary that contains integers, strings and strings like "20" as keys.
        //[LuaKey("failures")]
        //public Dictionary<object, Failure> Failures { get; set; } = [];

        public static DcsMission CreateNewMission(string Theatre)
        {
            return DefaultMission.Create(Theatre);
        }

        public async Task SaveToFileAsync(string filePath)
        {
            if(Theatre == null)
            {
                throw new Exception("Theatre is required to save mission.");
            }

            var mizBytes = await MizSerializer.Serialize(this);
            if(!mizBytes.Success || mizBytes.Result == null)
            {
                throw new Exception($"Failed to serialize mission: {mizBytes.FailureReason}");
            }
            File.WriteAllBytes(filePath, mizBytes.Result);
        }
    }
}
