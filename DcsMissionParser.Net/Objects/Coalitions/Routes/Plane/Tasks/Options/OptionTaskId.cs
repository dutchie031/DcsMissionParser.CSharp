using System;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;

public enum OptionTaskId
{
    ROE                        = 0,
    REACTION_ON_THREAT         = 1,
    RADAR_USING                = 3,
    FLARE_USING                = 4,
    Formation                  = 5,
    RTB_ON_BINGO               = 6,
    SILENCE                    = 7,
    RTB_ON_OUT_OF_AMMO         = 10,
    ECM_USING                  = 13,
    PROHIBIT_AA                = 14,
    PROHIBIT_JETT              = 15,
    PROHIBIT_AB                = 16,
    PROHIBIT_AG                = 17,
    MISSILE_ATTACK             = 18,
    PROHIBIT_WP_PASS_REPORT    = 19,
    OPTION_RADIO_USAGE_CONTACT = 21,
    OPTION_RADIO_USAGE_ENGAGE  = 22,
    OPTION_RADIO_USAGE_KILL    = 23,
    JETT_TANKS_IF_EMPTY        = 25,
    FORCED_ATTACK              = 26,
    PREFER_VERTICAL            = 32,
    ALLOW_FORMATION_SIDE_SWAP  = 35
}
