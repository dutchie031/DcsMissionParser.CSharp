using System;

namespace DcsMissionParser.Net.Annotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class AsStringAttribute : Attribute
{
    public AsStringAttribute() { }
}
