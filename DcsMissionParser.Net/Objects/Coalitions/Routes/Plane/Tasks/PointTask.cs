using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;
using DcsMissionParser.Net.Objects.Commons;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks;

public abstract class PointTask
{
    [LuaKey("id")]
    public PointTaskId Id { get; set; } = PointTaskId.None;
}

[LuaClassByStringValue(key: "id", value: PointTaskId.ComboTaskId)]
public class ComboTask : PointTask
{
    public ComboTask()
    {
        Id = PointTaskId.ComboTask;
    }

    [LuaKey("params")]
    public List<PointTask> Tasks { get; set; } = [];
}

[LuaClassByStringValue(key: "id", value: PointTaskId.MissionId)]
public class Mission : PointTask
{
    public Mission()
    {
        Id = PointTaskId.Mission;
    }

    //TODO: Implement Mission Task Parameters
}

[LuaClassByStringValue(key: "id", value: PointTaskId.ControlledTaskId)]
public class ControlledTask : PointTask
{
    public ControlledTask()
    {
        Id = PointTaskId.Controlled;
    }

    public required PointTask Task { get; set; }
    //TODO: Implement Controlled Task Parameters
}

[LuaClassByStringValue(key: "id", value: PointTaskId.WrappedActionId)]
public class WrappedAction : PointTask
{
    public WrappedAction()
    {
        Id = PointTaskId.WrappedAction;
    }

    [LuaKey("params")]
    public required Parameters Params { get; set; }

    public class Parameters
    {
        [LuaKey("action")]
        public required PointTask Action { get; set; }
    }
}

[LuaClassByStringValue(key: "id", value: PointTaskId.OptionsId)]
public abstract class OptionTask<T> : PointTask
{
    public OptionTask()
    {
        Id = PointTaskId.OptionAction;
    }

    [LuaKey("name")]
    public OptionTaskId OptionName { get; protected set;}

    [LuaKey("value")]
    public required T Value { get; set; }

}