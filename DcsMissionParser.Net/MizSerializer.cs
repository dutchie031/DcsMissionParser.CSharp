using System;
using System.IO.Compression;
using DcsMissionParser.Net.Parsers;

namespace DcsMissionParser.Net;

public class MizSerializer
{
    /// <summary>
    /// Deserializes a .miz file (as a byte array) into a DcsMission object.
    /// </summary>
    /// <param name="mizBytes">The byte array representing the .miz file.</param>
    /// <returns>A ParseResult containing the deserialized DcsMission object.</returns>
    public static async Task<ParseResult<DcsMission>> Deserialize(byte[] mizBytes)
    {
        using ZipArchive zip = new (new MemoryStream(mizBytes), ZipArchiveMode.Read);
        var missionEntry = zip.GetEntry("mission");
        if (missionEntry == null)        {
            return ParseResult<DcsMission>.Fail("Mission file not found in .miz archive.");
        }
        
        using var missionStream = missionEntry.Open();
        return await MissionSerializer.Deserialize(missionStream);
    }

    /// <summary>
    /// Serializes a DcsMission object into a byte array that can be saved as a .miz file.
    /// </summary>
    /// <param name="mizObject">The DcsMission object to serialize.</param>
    /// <returns>A ParseResult containing the serialized byte array.</returns>
    public static async Task<ParseResult<byte[]>> Serialize(DcsMission mizObject) 
    {
        try
        {
            ParseResult<byte[]> missionBytes = await MissionWriter.TryWriteAsync(mizObject);
            if(!missionBytes.Success || missionBytes.Result == null)
            {
                return ParseResult<byte[]>.Fail($"Mission serialization failed: {missionBytes.FailureReason}");
            }

            using MemoryStream memoryStream = new ();
            using (ZipArchive zip = new (memoryStream, ZipArchiveMode.Create, true))
            {
                var entry = zip.CreateEntry("mission");
                using (var entryStream = entry.Open())
                {
                    await entryStream.WriteAsync(missionBytes.Result, 0, missionBytes.Result.Length);
                }

                var theatreEntry = zip.CreateEntry("theatre");
                using (var theatreStream = theatreEntry.Open())
                {   
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(mizObject.Theatre ?? string.Empty);
                    await theatreStream.WriteAsync(bytes, 0, bytes.Length);
                }
            }
            
            return ParseResult<byte[]>.Ok(memoryStream.ToArray());
        }
        catch (Exception ex) 
        {
            return ParseResult<byte[]>.Fail($"Serialization failed: {ex.Message}");
        }
    }
}
