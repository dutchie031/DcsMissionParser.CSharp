using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;
using DcsMissionParser.Net.Objects.Commons;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks;

public abstract class PointTask
{
    [LuaKey("id")]
    public PointTaskId Id { get; set; } = PointTaskId.None;

    [LuaKey("number")]
    public int Number { get; set; } = 1;
}

public abstract class WrapperTask : PointTask { }

[LuaClassByStringValue(key: "id", value: PointTaskId.ComboTaskId)]
public class ComboTask : WrapperTask
{
    public ComboTask()  { Id = PointTaskId.ComboTask; }

    [LuaKey("params")]
    public Params Parameters { get; set; } = new();

    public class Params
    {
        [LuaKey("tasks")]
        public List<PointTask> Tasks { get; set; } = [];
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.MissionId)]
public class Mission : WrapperTask
{
    public Mission() => Id = PointTaskId.Mission;

    //TODO: Implement Mission Task Parameters
}

[LuaClassByStringValue(key: "id", value: PointTaskId.ControlledTaskId)]
public class ControlledTask : WrapperTask
{
    public ControlledTask()
    {
        Id = PointTaskId.Controlled;
    }

    public required PointTask Task { get; set; }
    //TODO: Implement Controlled Task Parameters
}

[LuaClassByStringValue(key: "id", value: PointTaskId.WrappedActionId)]
public class WrappedAction : WrapperTask
{
    public WrappedAction() => Id = PointTaskId.WrappedAction;

    [LuaKey("params")]
    public required Parameters Params { get; set; }

    public class Parameters
    {
        [LuaKey("action")]
        public required PointTask Action { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.AttackGroupId)]
public class AttackGroupTask : PointTask
{
    public AttackGroupTask() => Id = PointTaskId.AttackGroup;

    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("groupId")]
        public required int GroupId { get; set; }     

        [LuaKey("weaponType")]
        public WeaponType WeaponType { get; set; }

        [LuaKey("expend")]
        public WeaponExpend Expend { get; set; } = WeaponExpend.Auto;

        [LuaKey("directionEnabled")]
        public bool DirectionEnabled { get; set; } = false;

        [LuaKey("direction")]
        public double Direction { get; set; } = 0.0;

        [LuaKey("altitudeEnabled")]
        public bool AltitudeEnabled { get; set; } = false;

        [LuaKey("altitude")]
        public double Altitude { get; set; } = 0.0;

        [LuaKey("attackQtyLimit")]
        public bool AttackQtyLimit { get; set; } = false;

        [LuaKey("attackQty")]
        public int AttackQty { get; set; } = 1;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.AttackUnitId)]
public class AttackUnitTask : PointTask
{
    public AttackUnitTask() => Id = PointTaskId.AttackUnit;

    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("unitId")]
        public required int UnitId { get; set; }     

        [LuaKey("weaponType")]
        public WeaponType WeaponType { get; set; }

        [LuaKey("expend")]
        public WeaponExpend Expend { get; set; } = WeaponExpend.Auto;

        [LuaKey("direction")]
        public double Direction { get; set; } = 0.0;

        [LuaKey("attackQtyLimit")]
        public bool AttackQtyLimit { get; set; } = false;

        [LuaKey("attackQty")]
        public int AttackQty { get; set; } = 1;

        [LuaKey("groupAttack")]
        public bool GroupAttack { get; set; } = false;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.BombingId)]
public class BombingTask : PointTask
{
    public BombingTask() => Id = PointTaskId.Bombing;

    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("point")]
        public required Vec2 Point { get; set; }

        [LuaKey("weaponType")]
        public WeaponType WeaponType { get; set; }

        [LuaKey("expend")]
        public WeaponExpend Expend { get; set; } = WeaponExpend.Auto;

        [LuaKey("attackQty")]
        public int AttackQty { get; set; } = 1;

        [LuaKey("attackQtyLimit")]
        public bool AttackQtyLimit { get; set; } = false;

        [LuaKey("direction")]
        public double Direction { get; set; } 

        [LuaKey("groupAttack")]
        public bool GroupAttack { get; set; } = false;

        [LuaKey("altitude")]
        public double Altitude { get; set; }

        [LuaKey("altitudeEnabled")]
        public bool AltitudeEnabled { get; set; } = false;

        [LuaKey("attackType")]
        public string AttackType { get; } = "Dive"; //TODO: Verify possible other values
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.StrafingId)]
public class StrafingTask : PointTask
{
    public StrafingTask() => Id = PointTaskId.Strafing;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("point")]
        public required Vec2 Point { get; set; }

        [LuaKey("weaponType")]
        public WeaponType WeaponType { get; set; }

        [LuaKey("expend")]
        public WeaponExpend Expend { get; set; } = WeaponExpend.Auto;

        [LuaKey("attackQty")]
        public int AttackQty { get; set; } = 1;

        [LuaKey("attackQtyLimit")]
        public bool AttackQtyLimit { get; set; } = false;

        [LuaKey("direction")]
        public double Direction { get; set; } = 0.0;

        [LuaKey("directionEnabled")]
        public bool DirectionEnabled { get; set; } = false;

        [LuaKey("groupAttack")]
        public bool GroupAttack { get; set; } = false;

        [LuaKey("length")]
        public double Length { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.CarpetBombingId)]
