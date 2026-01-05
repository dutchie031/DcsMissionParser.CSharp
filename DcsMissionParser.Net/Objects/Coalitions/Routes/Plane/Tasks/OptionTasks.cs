using System;
using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks;

[LuaClassByEnum<OptionTaskId>("id", OptionTaskId.ROE)]
public class SetROETask : OptionTask<ROE>
{
    public SetROETask()
    {
        OptionName = OptionTaskId.ROE;
    }
}

[LuaClassByEnum<OptionTaskId>("id", OptionTaskId.REACTION_ON_THREAT)]
public class SetReactionToThreadTask : OptionTask<ReactionToThreat>
{
    public SetReactionToThreadTask()
    {
        OptionName = OptionTaskId.REACTION_ON_THREAT;
    }
}