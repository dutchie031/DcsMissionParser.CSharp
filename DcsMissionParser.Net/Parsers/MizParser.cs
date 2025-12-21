using System.Collections;
using System.IO.Compression;
using System.Reflection;
using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.Net;
using Lua;

namespace DcsMissionParser.Net.Parsers
{

    internal static class MizParser
    {
        public static async Task<ParseResult<MizObject>> TryParse(byte[] mizBytes) 
        {
            if(!GetMissionFile(mizBytes, out byte[] missionBytes, out string failureReason)) 
            {
                return ParseResult<MizObject>.Fail(failureReason);
            }

            LuaTable missionTable = await ParseMissionFile(missionBytes);
            MizObject? mizObject = (MizObject?) ParseTable(missionTable, typeof(MizObject));
            if (mizObject != null)
                return ParseResult<MizObject>.Ok(mizObject);
            return ParseResult<MizObject>.Fail("Could not parse mission");
        }

        private static bool IsList(this Type target)
        {
            return target.IsGenericType && target.GetGenericTypeDefinition() == typeof(List<>);
        }

        private static object? ParseTable(LuaTable table, Type target) 
        {
            if (target.IsList())
            {
                IList? listInstance = (IList?)Activator.CreateInstance(target);
                if (listInstance == null)
                    return null;

                Type child = target.GetGenericArguments().Single();
                foreach (var item in table)
                {
                    if (item.Value.TryRead(out LuaTable childItem))
                    {
                        object? parsed = ParseTable(childItem, child);
                        if (parsed != null)
                            listInstance.Add(parsed);
                    }
                    //TODO: else it's a table of items, which isn't needed right now. 
                }
                return listInstance;
            }
            else if (target.IsGenericType && target.GetGenericTypeDefinition() == typeof(Dictionary<,>)) 
            {
                Type keyType = target.GetGenericArguments()[0];
                Type valueType = target.GetGenericArguments()[1];
                
                Type newDictType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
                IDictionary? dictInstance = (IDictionary?) Activator.CreateInstance(newDictType);
                if (dictInstance == null)
                    return null;

                foreach (var item in table) 
                {
                    if (!item.Key.TryRead(out object keyObj))
                        continue;

                    object? valueObj = null;
                    if (valueType.IsClass)
                    {
                        if (!item.Value.TryRead(out LuaTable valueTable))
                            continue;

                        valueObj = ParseTable(valueTable, valueType);
                    }
                    else if (valueType == typeof(string))
                    {
                        if (!item.Value.TryRead(out string valueStr))
                            continue;

                        valueObj = valueStr;
                    }
                    else if (valueType == typeof(int))
                    {
                        if (!item.Value.TryRead(out int valueInt))
                            continue;
                        valueObj = valueInt;
                    }
                    else if (valueType == typeof(double))
                    {
                        if (!item.Value.TryRead(out double valueDouble))
                            continue;
                        valueObj = valueDouble;
                    }
                    else if (valueType == typeof(bool))
                    {
                        if (!item.Value.TryRead(out bool valueBool))
                            continue;
                        valueObj = valueBool;
                    } else 
                    {
                        valueObj = null;
                    }

                    dictInstance.Add(keyObj, valueObj);
                }
                return dictInstance;
            }
            else if (target.IsClass && target.IsAbstract)
            {
                IEnumerable<Type> subClasses = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == target);

                foreach (var subclass in subClasses)
                {
                    if (subclass.GetCustomAttributes(typeof(LuaClassByEnumAttribute<>)).FirstOrDefault() is ILuaClassByEnumAttribute enumAttribute)
                    {
                        string key = enumAttribute.KeySelection;
                        if (table[key].TryRead(out string s))
                        {
                            object val = Enum.Parse(enumAttribute.EnumType, s, true);
                            if (val.Equals(enumAttribute.Value))
                            {
                                return ParseTable(table, subclass);
                            }
                        }
                    }
                }
            }
            else if (target.IsClass)
            {
                object? instance = Activator.CreateInstance(target);
                if (instance == null)
                    return null;

                foreach (var property in target.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (property.GetCustomAttributes(typeof(LuaKeyAttribute), false).FirstOrDefault() is not LuaKeyAttribute attribute)
                        continue;

                    string luaKey = attribute.Name;
                    Type propertyType = property.PropertyType;
                    if (propertyType.IsPrimitive)
                    {
                        if (propertyType == typeof(int))
                        {
                            if (table[luaKey].TryRead(out int s))
                                property.SetValue(instance, s);
                        }
                        else if (propertyType == typeof(double))
                        {
                            if (table[luaKey].TryRead(out double s))
                                property.SetValue(instance, s);
                        }
                        else if (propertyType == typeof(bool))
                        {
                            if (table[luaKey].TryRead(out bool s))
                                property.SetValue(instance, s);
                        }
                    }
                    if (propertyType == typeof(string))
                    {
                        if (table[luaKey].TryRead(out string s))
                            property.SetValue(instance, s);
                    }
                    else if (propertyType.IsClass || propertyType.IsList())
                    {
                        if (table[luaKey].TryRead(out LuaTable childTable))
                            property.SetValue(instance, ParseTable(childTable, propertyType));
                    }
                    else
                    {

                    }
                }
                return instance;
            }


            return null;
        }

        private static async Task<LuaTable> ParseMissionFile(byte[] mizBytes) 
        {

            var state = LuaState.Create();
            await state.DoStringAsync(System.Text.Encoding.UTF8.GetString(mizBytes));
            LuaTable table = state.Environment["mission"].Read<LuaTable>();

            return table;
        }


        private static bool GetMissionFile(byte[] miz, out byte[] mission, out string failureReason)
        {
            using ZipArchive archive = new ZipArchive(new MemoryStream(miz), ZipArchiveMode.Read);
            ZipArchiveEntry? missionEntry = archive.GetEntry("mission");
            if (missionEntry == null)
            {
                failureReason = "The .miz file does not contain a mission file";
                mission = [];
                return false;
            }

            using Stream missionStream = missionEntry.Open();
            using MemoryStream ms = new MemoryStream();
            missionStream.CopyTo(ms);
            mission = ms.ToArray();
            failureReason = string.Empty;
            return true;
        }

    }
}
