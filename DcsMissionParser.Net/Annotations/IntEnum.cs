using System;
using System.Reflection;

namespace DcsMissionParser.Net.Annotations;

public abstract class IntEnum : IEquatable<IntEnum>
{
    public int Value { get; }

    protected IntEnum(int value)
    {
        Value = value;
    }

    public static T[] GetAll<T>() where T : IntEnum
    {
        return [.. typeof(T)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(f => f.FieldType == typeof(T))
            .Select(f => (T)f.GetValue(null)!)];
    }

    public static T? FromValue<T>(string value) where T : IntEnum
    {
        if (int.TryParse(value, out int intValue))
        {
            return GetAll<T>().FirstOrDefault(item => item.Value == intValue);
        }
        return null;
    }

    public static bool TryFromValue<T>(string value, out T? result) where T : IntEnum
    {
        result = FromValue<T>(value);
        return result != null;
    }
    
    

    public override bool Equals(object? obj) => Equals(obj as IntEnum);
    public bool Equals(IntEnum? other) => other?.Value == Value;
    public override int GetHashCode() =>  HashCode.Combine(Value);

    public static bool operator ==(IntEnum? left, IntEnum? right) => EqualityComparer<IntEnum?>.Default.Equals(left, right);
    
    public static bool operator !=(IntEnum? left, IntEnum? right) => !(left == right);
}
