using System;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;

public enum ReactionToThreat
{
    NO_REACTION          = 0,
    PASSIVE_DEFENCE      = 1,
    EVADE_FIRE           = 2,
    BYPASS_AND_ESCAPE    = 3,
    ALLOW_ABORT_MISSION  = 4,
    AAA_EVADE_FIRE       = 5
}
