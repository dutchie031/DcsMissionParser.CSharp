using System;
using DcsMissionParser.Net.Objects.CoalitionConfiguration;
using DcsMissionParser.Net.Objects.Coalitions;
using DcsMissionParser.Net.Objects.Coalitions.Countries;
using DcsMissionParser.Net.Objects.Commons;
using DcsMissionParser.Net.Objects.Drawing;

namespace DcsMissionParser.Net;

public class DefaultMission
{
    public static MizObject Create(string theatre)
    {
        return new MizObject
        {
            Theatre = theatre,
            StartTime = 0,
            Coalitions = Coalitions(),
            Drawings = Drawings(),
            CoalitionConfiguration = CoalitionConfiguration(),
            Version = 23,
            CurrentKey = 10
        };
    }

    private static Coalitions Coalitions()
    {
        return new ()
        {
            Blue = new ()
            {
                Name = "blue",
                NavPoints = [],
                BullsEye = new Vec2 { X = 0, Y = 0 },
                Countries = []
            },
            Red = new ()
            {
                Name = "red",
                NavPoints = [],
                BullsEye = new Vec2 { X = 0, Y = 0 },
                Countries = []
            },
            Neutrals = new ()
            {
                Name = "neutrals",
                NavPoints = [],
                BullsEye = new Vec2 { X = 0, Y = 0 },
                Countries = []
            }
        };
    }


    private static Drawings Drawings()
    {
        return new ()
        {
            Layers = new List<Layer>
            {
                new ()
                {
                    Name = "Author",
                    Objects = []
                },
                new ()
                {
                    Name = "Common",
                    Objects = []
                },
                new ()
                {
                    Name = "Blue",
                    Objects = []
                },
                new ()
                {
                    Name = "Red",
                    Objects = []
                },
                new ()
                {
                    Name = "Neutral",
                    Objects = []
                }
            }  
        };
    }

    private static CoalitionConfiguration CoalitionConfiguration()
    {
        return new CoalitionConfiguration
        {
            Neutrals = [91, 70, 83, 23, 65, 86, 64, 25, 63, 76, 84, 90, 29, 62, 30, 78, 87, 31, 61, 32, 33, 60, 17, 35, 69, 36, 59, 71, 79, 58, 57, 56, 55, 92, 88, 73, 39, 89, 54, 77, 72, 41, 42, 44, 85, 75, 53, 22, 52, 66, 51, 74, 82, 7, 68, 50, 49, 48, 67],
            Red = [21, 11, 8, 80, 28, 26, 13, 5, 16, 6, 15, 20, 12, 40, 45, 9, 46, 10, 3, 4, 1, 2],
            Blue = [18, 24, 27, 81, 34, 37, 38, 0, 43, 19, 47]
        };
    }
}
