using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace DcsMissionParser.Net.Annotations
{
    /// <summary>
    /// Generic TypeConverter for all StringEnum classes that supports conversion from string values.
    /// Applied via [TypeConverter] attribute on the StringEnum base class to automatically work with all derived types.
    /// </summary>
    public class StringEnumTypeConverter : TypeConverter
    {
        private static MethodInfo? s_fromValueMethod;

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is not string stringValue)
            {
                return base.ConvertFrom(context, culture, value);
            }

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                throw new ArgumentException($"Value cannot be null or whitespace.", nameof(value));
            }

            // Get the target type from the context
            var targetType = context?.PropertyDescriptor?.PropertyType;
            if (targetType == null || !typeof(StringEnum).IsAssignableFrom(targetType))
            {
                return base.ConvertFrom(context, culture, value);
            }

            try
            {
                // Cache the base MethodInfo across all instances (static)
                s_fromValueMethod ??= typeof(StringEnum)
                    .GetMethod(nameof(StringEnum.FromValue), BindingFlags.Public | BindingFlags.Static);

                if (s_fromValueMethod == null)
                {
                    throw new InvalidOperationException("Could not find StringEnum.FromValue method.");
                }

                var genericMethod = s_fromValueMethod.MakeGenericMethod(targetType);
                var result = genericMethod.Invoke(null, new object[] { stringValue });

                if (result == null)
                {
                    throw new NotSupportedException($"Unknown {targetType.Name} value '{stringValue}'.");
                }

                return result;
            }
            catch (TargetInvocationException ex)
            {
                throw new NotSupportedException($"Error converting value '{stringValue}' to {targetType.Name}.", ex.InnerException);
            }
        }

        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is StringEnum stringEnum)
            {
                return stringEnum.Value;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
