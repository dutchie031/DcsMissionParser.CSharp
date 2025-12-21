using DcsMissionParser.Net.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcsMissionParser.Net
{
    public class MissionSerializer
    {
        public static async Task<ParseResult<MizObject>> Deserialize(byte[] mizBytes) 
        {
            return await MizParser.TryParse(mizBytes);
        }

        public static async Task<ParseResult<byte[]>> Serialize(MizObject mizObject) 
        {
            try
            {
                return await MissionWriter.TryWriteAsync(mizObject);
            }
            catch (Exception ex) 
            {
                return ParseResult<byte[]>.Fail($"Serialization failed: {ex.Message}");
            }
        }
    }
}