public class CarpetBombingTask : PointTask
{
    public CarpetBombingTask() => Id = PointTaskId.CarpetBombing;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("attackType")]
        public string AttackType { get; } = "Carpet";

        [LuaKey("carpetLength")]
        public required double CarpetLength { get; set; }

        [LuaKey("point")]
        public required Vec2 Point { get; set; }

        [LuaKey("weaponType")]
        public WeaponType WeaponType { get; set; }

        [LuaKey("expend")]
        public WeaponExpend Expend { get; set; } = WeaponExpend.Auto;

        [LuaKey("attackQty")]
        public int AttackQty { get; set; } = 1;

        [LuaKey("attackQtyLimit")]
        public bool AttackQtyLimit { get; set; } = false;

        [LuaKey("groupAttack")]
        public bool GroupAttack { get; set; } = false;

        [LuaKey("altitude")]
        public double Altitude { get; set; }

        [LuaKey("altitudeEnabled")]
        public bool AltitudeEnabled { get; set; } = false;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.AttackMapObjectId)]
public class AttackMapObjectTask : PointTask
{
    public AttackMapObjectTask() => Id = PointTaskId.AttackMapObject;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("point")]
        public required Vec2 Point { get; set; }

        [LuaKey("weaponType")]
        public WeaponType WeaponType { get; set; }

        [LuaKey("expend")]
        public WeaponExpend Expend { get; set; } = WeaponExpend.Auto;

        [LuaKey("attackQty")]
        public int AttackQty { get; set; } = 1;

        [LuaKey("attackQtyLimit")]
        public bool AttackQtyLimit { get; set; } = false;

        [LuaKey("direction")]
        public double Direction { get; set; } = 0.0;

        [LuaKey("groupAttack")]
        public bool GroupAttack { get; set; } = false;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.BombingRunwayId)]
public class BombingRunwayTask : PointTask
{
    public BombingRunwayTask() => Id = PointTaskId.BombingRunway;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("runwayId")]
        public required AirdromeId RunwayId { get; set; }

        [LuaKey("weaponType")]
        public WeaponType WeaponType { get; set; }

        [LuaKey("expend")]
        public WeaponExpend Expend { get; set; } = WeaponExpend.Auto;

        [LuaKey("attackQty")]
        public int AttackQty { get; set; } = 1;

        [LuaKey("attackQtyLimit")]
        public bool AttackQtyLimit { get; set; } = false;

        [LuaKey("direction")]
        public double Direction { get; set; } = 0.0;

        [LuaKey("groupAttack")]
        public bool GroupAttack { get; set; } = false;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.OrbitId)]
public class OrbitTask : PointTask
{
    public OrbitTask() => Id = PointTaskId.Orbit;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("pattern")]
        public RaceTrackPattern Pattern { get; set; } = RaceTrackPattern.Circle;

        [LuaKey("point")]
        public required Vec2 Point { get; set; }

        [LuaKey("point2")]
        public Vec2? Point2 { get; set; }

        [LuaKey("speed")]
        public double Speed { get; set; }

        [LuaKey("altitude")]
        public double Altitude { get; set; }

        [LuaKey("hotLegDir")]
        public double HotLegDir { get; set; } = 0.0;

        [LuaKey("legLength")]
        public double LegLength { get; set; }

        [LuaKey("width")]
        public double Width { get; set; }

        [LuaKey("clockWise")]
        public bool ClockWise { get; set; } = true;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.RefuelingId)]
public class RefuelingTask : PointTask
{
    public RefuelingTask() => Id = PointTaskId.Refueling;

    [LuaKey("params")]
    public Params Parameters { get; } = new();

    public class Params {}
}

[LuaClassByStringValue(key: "id", value: PointTaskId.FollowId)]
public class FollowTask : PointTask
{
    public FollowTask() => Id = PointTaskId.Follow;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("groupId")]
        public required int GroupId { get; set; }

        /// <summary>
        /// Relative point to follow the target group
        /// </summary>
        [LuaKey("pos")]
        public required Vec3 Pos { get; set; }

        [LuaKey("lastWptIndexFlag")]
        public bool LastWptIndexFlag { get; set; } = true;

        [LuaKey("lastWptIndex")]
        public int LastWptIndex { get; set; } = -1;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.FollowBigFormationId)]
public class FollowBigFormationTask : PointTask
{
    public FollowBigFormationTask() => Id = PointTaskId.FollowBigFormation;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("groupId")]
        public required int GroupId { get; set; }

        /// <summary>
        /// Relative point to follow the target group in big formation
        /// </summary>
        [LuaKey("pos")]
        public required Vec3 Pos { get; set; }

        [LuaKey("lastWptIndexFlag")]
        public bool LastWptIndexFlag { get; set; } = true;

        [LuaKey("lastWptIndex")]
        public int LastWptIndex { get; set; } = -1;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.EscortId)]
public class EscortTask : PointTask
{
    public EscortTask() => Id = PointTaskId.Escort;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("groupId")]
        public required int GroupId { get; set; }

        /// <summary>
        /// Relative position to escort the target group
        /// </summary>
        [LuaKey("pos")]
        public required Vec3 Pos { get; set; }

        [LuaKey("lastWptIndexFlag")]
        public bool LastWptIndexFlag { get; set; } = true;

        [LuaKey("lastWptIndex")]
        public int LastWptIndex { get; set; } = -1;

        [LuaKey("engagementDistMax")]
        public double EngagementDistMax { get; set; } = 37040.0; //20NM

        [LuaKey("targetTypes")]
        public List<string> TargetTypes { get; set; } = [];
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.RecoveryTankerId)]
public class RecoveryTankerTask : PointTask
{
    public RecoveryTankerTask() => Id = PointTaskId.RecoveryTanker;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("groupId")]
        public required int GroupId { get; set; }

        [LuaKey("speed")]
        public double Speed { get; set; }

        [LuaKey("altitude")]
        public double Altitude { get; set; }

        [LuaKey("lastWptIndexFlag")]
        public bool LastWptIndexFlag { get; set; } = true;

        [LuaKey("lastWptIndex")]
        public int LastWptIndex { get; set; } = -1;
    }
}
