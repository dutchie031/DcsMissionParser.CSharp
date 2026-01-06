using System;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Routes.Common;
using DcsMissionParser.Net.Objects.Commons;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks;

public class CommandTask : PointTask
{
    // Base class for command tasks
}

[LuaClassByStringValue(key: "id", value: PointTaskId.ScriptId)]
public class ScriptTask : CommandTask
{
    public ScriptTask() => Id = PointTaskId.Script;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("command")]
        public required string Command { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.SetCallsignId)]
public class SetCallsignTask : CommandTask
{
    public SetCallsignTask() => Id = PointTaskId.SetCallsign;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        //TODO: Make this enumerator: https://wiki.hoggitworld.com/view/DCS_command_setCallsign
        [LuaKey("callname")]
        public required int Callname { get; set; }

        [LuaKey("number")]
        public required int Number { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.SetFrequencyId)]
public class SetFrequencyTask : CommandTask
{
    public SetFrequencyTask() => Id = PointTaskId.SetFrequency;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("frequency")]
        public required double Frequency { get; set; }

        [LuaKey("modulation")]
        public Modulation Modulation { get; set; } = Modulation.FM;

        [LuaKey("power")]
        public double Power { get; set; } = 10.0;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.SetFrequencyForUnitId)]
public class SetFrequencyForUnitTask : CommandTask
{
    public SetFrequencyForUnitTask() => Id = PointTaskId.SetFrequencyForUnit;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("frequency")]
        public required double Frequency { get; set; }

        [LuaKey("modulation")]
        public Modulation Modulation { get; set; } = Modulation.FM;

        [LuaKey("power")]
        public double Power { get; set; } = 10.0;

        [LuaKey("unitId")]
        public required int UnitId { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.SwitchWaypointId)]
public class SwitchWaypointTask : CommandTask
{
    public SwitchWaypointTask() => Id = PointTaskId.SwitchWaypoint;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("fromWaypointIndex")]
        public required int FromWaypointIndex { get; set; }

        [LuaKey("goToWaypointIndex")]
        public required int GoToWaypointIndex { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.SwitchActionId)]
public class SwitchActionTask : CommandTask
{
    public SwitchActionTask() => Id = PointTaskId.SwitchAction;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        /// <summary>
        /// The index of the action you wish to switch to.
        /// </summary>
        [LuaKey("actionIndex")]
        public required int ActionIndex { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.SetInvisibleId)]
public class SetInvisibleTask : CommandTask
{
    public SetInvisibleTask() => Id = PointTaskId.SetInvisible;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("value")]
        public required bool Value { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.SetImmortalId)]
public class SetImmortalTask : CommandTask
{
    public SetImmortalTask() => Id = PointTaskId.SetImmortal;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        /// <summary>
        /// True enables immortality, false disables it.
        /// </summary>
        [LuaKey("value")]
        public required bool Value { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.SetUnlimitedFuelId)]
public class SetUnlimitedFuelTask : CommandTask
{
    public SetUnlimitedFuelTask() => Id = PointTaskId.SetUnlimitedFuel;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("value")]
        public required bool Value { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.ActivateBeaconId)]
public class ActivateBeaconTask : CommandTask
{
    public ActivateBeaconTask() => Id = PointTaskId.ActivateBeacon;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("type")]
        public required BeaconType Type { get; set; }

        [LuaKey("system")]
        public required BeaconSystemType System { get; set; }

        [LuaKey("name")]
        public required string Name { get; set; }

        [LuaKey("callsign")]
        public required string Callsign { get; set; }

        [LuaKey("frequency")]
        public required double Frequency { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.DeactivateBeaconId)]
public class DeactivateBeaconTask : CommandTask
{
    public DeactivateBeaconTask() => Id = PointTaskId.DeactivateBeacon;

    [LuaKey("params")]
    public Params Parameters { get; set; } = new();

    public class Params
    {
        // Empty params class as per specification
    }
}


[LuaClassByStringValue(key: "id", value: PointTaskId.EPLRSId)]
public class EPLRSTask : CommandTask
{
    public EPLRSTask() => Id = PointTaskId.EPLRS;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("value")]
        public required bool Value { get; set; }

        [LuaKey("groupId")]
        public required int GroupId { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.StartId)]
public class StartTask : CommandTask
{
    public StartTask() => Id = PointTaskId.Start;

    [LuaKey("params")]
    public Params Parameters { get; set; } = new();

    public class Params
    {
        // Empty params class as per specification
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.TransmitMessageId)]
public class TransmitMessageTask : CommandTask
{
    public TransmitMessageTask() => Id = PointTaskId.TransmitMessage;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("duration")]
        public required double Duration { get; set; }

        [LuaKey("subtitle")]
        public required string Subtitle { get; set; }

        [LuaKey("loop")]
        public required bool Loop { get; set; }

        [LuaKey("file")]
        public required string File { get; set; }
    }
}


[LuaClassByStringValue(key: "id", value: PointTaskId.StopTransmissionId)]
public class StopTransmissionTask : CommandTask
{
    public StopTransmissionTask() => Id = PointTaskId.StopTransmission;

    [LuaKey("params")]
    public Params Parameters { get; set; } = new();

    public class Params
    {
        // Empty params class as per specification
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.SmokeOnOffId)]
public class SmokeOnOffTask : CommandTask
{
    public SmokeOnOffTask() => Id = PointTaskId.SmokeOnOff;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("value")]
        public required bool Value { get; set; }
    }
}

