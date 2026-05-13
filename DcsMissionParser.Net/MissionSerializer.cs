using DcsMissionParser.Net.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcsMissionParser.Net;
public class MissionSerializer
{
    public static async Task<ParseResult<byte[]>> Serialize(DcsMission mission)
    {
        try
        {
            return await MissionWriter.TryWriteAsync(mission);
        }
        catch (Exception ex)
        {
            return ParseResult<byte[]>.Fail($"Mission serialization failed: {ex.Message}");
        }
    }

    public static async Task<ParseResult<DcsMission>> Deserialize(byte[] mizBytes)
    {
        try
        {
            return await MissionParser.TryParse(mizBytes);
        }
        catch (Exception ex)
        {
            return ParseResult<DcsMission>.Fail($"Mission deserialization failed: {ex.Message}");
        }
    }

    public static async Task<ParseResult<DcsMission>> Deserialize(Stream stream)
    {
        try
        {
            //TODO: Optimize this by parsing directly from the stream instead of converting to byte array first.
            return await MissionParser.TryParse(stream);
        }
        catch (Exception ex)
        {
            return ParseResult<DcsMission>.Fail($"Mission deserialization failed: {ex.Message}");
        }
    }
}
