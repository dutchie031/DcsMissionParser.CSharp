using System;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks;


public class PointTaskId : StringEnum
{
    private PointTaskId(string value) : base(value) { }
    
    public static readonly PointTaskId None = new ("None");

    internal const string ComboTaskId = "ComboTask";
    public static readonly PointTaskId ComboTask = new (ComboTaskId);

    internal const string MissionId = "Mission";  
    public static readonly PointTaskId Mission = new (MissionId);
    
    internal const string ControlledTaskId = "ControlledTask";
    public static readonly PointTaskId Controlled = new (ControlledTaskId);

    internal const string WrappedActionId = "WrappedAction";
    public static readonly PointTaskId WrappedAction = new (WrappedActionId);

    internal const string OptionsId = "Option";
    public static readonly PointTaskId OptionAction = new (OptionsId); 

    internal const string AttackGroupId = "AttackGroup";
    public static readonly PointTaskId AttackGroup = new (AttackGroupId);

    internal const string AttackUnitId = "AttackUnit";
    public static readonly PointTaskId AttackUnit = new (AttackUnitId);    

    internal const string BombingId = "Bombing";
    public static readonly PointTaskId Bombing = new (BombingId);

    internal const string StrafingId = "Strafing";
    public static readonly PointTaskId Strafing = new (StrafingId);

    internal const string CarpetBombingId = "CarpetBombing";
    public static readonly PointTaskId CarpetBombing = new (CarpetBombingId);

    internal const string AttackMapObjectId = "AttackMapObject";
    public static readonly PointTaskId AttackMapObject = new (AttackMapObjectId);

    internal const string BombingRunwayId = "BombingRunway";
    public static readonly PointTaskId BombingRunway = new (BombingRunwayId);
    
    internal const string OrbitId = "Orbit";
    public static readonly PointTaskId Orbit = new (OrbitId);

    internal const string RefuelingId = "Refueling";
    public static readonly PointTaskId Refueling = new (RefuelingId);

    internal const string FollowId = "Follow";
    public static readonly PointTaskId Follow = new (FollowId);
 
    internal const string FollowBigFormationId = "FollowBigFormation";
    public static readonly PointTaskId FollowBigFormation = new (FollowBigFormationId);

    internal const string EscortId = "Escort";
    public static readonly PointTaskId Escort = new (EscortId);

    internal const string RecoveryTankerId = "RecoveryTanker";
    public static readonly PointTaskId RecoveryTanker = new (RecoveryTankerId);

    internal const string EngageTargetsId = "EngageTargets";
    public static PointTaskId EngageTargets => new (EngageTargetsId);

    internal const string EngageTargetsInZoneId = "EngageTargetsInZone";
    public static PointTaskId EngageTargetsInZone => new (EngageTargetsInZoneId);

    internal const string EngageGroupId = "EngageGroup";
    public static PointTaskId EngageGroup => new (EngageGroupId);

    internal const string EngageUnitId = "EngageUnit";
    public static PointTaskId EngageUnit => new (EngageUnitId);

    internal const string AWACSId = "AWACS";
    public static PointTaskId AWACS => new (AWACSId);

    internal const string TankerId = "Tanker";
    public static PointTaskId Tanker => new (TankerId);

    internal const string FACId = "FAC";
    public static PointTaskId FAC => new (FACId);

    internal const string ScriptId = "Script";
    public static PointTaskId Script => new (ScriptId);

    internal const string SetCallsignId = "SetCallsign";
    public static PointTaskId SetCallsign => new (SetCallsignId);

    internal const string SetFrequencyId = "SetFrequency";
    public static PointTaskId SetFrequency => new (SetFrequencyId);

    internal const string SetFrequencyForUnitId = "SetFrequencyForUnit";
    public static PointTaskId SetFrequencyForUnit => new (SetFrequencyForUnitId);

    internal const string SwitchWaypointId = "SwitchWaypoint";
    public static PointTaskId SwitchWaypoint => new (SwitchWaypointId);

    internal const string SwitchActionId = "SwitchAction";
    public static PointTaskId SwitchAction => new (SwitchActionId);

    internal const string SetInvisibleId = "SetInvisible";
    public static PointTaskId SetInvisible => new (SetInvisibleId);

    internal const string SetImmortalId = "SetImmortal";
    public static PointTaskId SetImmortal => new (SetImmortalId);

    internal const string SetUnlimitedFuelId = "SetUnlimitedFuel";
    public static PointTaskId SetUnlimitedFuel => new (SetUnlimitedFuelId);

    internal const string ActivateBeaconId = "ActivateBeacon";
    public static PointTaskId ActivateBeacon => new (ActivateBeaconId);

    internal const string DeactivateBeaconId = "DeactivateBeacon";
    public static PointTaskId DeactivateBeacon => new (DeactivateBeaconId);

    internal const string EPLRSId = "EPLRS";
    public static PointTaskId EPLRS => new (EPLRSId);

    internal const string StartId = "Start";
    public static PointTaskId Start => new (StartId);

    internal const string TransmitMessageId = "TransmitMessage";
    public static PointTaskId TransmitMessage => new (TransmitMessageId);

    internal const string StopTransmissionId = "stopTransmission";
    public static PointTaskId StopTransmission => new (StopTransmissionId);

    internal const string SmokeOnOffId = "SMOKE_ON_OFF";
    public static PointTaskId SmokeOnOff => new (SmokeOnOffId);

}