using System;
using DcsMissionParser.Net.Objects.Commons;

namespace DcsMissionParser.Net.Annotations;

public interface ILuaClassByStringValue 
{
    public string KeySelection { get; }
    public string Value { get; }

}

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class LuaClassByStringValue : Attribute, ILuaClassByStringValue
{
    public string KeySelection { get; }

    public string Value { get; }

    public LuaClassByStringValue (string key, string value)
    {
        Value = value;
        KeySelection = key;
    }

}
