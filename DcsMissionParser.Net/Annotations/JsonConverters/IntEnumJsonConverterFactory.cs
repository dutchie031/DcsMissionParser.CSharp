using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DcsMissionParser.Net.Annotations.JsonConverters
{
    public sealed class IntEnumJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(IntEnum).IsAssignableFrom(typeToConvert);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(IntEnumJsonConverter<>).MakeGenericType(typeToConvert);
            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }

        private sealed class IntEnumJsonConverter<TIntEnum> : JsonConverter<TIntEnum>
            where TIntEnum : IntEnum
        {
            public override TIntEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if(reader.TokenType == JsonTokenType.Null)
                {
                    return null;
                }

                int rawValue;
                if(reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out var numberValue))
                {
                    rawValue = numberValue;
                }
                else if(reader.TokenType == JsonTokenType.String && int.TryParse(reader.GetString(), out var stringValue))
                {
                    rawValue = stringValue;
                }
                else
                {
                    throw new JsonException($"Expected integer token for {typeToConvert.Name}.");
                }

                if(IntEnum.TryFromValue<TIntEnum>(rawValue.ToString(), out var parsed) && parsed is not null)
                {
                    return parsed;
                }

                throw new JsonException($"Unknown {typeToConvert.Name} value '{rawValue}'.");
            }

            public override void Write(Utf8JsonWriter writer, TIntEnum value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value.Value);
            }
        }
    }
}
