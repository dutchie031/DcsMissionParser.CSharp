using System;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks;

[LuaClassByStringValue(key: "id", value: PointTaskId.OptionsId)]
public abstract class OptionTask<T> : PointTask
{
    public OptionTask()
    {
        Id = PointTaskId.OptionAction;
    }

    [LuaKey("params")]
    public required OptionTaskParams Parameters { get; set; }

    public class OptionTaskParams
    {
        [LuaKey("name")]
        public OptionTaskId OptionName { get; internal set;}

        [LuaKey("value")]
        public required T Value { get; set; }
    }
}


[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.ROE)]
public class SetROETask : OptionTask<ROE>
{
    public SetROETask()
    {
        Parameters = new OptionTaskParams() 
        { 
            OptionName = OptionTaskId.ROE,
            Value = ROE.RETURN_FIRE
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.REACTION_ON_THREAT)]
public class SetReactionToThreatTask : OptionTask<ReactionToThreat>
{
    public SetReactionToThreatTask()
    {
        Parameters = new OptionTaskParams() 
        { 
            OptionName = OptionTaskId.REACTION_ON_THREAT,
            Value = ReactionToThreat.EVADE_FIRE
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.RADAR_USING)]
public class SetRadarUsing : OptionTask<RadarUsing>
{
    public SetRadarUsing()
    {
        Parameters = new OptionTaskParams() 
        { 
            OptionName = OptionTaskId.RADAR_USING,
            Value = RadarUsing.FOR_SEARCH_IF_REQUIRED
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.FLARE_USING)]
public class SetFlareUsing : OptionTask<FlareUsing>
{
    public SetFlareUsing()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.FLARE_USING,
            Value = FlareUsing.WHEN_FLYING_NEAR_ENEMIES
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.ECM_USING)]
public class SetECMUsing : OptionTask<ECMUsing>
{
    public SetECMUsing()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.ECM_USING,
            Value = ECMUsing.USE_IF_DETECTED_LOCK_BY_RADAR
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.MISSILE_ATTACK)]
public class SetMissileAttackRange : OptionTask<MissileAttackRange>
{
    public SetMissileAttackRange()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.MISSILE_ATTACK,
            Value = MissileAttackRange.RANDOM_RANGE
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.RTB_ON_BINGO)]
public class SetRTBOnBingo : OptionTask<bool>
{
    public SetRTBOnBingo()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.RTB_ON_BINGO,
            Value = true
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.RTB_ON_OUT_OF_AMMO)]
public class SetRTBOnOutOfAMMO : OptionTask<bool>
{
    public SetRTBOnOutOfAMMO()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.RTB_ON_OUT_OF_AMMO,
            Value = true
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.SILENCE)]
public class SetSilence : OptionTask<bool>
{
    public SetSilence()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.SILENCE,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.PROHIBIT_AA)]
public class SetProhibitAA : OptionTask<bool>
{
    public SetProhibitAA()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.PROHIBIT_AA,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.PROHIBIT_JETT)]
public class SetProhibitJettison : OptionTask<bool>
{
    public SetProhibitJettison()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.PROHIBIT_JETT,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.PROHIBIT_AB)]
public class SetProhibitAfterBurner : OptionTask<bool>
{
    public SetProhibitAfterBurner()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.PROHIBIT_AB,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.PROHIBIT_AG)]
public class SetProhibitAG : OptionTask<bool>
{
    public SetProhibitAG()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.PROHIBIT_AG,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.PROHIBIT_WP_PASS_REPORT)]
public class SetProhibitWPPassReport : OptionTask<bool>
{
    public SetProhibitWPPassReport()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.PROHIBIT_WP_PASS_REPORT,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.OPTION_RADIO_USAGE_CONTACT)]
public class SetProhibitRadioUsageContact : OptionTask<bool>
{
    public SetProhibitRadioUsageContact()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.OPTION_RADIO_USAGE_CONTACT,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.OPTION_RADIO_USAGE_ENGAGE)]
public class SetProhibitRadioUsageEngage : OptionTask<bool>
{
    public SetProhibitRadioUsageEngage()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.OPTION_RADIO_USAGE_ENGAGE,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.OPTION_RADIO_USAGE_KILL)]
public class SetProhibitRadioUsageKill : OptionTask<bool>
{
    public SetProhibitRadioUsageKill()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.OPTION_RADIO_USAGE_KILL,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.JETT_TANKS_IF_EMPTY)]
public class SetJettisonTanksIfEmpty : OptionTask<bool>
{
    public SetJettisonTanksIfEmpty()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.JETT_TANKS_IF_EMPTY,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.FORCED_ATTACK)]
public class SetForcedAttack : OptionTask<bool>
{
    public SetForcedAttack()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.FORCED_ATTACK,
            Value = false
        };
    }
}

[LuaClassByEnum<OptionTaskId>("params.name", OptionTaskId.ALLOW_FORMATION_SIDE_SWAP)]
public class SetAllowFormationSideSwap : OptionTask<bool>
{
    public SetAllowFormationSideSwap()
    {
        Parameters = new OptionTaskParams()
        {
            OptionName = OptionTaskId.ALLOW_FORMATION_SIDE_SWAP,
            Value = false
        };
    }
}

