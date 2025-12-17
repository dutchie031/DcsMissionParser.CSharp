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


        public bool Visible { get; set; }
        public string? Name { get; set; }
        public string? LayerName { get; set; }
        public double MapY { get; set; }
        public double MapX { get; set; }
        public bool Closed { get; set; }
        public int Thickness { get; set; }
        public string? Color { get; set; }
        public string? Style { get; set; }
        public string? LineMode { get; set; }
        public List<Vec2> Points { get; set; } = [];



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

    #endregion

    #region Lines
    public abstract class Line : DrawingObject 
    {
        
    }
    #endregion

    #region TextBoxes

    #endregion
}
