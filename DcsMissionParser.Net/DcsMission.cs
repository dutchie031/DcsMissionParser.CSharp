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
        public Guid ParserId { get; init; } = Guid.NewGuid();

        //Currently a cursed dictionary that contains integers, strings and strings like "20" as keys.
        //[LuaKey("failures")]
        //public Dictionary<object, Failure> Failures { get; set; } = [];


        #region Helper Methods

        /// <summary>
        /// Checks if a group name exists in any coalition. <br>
        /// May be expensive with large missions, no cache is used for correctness <br>
        /// </summary>
        /// <param name="grouName"></param>
        /// <returns></returns>
        public bool IsGroupNameExists(string grouName)
        {
            return Coalitions.IsGroupNameExists(grouName);
        }

        /// <summary>
        /// Checks if a unit name exists in any coalition. <br>
        /// May be expensive with large missions, no cache is used for correctness <br>
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public bool IsUnitNameExists(string unitName)
        {
            return Coalitions.IsUnitNameExists(unitName);
        }


        /// <summary>
        /// Gets the next available group ID. <br>
        /// </summary>
        public int NextGroupId
        {
            get
            {
                if(field == -1)
                {
                    field = Coalitions.GetMaxGroupId() + 1;
                }
                return field++;
            } 
        } = -1;

        /// <summary>
        /// Gets the next available unit ID. <br>
        /// </summary>
        public int NextUnitId
        {
            get
            {
                if (field == -1)
                {
                    field = Coalitions.GetMaxUnitId() + 1;
                }
                return field++;
            }
        } = -1;


        #endregion


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
