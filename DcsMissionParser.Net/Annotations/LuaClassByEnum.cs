using System;
using Lua;

namespace DcsMissionParser.Net.Annotations;


internal interface ILuaClassByEnumAttribute
{
    public Type EnumType { get; }
    public string KeySelection { get; }
    public Enum Value { get; }

    public bool IsMatch(LuaTable table);
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

    public bool IsMatch(LuaTable table)
    {
        string[] keys = KeySelection.Split(".");
        
        for(int i = 0; i < keys.Length; i++)
        {
            string key = keys[i];
            if (i == keys.Length - 1)
            {
                var value = table[key];
                if( value.Type == LuaValueType.String && value.TryRead(out string s))
                {
                    return Enum.TryParse(EnumType, s, true, out var result) && result.Equals(Value);
                }

                if( value.Type == LuaValueType.Number && value.TryRead(out int intVal))
                {
                    return Enum.ToObject(EnumType, intVal).Equals(Value);
                }
            }
            else
            {
                if (table[key].TryRead(out LuaTable nextTable))
                {
                    table = nextTable;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }

}
