using DcsMissionParser.Net;
using DcsMissionParser.Net.Annotations;
using System.Reflection;
using System.Text;

namespace DcsMissionParser.Net.Parsers
{
    internal static class MissionWriter
    {
        public static async Task<ParseResult<byte[]>> TryWriteAsync(DcsMission mizObject)
        {
            StringWriter writer = new StringWriter();
            writer.WriteLine("mission = ");
            WriteObjectAsLuaString(mizObject, writer, 1);
            return ParseResult<byte[]>.Ok(Encoding.UTF8.GetBytes(writer.ToString()));
        }

        private static bool IsList(this Type target)
        {
            return target.IsGenericType && target.GetGenericTypeDefinition() == typeof(List<>);
        }

        private static void WriteLineIndent(this StringWriter sw, string text, int indentation)
        {
            for (int i = 0; i < indentation; i++)
                sw.Write("\t");
            sw.WriteLine(text);
        }

        private static void WriteIndent(this StringWriter sw, string text, int indentation)
        {
            for (int i = 0; i < indentation; i++)
                sw.Write("\t");
            sw.Write(text);
        }

        /// <summary>
        /// Escapes special characters in a string for Lua string literals.
        /// Handles all escape sequences defined in Lua 5.1 specification (§2.1).
        /// </summary>
        private static string EscapeLuaString(string str)
        {
            if (str == null)
                return string.Empty;

            return str
                .Replace("\\", "\\\\")  // MUST BE FIRST to avoid double-escaping!
                .Replace("\"", "\\\"")  // Double quote
                .Replace("\n", "\\n")   // Newline
                .Replace("\r", "\\r")   // Carriage return
                .Replace("\t", "\\t")   // Tab
                .Replace("\a", "\\a")   // Bell
                .Replace("\b", "\\b")   // Backspace
                .Replace("\f", "\\f")   // Form feed
                .Replace("\v", "\\v")   // Vertical tab
                .Replace("\0", "\\0");  // Null
        }

        private static void WriteObjectAsLuaString(object? instance, StringWriter sw, int indentation = 0, AsStringAttribute? asStringAttribute = null)
        {
            if (instance == null)
            {
                sw.WriteLine(" nil, \n");
                return;
            }

            Type type = instance.GetType();
            if (IsList(type))
            {
                List<object>? objects = (instance as System.Collections.IEnumerable)?.Cast<object>().ToList();
                if (objects == null)
                    return;

                sw.WriteLine("{");
                int i = 1;
                foreach (object? obj in objects)
                {
                    sw.WriteIndent($"[{i}] = ", indentation);
                    WriteObjectAsLuaString(obj, sw, indentation + 1);
                    i++;
                }
                sw.WriteLineIndent("},", indentation);
            }
            else if (type.IsPrimitive)
            {
                if (type == typeof(bool))
                    sw.WriteLine($"{instance.ToString()?.ToLower()},");
                else
                    sw.WriteLine($"{instance},");
            }
            else if (type == typeof(string))
            {
                sw.WriteLine($"\"{EscapeLuaString((string)instance)}\",");
            }
            else if (type.IsEnum)
            {
                if (asStringAttribute != null && asStringAttribute.ToLower)
                    sw.WriteLine($"\"{EscapeLuaString(instance.ToString()?.ToLower() ?? "")}\",");
                else if (asStringAttribute != null)
                    sw.WriteLine($"\"{EscapeLuaString(instance.ToString() ?? "")}\",");
                else
                    sw.WriteLine($"{(int)instance},");
            }
            else if (typeof(IntEnum).IsAssignableFrom(type))
            {
                IntEnum intEnum = (IntEnum)instance;
                sw.WriteLine($"{intEnum.Value},");
            }
            else if (typeof(StringEnum).IsAssignableFrom(type))
            {
                StringEnum stringEnum = (StringEnum)instance;
                sw.WriteLine($"\"{EscapeLuaString(stringEnum.Value)}\",");
            }
            else if (type.IsClass)
            {
                sw.WriteLine();
                sw.WriteLineIndent("{", indentation - 1);
                foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (property.GetCustomAttributes(typeof(LuaKeyAttribute), false).FirstOrDefault() is not LuaKeyAttribute attribute)
                        continue;

                    AsStringAttribute? localAsStringAttribute = null;
                    if (property.PropertyType.IsEnum)
                        localAsStringAttribute = property.GetCustomAttribute<AsStringAttribute>();

                    object? value = property.GetValue(instance);

                    sw.WriteIndent($"[\"{EscapeLuaString(attribute.Name)}\"] = ", indentation);
                    WriteObjectAsLuaString(value, sw, indentation + 1, asStringAttribute: localAsStringAttribute);
                }
                if (indentation != 1)
                    sw.WriteLineIndent("},", indentation - 1);
                else
                    sw.WriteLineIndent("}", indentation - 1);
            }
        }
    }
}
