using System;

namespace DcsMissionParser.CSharp.Annotations;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class LuaClassByEnum<T> : Attribute
{
    public readonly T Value;
    public readonly string KeySelection;

    public LuaClassByEnum(T value, string keySelection)
    {
        Value = value;
        KeySelection = keySelection;
    }

}
