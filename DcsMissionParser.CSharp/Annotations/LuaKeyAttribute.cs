using System;

namespace DcsMissionParser.CSharp.Annotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class LuaKeyAttribute : Attribute
{
    public readonly string Name;
    public LuaKeyAttribute(string name)
    {
        Name = name;
    }
}
