using System;

namespace DcsMissionParser.CSharp.Annotations;


internal interface ILuaClassByEnumAttribute
{
    public Type EnumType { get; }
    public string KeySelection { get; }
    public Enum Value { get; }
}

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal class LuaClassByEnumAttribute<T> : Attribute, ILuaClassByEnumAttribute where T : Enum
{
    public Type EnumType { get; private set; }
    public string KeySelection { get; private set; }
    public Enum Value { get; private set; }

    public LuaClassByEnumAttribute(string keySelection, T value)
    {
        EnumType = typeof(T);
        Value = value;
        KeySelection = keySelection;
    }

}
