using System;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;

public enum ECMUsing
{
    NEVER_USE                       = 0,
    USE_IF_ONLY_LOCK_BY_RADAR       = 1,
    USE_IF_DETECTED_LOCK_BY_RADAR   = 2,
    ALWAYS_USE                      = 3
}
