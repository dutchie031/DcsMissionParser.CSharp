using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DcsMissionParser.Net.Annotations.JsonConverters
{
    public sealed class StringEnumJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(StringEnum).IsAssignableFrom(typeToConvert);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(StringEnumJsonConverter<>).MakeGenericType(typeToConvert);
            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }

        private sealed class StringEnumJsonConverter<TStringEnum> : JsonConverter<TStringEnum>
            where TStringEnum : StringEnum
        {
            public override TStringEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if(reader.TokenType == JsonTokenType.Null)
                {
                    return null;
                }

                if(reader.TokenType != JsonTokenType.String)
                {
                    throw new JsonException($"Expected string token for {typeToConvert.Name}.");
                }

                var rawValue = reader.GetString();
                if(string.IsNullOrWhiteSpace(rawValue))
                {
                    throw new JsonException($"Value for {typeToConvert.Name} cannot be null or whitespace.");
                }

                if(StringEnum.TryFromValue<TStringEnum>(rawValue, out var parsed) && parsed is not null)
                {
                    return parsed;
                }

                throw new JsonException($"Unknown {typeToConvert.Name} value '{rawValue}'.");
            }

            public override void Write(Utf8JsonWriter writer, TStringEnum value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.Value);
            }
        }
    }
}
