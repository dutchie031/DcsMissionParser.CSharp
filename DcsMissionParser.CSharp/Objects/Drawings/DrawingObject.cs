using DcsMissionParser.CSharp.Objects.Commons;
using Lua;

namespace DcsMissionParser.CSharp.Objects.Drawings
{
    public abstract class DrawingObject
    {
        public static DrawingObject? FromLuaTable(LuaTable table) 
        {
            string? primitiveType = table["primitiveType"].Read<string>();
            if (!Enum.TryParse<PrimitiveType>(primitiveType, out var parsedType))
                return null;

            return parsedType switch
            {
                PrimitiveType.Polygon => Polygon.FromLuaTable(table),
                _ => null,
            };
        }

        public required PrimitiveType PrimitiveType { get; set; }

    }

    public enum PrimitiveType
    {
        Unknown,
        Line,
        Polygon,
        TextBox
    }

    #region Polygons

    public enum PolygonMode 
    {
        Circle,
        Free,
        Oval,
        Rect
    }
    public abstract class Polygon : DrawingObject
    {
        public Polygon() 
        {
            PrimitiveType = PrimitiveType.Polygon;
        }

        public static Polygon? FromLuaTable(LuaTable table)
        {
            string? polyMode = table["polygonMode"].Read<string>();
            if (!Enum.TryParse<PolygonMode>(polyMode, out var parsedMode))
                return null;

            return parsedMode switch
            {
                _ => null
            };
        }

        public PolygonMode PolygonMode { get; set; }
    }

    public class Circle : Polygon
    {
        public Circle() : base()
        {
            PolygonMode = PolygonMode.Circle;
        }
    }

    public class Free : Polygon 
    {
        public Free() : base()
        {
            PolygonMode = PolygonMode.Free;
        }
    }

    public class Oval : Polygon 
    {
        public Oval() : base() 
        {
            PolygonMode = PolygonMode.Oval;
        }


    }

    public class Rect : Polygon 
    {
        public Rect() : base() 
        {
            PolygonMode = PolygonMode.Rect;
        }
    }

    #endregion

    #region Lines
    public abstract class Line : DrawingObject 
    {
        
    }
    #endregion

    #region TextBoxes

    #endregion
}
