using System;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;

public enum RadarUsing
{
    NEVER                   = 0,
    FOR_ATTACK_ONLY         = 1,
    FOR_SEARCH_IF_REQUIRED  = 2,
    FOR_CONTINUOUS_SEARCH   = 3
}
