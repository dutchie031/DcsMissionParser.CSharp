using System;
using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks;


public class PointTaskId : StringEnum
{
    private PointTaskId(string value) : base(value) { }
    public static PointTaskId None => new ("None");

    internal const string ComboTaskId = "ComboTask";
    public static PointTaskId ComboTask => new (ComboTaskId);

    internal const string MissionId = "Mission";  
    public static PointTaskId Mission => new (MissionId);
    
    internal const string ControlledTaskId = "ControlledTask";
    public static PointTaskId Controlled => new (ControlledTaskId);

    internal const string WrappedActionId = "WrappedAction";
    public static PointTaskId WrappedAction => new (WrappedActionId);

    internal const string OptionsId = "Option";
    public static PointTaskId OptionAction => new (OptionsId); 

    

}