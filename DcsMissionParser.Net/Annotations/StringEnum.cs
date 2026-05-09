using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DcsMissionParser.Net.Annotations
{
    public abstract class StringEnum : IEquatable<StringEnum>
    {
        public string Value { get; }

        protected StringEnum(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static T[] GetAll<T>() where T : StringEnum
        {
            return [.. typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(T))
                .Select(f => (T)f.GetValue(null)!)];
        }

        public static T? FromValue<T>(string value) where T : StringEnum
        {
            return GetAll<T>().FirstOrDefault(item => item.Value.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        public static bool TryFromValue<T>(string value, out T? result) where T : StringEnum
        {
            result = FromValue<T>(value);
            return result != null;
        }

        public override string ToString() => Value;
        public override bool Equals(object? obj) => Equals(obj as StringEnum);
        public bool Equals(StringEnum? other) => other?.Value == Value;
        public override int GetHashCode() => Value.GetHashCode();
        
        public static bool operator ==(StringEnum? left, StringEnum? right) => 
            ReferenceEquals(left, right) || (left?.Equals(right) ?? false);
        public static bool operator !=(StringEnum? left, StringEnum? right) => !(left == right);
    }
}