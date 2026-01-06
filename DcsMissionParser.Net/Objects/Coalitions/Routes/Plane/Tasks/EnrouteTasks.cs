using System;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;
using DcsMissionParser.Net.Objects.Commons;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks;


public abstract class EnrouteTask : PointTask
{
    // Base class for enroute tasks
}

[LuaClassByStringValue(key: "id", value: PointTaskId.EngageTargetsId)]
public class EngageTargetsTask : EnrouteTask
{
    public EngageTargetsTask() => Id = PointTaskId.EngageTargets;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("maxDist")]
        public double MaxDist { get; set; } = 50000.0;

        /// <summary>
        /// Required to check maxDist
        /// </summary>
        [LuaKey("maxDistEnabled")]
        public bool MaxDistEnabled { get; set; } = false;

        [LuaKey("targetTypes")]
        public List<string> TargetTypes { get; set; } = [];

        [LuaKey("priority")]
        public int Priority { get; set; } = 0;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.EngageTargetsInZoneId)]
public class EngageTargetsInZoneTask : EnrouteTask
{
    public EngageTargetsInZoneTask() => Id = PointTaskId.EngageTargetsInZone;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("point")]
        public required Vec2 Point { get; set; }

        [LuaKey("zoneRadius")]
        public double ZoneRadius { get; set; }

        [LuaKey("targetTypes")]
        public List<string> TargetTypes { get; set; } = [];

        [LuaKey("priority")]
        public int Priority { get; set; } = 0;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.EngageGroupId)]
public class EngageGroupTask : EnrouteTask
{
    public EngageGroupTask() => Id = PointTaskId.EngageGroup;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("groupId")]
        public required int GroupId { get; set; }

        [LuaKey("weaponType")]
        public WeaponType WeaponType { get; set; }

        [LuaKey("expend")]
        public WeaponExpend Expend { get; set; } = WeaponExpend.Auto;

        [LuaKey("attackQty")]
        public int AttackQty { get; set; } = 1;

        [LuaKey("direction")]
        public double Direction { get; set; } = 0.0;

        [LuaKey("attackQtyLimit")]
        public bool AttackQtyLimit { get; set; } = false;

        [LuaKey("priority")]
        public int Priority { get; set; } = 0;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.EngageUnitId)]
public class EngageUnitTask : EnrouteTask
{
    public EngageUnitTask() => Id = PointTaskId.EngageUnit;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("unitId")]
        public required int UnitId { get; set; }

        [LuaKey("weaponType")]
        public WeaponType WeaponType { get; set; }

        [LuaKey("expend")]
        public WeaponExpend Expend { get; set; } = WeaponExpend.Auto;

        [LuaKey("attackQty")]
        public int AttackQty { get; set; } = 1;

        [LuaKey("direction")]
        public double Direction { get; set; } = 0.0;

        [LuaKey("attackQtyLimit")]
        public bool AttackQtyLimit { get; set; } = false;

        [LuaKey("groupAttack")]
        public bool GroupAttack { get; set; } = false;

        [LuaKey("priority")]
        public int Priority { get; set; } = 0;
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.AWACSId)]
public class AWACSTask : EnrouteTask
{
    public AWACSTask() => Id = PointTaskId.AWACS;

    [LuaKey("params")]
    public Params Parameters { get; set; } = new();

    public class Params
    {
        // Empty params class as per specification
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.TankerId)]
public class TankerTask : EnrouteTask
{
    public TankerTask() => Id = PointTaskId.Tanker;

    [LuaKey("params")]
    public Params Parameters { get; set; } = new();

    public class Params
    {
        // Empty params class as per specification
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.FACId)]
public class FACTask : EnrouteTask
{
    public FACTask() => Id = PointTaskId.FAC;

    [LuaKey("params")]
    public required Params Parameters { get; set; }

    public class Params
    {
        [LuaKey("frequency")]
        public double Frequency { get; set; } = 251.0;

        [LuaKey("modulation")]
        public Modulation Modulation { get; set; } = Modulation.FM;

        [LuaKey("callname")]
        public int Callname { get; set; } = 1;

        [LuaKey("number")]
        public int Number { get; set; } = 1;

        [LuaKey("priority")]
        public int Priority { get; set; } = 0;
    }
}
