using System.Collections;
using System.IO.Compression;
using System.Reflection;
using DcsMissionParser.Net;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Commons;
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
            var parseResult = ParseTable(missionTable, typeof(MizObject));
            if (parseResult.Success && parseResult.Result is MizObject mizObject)
                return ParseResult<MizObject>.Ok(mizObject);
            return ParseResult<MizObject>.Fail(parseResult.FailureReason);
        }

        private static bool IsList(this Type target)
        {
            return target.IsGenericType && target.GetGenericTypeDefinition() == typeof(List<>);
        }

        private static bool IsDict(this Type target)
        {
            return target.IsGenericType && target.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }

        private static ParseResult<object> ParseTable(LuaTable table, Type target) 
        {
            return target switch
            {
                _ when target.IsList() => ParseList(table, target),
                _ when target.IsDict() => ParseDictionary(table, target),
                _ when target.IsAbstract => ParseAbstractClass(table, target),
                _ when target.IsClass => ParseClass(table, target),
                _ => ParseResult<object>.Fail($"Unsupported type: {target.Name}")
            };
        }

        private static ParseResult<object> ParseList(LuaTable table, Type listType) 
        {
            IList? listInstance = (IList?)Activator.CreateInstance(listType);
            if (listInstance == null)
                return ParseResult<object>.Fail("Failed to create list instance");

            Type child = listType.GetGenericArguments().Single();
            foreach (var item in table)
            {
                if (item.Value.TryRead(out LuaTable childItem))
                {
                    var parseResult = ParseTable(childItem, child);
                    if (parseResult.Success && parseResult.Result != null)
                        listInstance.Add(parseResult.Result);
                }
                //TODO: else it's a table of items, which isn't needed right now. 
            }
            return ParseResult<object>.Ok(listInstance);
        }

        private static ParseResult<object> ParseDictionary(LuaTable table, Type dictType) 
        {
            Type keyType = dictType.GetGenericArguments()[0];
            Type valueType = dictType.GetGenericArguments()[1];
            
            Type newDictType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
            IDictionary? dictInstance = (IDictionary?) Activator.CreateInstance(newDictType);
            if (dictInstance == null)
                return ParseResult<object>.Fail("Failed to create dictionary instance");

            foreach (var item in table) 
            {
                if (!item.Key.TryRead(out object keyObj))
                    continue;

                object? valueObj = null;
                if(typeof(StringEnum).IsAssignableFrom(valueType))
                {
                    if (!item.Value.TryRead(out string valueStr))
                        continue;
                    
                    // Use reflection to call StringEnum.FromValue<T>(string)
                    var fromValueMethod = typeof(StringEnum).GetMethod(nameof(StringEnum.FromValue))!.MakeGenericMethod(valueType);
                    valueObj = fromValueMethod.Invoke(null, new object[] { valueStr });
                }
                else if(typeof(IntEnum).IsAssignableFrom(valueType))
                {
                    if (!item.Value.TryRead(out int valueInt))
                        continue;
                    
                    // Use reflection to call IntEnum.FromValue<T>(int)
                    var fromValueMethod = typeof(IntEnum).GetMethod(nameof(IntEnum.FromValue))!.MakeGenericMethod(valueType);
                    valueObj = fromValueMethod.Invoke(null, new object[] { valueInt });
                }
                else if (valueType.IsClass)
                {
                    if (!item.Value.TryRead(out LuaTable valueTable))
                        continue;

                    var valueResult = ParseTable(valueTable, valueType);
                    if (valueResult.Success)
                        valueObj = valueResult.Result;
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
            return ParseResult<object>.Ok(dictInstance);
        }

        private static ParseResult<object> ParseClass(LuaTable table, Type classType) 
        {
            object? instance = Activator.CreateInstance(classType);
            if (instance == null)
                return ParseResult<object>.Fail("Failed to create class instance");

            foreach (var property in classType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
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
                else if (propertyType == typeof(string))
                {
                    if (table[luaKey].TryRead(out string s))
                        property.SetValue(instance, s);
                }
                else if(propertyType.IsEnum)
                {
                    if(table[luaKey].Type == LuaValueType.String && table[luaKey].TryRead(out string enumStr))
                    {
                        if (Enum.TryParse(propertyType, enumStr, true, out var enumVal))
                        {
                            property.SetValue(instance, enumVal);
                        }
                    }
                    else if(table[luaKey].Type == LuaValueType.Number && table[luaKey].TryRead(out int enumInt))
                    {
                        var enumVal = Enum.ToObject(propertyType, enumInt);
                        property.SetValue(instance, enumVal);
                    }
                }
                else if(typeof(StringEnum).IsAssignableFrom(propertyType))
                {
                    if (!table[luaKey].TryRead(out string valueStr))
                        continue;
                    
                    // Use reflection to call StringEnum.FromValue<T>(string)
                    var fromValueMethod = typeof(StringEnum).GetMethod(nameof(StringEnum.FromValue))!.MakeGenericMethod(propertyType);
                    var parsedEnum = fromValueMethod.Invoke(null, new object[] { valueStr });
                    property.SetValue(instance, parsedEnum);
                }
                else if(typeof(IntEnum).IsAssignableFrom(propertyType))
                {
                    if (!table[luaKey].TryRead(out int valueInt))
                        continue;
                    
                    // Use reflection to call IntEnum.FromValue<T>(int)
                    var fromValueMethod = typeof(IntEnum).GetMethod(nameof(IntEnum.FromValue))!.MakeGenericMethod(propertyType);
                    var parsedEnum = fromValueMethod.Invoke(null, new object[] { valueInt });
                    property.SetValue(instance, parsedEnum);
                }
                else if (propertyType.IsClass || propertyType.IsList())
                {
                    if (table[luaKey].TryRead(out LuaTable childTable))
                    {
                        var childResult = ParseTable(childTable, propertyType);
                        if (childResult.Success)
                            property.SetValue(instance, childResult.Result);
                    }
                }
                else
                {

                }
            }
            return ParseResult<object>.Ok(instance);
        }

        private static ParseResult<object> ParseAbstractClass(LuaTable table, Type abstractType) 
        {
            IEnumerable<Type> subClasses = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => {
                if (abstractType.IsAssignableFrom(t))
                    return true;
                
                // Handle generic types: check if base type is generic and matches the generic definition
                if (abstractType.IsGenericType && t.BaseType?.IsGenericType == true)
                {
                    return t.BaseType.GetGenericTypeDefinition() == abstractType.GetGenericTypeDefinition();
                }

                return false;
            });

            foreach (var subclass in subClasses)
            {
                if (subclass.GetCustomAttributes(typeof(LuaClassByEnumAttribute<>)).FirstOrDefault() is ILuaClassByEnumAttribute enumAttribute)
                {
                    if (enumAttribute.IsMatch(table))
                    {
                        return ParseTable(table, subclass);
                    }
                } else if (subclass.GetCustomAttributes(typeof(LuaClassByStringValue)).FirstOrDefault() is ILuaClassByStringValue luaClassByStringValue)
                {
                    string key = luaClassByStringValue.KeySelection;
                    if (table[key].TryRead(out string val))
                    {
                        if (val.Equals(luaClassByStringValue.Value))
                        {
                            return ParseTable(table, subclass);
                        }
                    }
                }
            }

            return ParseResult<object>.Fail($"No suitable subclass found for {abstractType.Name}");
        }

        private static ParseResult<object> ParseValue(LuaValue value, Type targetType) 
        {
            if (targetType == typeof(string))
            {
                if (value.TryRead(out string s))
                    return ParseResult<object>.Ok(s);
            }
            else if (targetType == typeof(int))
            {
                if (value.TryRead(out int i))
                    return ParseResult<object>.Ok(i);
            }
            else if (targetType == typeof(double))
            {
                if (value.TryRead(out double d))
                    return ParseResult<object>.Ok(d);
            }
            else if (targetType == typeof(bool))
            {
                if (value.TryRead(out bool b))
                    return ParseResult<object>.Ok(b);
            }

            return ParseResult<object>.Fail($"Unsupported value type: {targetType.Name}");
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
