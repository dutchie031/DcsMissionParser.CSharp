using DcsMissionParser.Net.Annotations;
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

        internal bool IsGroupNameExists(string groupName)
        {
            return 
                Neutrals.IsGroupNameExists(groupName) ||
                Red.IsGroupNameExists(groupName) ||
                Blue.IsGroupNameExists(groupName);
        }

        internal bool IsUnitNameExists(string unitName)
        {
            return 
                Neutrals.IsUnitNameExists(unitName) ||
                Red.IsUnitNameExists(unitName) ||
                Blue.IsUnitNameExists(unitName);
        }

        internal int GetMaxGroupId()
        {
            var maxGroupId = 0;

            int max = Neutrals.GetMaxGroupId();
            if (max > maxGroupId)    
            {
                maxGroupId = max;
            }  

            max = Red.GetMaxGroupId();
            if (max > maxGroupId)    
            {
                maxGroupId = max;
            }  

            max = Blue.GetMaxGroupId();
            if (max > maxGroupId)    
            {
                maxGroupId = max;
            }  

            return maxGroupId;
        }

        internal int GetMaxUnitId()
        {
            var maxUnitId = 0;

            int max = Neutrals.GetMaxUnitId();
            if (max > maxUnitId)    
            {
                maxUnitId = max;
            }  

            max = Red.GetMaxUnitId();
            if (max > maxUnitId)    
            {
                maxUnitId = max;
            }  

            max = Blue.GetMaxUnitId();
            if (max > maxUnitId)    
            {
                maxUnitId = max;
            }  

            return maxUnitId;
        }
    }
}
