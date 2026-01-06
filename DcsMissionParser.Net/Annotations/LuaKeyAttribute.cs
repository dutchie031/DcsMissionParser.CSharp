using System;

namespace DcsMissionParser.Net.Annotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal class LuaKeyAttribute : Attribute
{
    public readonly string Name;
    public LuaKeyAttribute(string name)
    {
        Name = name;
    }
}
