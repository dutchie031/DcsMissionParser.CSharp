using System;

namespace DcsMissionParser.Net.Annotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class AsStringAttribute : Attribute
{
    public bool ToLower { get; } = false;

    public AsStringAttribute(bool lower = false)
    {
        ToLower = lower;
    }

}
