using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Commons;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks;

public abstract class PointTask
{
    [LuaKey("id")]
    public PointTaskID Id { get; set; } = PointTaskID.None;
}

[LuaClassByStringValue(key: "id", value: PointTaskID.ComboTaskId)]
public class ComboTask : PointTask
{
    public ComboTask()
    {
        Id = PointTaskID.ComboTask;
    }

    [LuaKey("params")]
    public List<PointTask> Tasks { get; set; } = [];
}

[LuaClassByStringValue(key: "id", value: PointTaskID.MissionId)]
public class Mission : PointTask
{
    public Mission()
    {
        Id = PointTaskID.Mission;
    }

    //TODO: Implement Mission Task Parameters
}

[LuaClassByStringValue(key: "id", value: PointTaskID.ControlledTaskId)]
public class ControlledTask : PointTask
{
    public ControlledTask()
    {
        Id = PointTaskID.Controlled;
    }

    public required PointTask Task { get; set; }
    //TODO: Implement Controlled Task Parameters
}

[LuaClassByStringValue(key: "id", value: PointTaskID.WrappedActionId)]
public class WrappedAction : PointTask
{
    public WrappedAction()
    {
        Id = PointTaskID.WrappedAction;
    }

    [LuaKey("params")]
    public WrappedActionParams Params { get; set; } = new ();
}

public class WrappedActionParams
{

    public class Action 
    {
        
    }
}


public class PointTaskID : StringEnum
{
    private PointTaskID(string value) : base(value) { }
    public static PointTaskID None => new ("None");

    internal const string ComboTaskId = "ComboTask";
    public static PointTaskID ComboTask => new (ComboTaskId);

    internal const string MissionId = "Mission";  
    public static PointTaskID Mission => new (MissionId);
    
    internal const string ControlledTaskId = "ControlledTask";
    public static PointTaskID Controlled => new (ControlledTaskId);

    internal const string WrappedActionId = "WrappedAction";
    public static PointTaskID WrappedAction => new (WrappedActionId);


}