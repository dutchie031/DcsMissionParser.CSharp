using DcsMissionParser.Net;
using DcsMissionParser.Net.Annotations;
using System.Reflection;
using System.Text;

namespace DcsMissionParser.Net.Parsers
{
    internal static class MissionWriter
    {
        public static async Task<ParseResult<byte[]>> TryWriteAsync(MizObject mizObject)
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

        private static void WriteObjectAsLuaString(object? instance, StringWriter sw, int indentation = 0) 
        {
            if (instance == null) 
            {
               sw.WriteLine(" nil, \n");
                return;
            }

            Type type = instance.GetType();
            if (IsList(type))
            {
                List<object>? objects = (instance as IEnumerable<object>)?.Cast<object>().ToList();
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
                sw.WriteLine($"\"{instance}\",");
            }
            else if (type.IsEnum) 
            {
                sw.WriteLine($"{(int)instance},", indentation);
            }
            else if(typeof(IntEnum).IsAssignableFrom(type))
            {
                IntEnum intEnum = (IntEnum)instance;
                sw.WriteLine($"{intEnum.Value},", indentation);
            }
            else if(typeof(StringEnum).IsAssignableFrom(type))
            {
                StringEnum stringEnum = (StringEnum)instance;
                sw.WriteLine($"\"{stringEnum.Value}\",", indentation);
            }
            else if (type.IsClass)
            {
                sw.WriteLine();
                sw.WriteLineIndent("{", indentation - 1);
                foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (property.GetCustomAttributes(typeof(LuaKeyAttribute), false).FirstOrDefault() is not LuaKeyAttribute attribute)
                        continue;

                    object? value = property.GetValue(instance);

                    sw.WriteIndent($"[\"{attribute.Name}\"] = ", indentation);
                    WriteObjectAsLuaString(value, sw, indentation + 1);
                }
                if (indentation != 1)
                    sw.WriteLineIndent("},", indentation -1);
                else 
                    sw.WriteLineIndent("}", indentation  -1);
            }
        }
    }
}
