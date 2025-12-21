using DcsMissionParser.CSharp.Annotations;
using System.Reflection;
using System.Text;

namespace DcsMissionParser.CSharp.Parsers
{
    internal static class MissionWriter
    {
        public static async Task<ParseResult<byte[]>> TryWriteAsync(MizObject mizObject)
        {
            StringWriter writer = new StringWriter();
            writer.WriteLine("mission = ");
            WriteObjectAsLuaString(mizObject, writer, 0);
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
                    sw.WriteLineIndent($"[{i}] = ", indentation);
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
                sw.WriteLine($"\"{instance}\",", indentation);
            }
            else if (type.IsClass)
            {
                sw.WriteLineIndent("{", indentation);
                foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (property.GetCustomAttributes(typeof(LuaKeyAttribute), false).FirstOrDefault() is not LuaKeyAttribute attribute)
                        continue;

                    object? value = property.GetValue(instance);

                    sw.WriteIndent($"[\"{attribute.Name}\"] = ", indentation);
                    WriteObjectAsLuaString(value, sw, indentation + 1);
                }
                if (indentation != 0)
                    sw.WriteLineIndent("},", indentation);
                else 
                    sw.WriteLineIndent("}", indentation);
            }
        }
    }
}
