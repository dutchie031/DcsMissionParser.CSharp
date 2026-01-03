using System;
using System.Diagnostics.CodeAnalysis;

namespace DcsMissionParser.Net.CoordMapping;

public class ConvertConfig
{
    internal static TransverseMercatorSettings? GetSettings(string mapName)
    {
        return mapName.ToLower() switch
        {
            "caucasus" => new Caucasus(),
            _ => null
        };
    }

    internal class Caucasus : TransverseMercatorSettings
    {
        [SetsRequiredMembers]
        public Caucasus()
        {
            CentralMeridian = 33.000039;
            ScaleFactor = 0.9996;
            FalseEasting = -99513.815;
            FalseNorthing = -4998114.749;
        }
    }

    internal class TransverseMercatorSettings
    {
        public required double CentralMeridian { get; init; }
        public required double ScaleFactor { get; init; }
        public required double FalseEasting { get; init; }
        public required double FalseNorthing { get; init; }
    }

}
