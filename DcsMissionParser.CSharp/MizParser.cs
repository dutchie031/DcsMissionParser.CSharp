using System.Collections;
using System.IO.Compression;
using System.Reflection;
using DcsMissionParser.CSharp.Annotations;
using Lua;

namespace DcsMissionParser.CSharp
{
    public class ParseResult
    {
        public bool Success { get; private set; }
        public string FailureReason { get; set; } = string.Empty;

        public MizObject? MizObject { get; set; } = null;

        private ParseResult() { }

        public static ParseResult Ok(MizObject mizObject)
        {
            return new ParseResult
            {
                Success = true,
                MizObject = mizObject
            };
        }
        public static ParseResult Fail(string reason)
        {
            return new ParseResult
            {
                Success = false,
                FailureReason = reason
            };
        }

    }

    public static class MizParser
    {
        public static async Task<ParseResult> TryParse(byte[] mizBytes) 
        {
            if(!GetMissionFile(mizBytes, out byte[] missionBytes, out string failureReason)) 
            {
                return ParseResult.Fail(failureReason);
            }

            LuaTable missionTable = await ParseMissionFile(missionBytes);
            MizObject? mizObject = (MizObject?) ParseTable(missionTable, typeof(MizObject));
            if (mizObject != null)
                return ParseResult.Ok(mizObject);
            return ParseResult.Fail("Could not parse mission");
        }

        private static bool IsList(this Type target)
        {
            return target.IsGenericType && target.GetGenericTypeDefinition() == typeof(List<>);
        }

        private static object? ParseTable(LuaTable table, Type target) 
        {
            if(target.IsList())
            {
                IList? listInstance = (IList?)Activator.CreateInstance(target);
                if (listInstance == null)
                    return null;

                Type child = target.GetGenericArguments().Single();
                foreach(var item in table)
                {
                    if (item.Value.TryRead(out LuaTable childItem))
                    {
                        object? parsed = ParseTable(childItem, child);
                        listInstance.Add(parsed);
                    }
                    //TODO: else it's a table of items, which isn't needed right now. 
                }
                return listInstance;
            }
            else if (target.IsClass)
            {
                object? instance = Activator.CreateInstance(target);
                if (instance == null)
                    return null;
                    
                foreach(var property in target.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (property.GetCustomAttributes(typeof(LuaKeyAttribute), false).FirstOrDefault() is not LuaKeyAttribute attribute)
                        continue;

                    string luaKey = attribute.Name;
                    Type propertyType = property.PropertyType;
                    if(propertyType.IsPrimitive)
                    {
                        if (propertyType == typeof(int))
                        {
                            if(table[luaKey].TryRead(out int s))
                                property.SetValue(instance, s);
                        }
                        else if(propertyType == typeof(double))
                        {
                            if(table[luaKey].TryRead(out double s))
                                property.SetValue(instance, s);
                        } 
                        else if(propertyType == typeof(bool))
                        {
                            if(table[luaKey].TryRead(out bool s))
                                property.SetValue(instance, s);
                        }
                    } 
                    if(propertyType == typeof(string))
                    {
                        if(table[luaKey].TryRead(out string s))
                            property.SetValue(instance, s);
                    } 
                    else if (propertyType.IsClass || propertyType.IsList())
                    {
                        if(table[luaKey].TryRead(out LuaTable childTable))
                            property.SetValue(instance, ParseTable(childTable, propertyType));
                    }else
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
