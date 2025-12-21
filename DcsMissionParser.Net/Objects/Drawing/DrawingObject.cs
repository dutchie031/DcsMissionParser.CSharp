using System.Collections.Generic;
using DcsMissionParser.CSharp.Annotations;
using DcsMissionParser.Net.Objects.Commons;
using Lua;

namespace DcsMissionParser.Net.Objects.Drawing
{
    public abstract class DrawingObject
    {
        [LuaKey("primitiveType")]
        public required PrimitiveType PrimitiveType { get; set; }

        [LuaKey("name")]
        public required string Name { get; set; }

        [LuaKey("visible")]
        public required bool Visible { get; set; }

        [LuaKey("layerName")]
        public required string? LayerName { get; set; }

        [LuaKey("mapX")]
        public required double MapX { get; set; }

        [LuaKey("mapY")]
        public required double MapY { get; set; }

        /// <summary>
        /// Hex ARGB
        /// </summary>
        [LuaKey("colorString")]
        public required string ColorString { get; set; }

        [LuaKey("style")]
        public required string Style { get; set; }

        [LuaKey("thickness")]
        public required double Thickness { get; set; }

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
        Rect,
        Arrow
    }
    
    [LuaClassByEnum<PrimitiveType>("primitiveType", PrimitiveType.Polygon)]
    public abstract class Polygon : DrawingObject
    {
        public Polygon() 
        {
            PrimitiveType = PrimitiveType.Polygon;
        }
        
        [LuaKey("polygonMode")]
        public PolygonMode PolygonMode { get; set; }

        [LuaKey("fillColorString")]
        public string? FillColorString { get; set; }

    }

    [LuaClassByEnum<PolygonMode>("polygonMode", PolygonMode.Circle)]
    public class Circle : Polygon
    {
        public Circle() : base()
        {
            PolygonMode = PolygonMode.Circle;
        }

        [LuaKey("radius")]
        public double Radius { get; set; }
    }

    [LuaClassByEnum<PolygonMode>("polygonMode", PolygonMode.Free)]
    public class Free : Polygon 
    {
        public Free() : base()
        {
            PolygonMode = PolygonMode.Free;
        }

        [LuaKey("points")]
        public List<Vec2> Points { get; set; } = new List<Vec2>();
    }

    [LuaClassByEnum<PolygonMode>("polygonMode", PolygonMode.Oval)]
    public class Oval : Polygon 
    {
        public Oval() : base() 
        {
            PolygonMode = PolygonMode.Oval;
        }

        [LuaKey("r1")]
        public double R1 { get; set; }

        [LuaKey("r2")]
        public double R2 { get; set; }

        [LuaKey("angle")]
        public double? Angle { get; set; }
    }

    [LuaClassByEnum<PolygonMode>("polygonMode", PolygonMode.Rect)]
    public class Rect : Polygon 
    {
        public Rect() : base() 
        {
            PolygonMode = PolygonMode.Rect;
        }

        [LuaKey("width")]
        public double Width { get; set; }

        [LuaKey("height")]
        public double Height { get; set; }

        [LuaKey("angle")]
        public double? Angle { get; set; }
    }

    [LuaClassByEnum<PolygonMode>("polygonMode", PolygonMode.Arrow)]
    public class Arrow : Polygon 
    {
        public Arrow() : base() 
        {
            PolygonMode = PolygonMode.Arrow;
        }

        [LuaKey("length")]
        public double Length { get; set; }

        [LuaKey("angle")]
        public double? Angle { get; set; }
    }

    #endregion

    #region Lines

    public enum LineMode
    {
        Segment,
        Segments,
        Free
    }

    [LuaClassByEnum<PrimitiveType>("primitiveType", PrimitiveType.Line)]
    public abstract class Line : DrawingObject 
    {
        public Line() 
        {
            PrimitiveType = PrimitiveType.Line;
        }

        [LuaKey("lineMode")]
        public LineMode LineMode { get; set; }

        [LuaKey("closed")]
        public required bool Closed { get; set; }

        [LuaKey("points")]
        public List<Vec2> Points { get; set; } = [];

    }

    [LuaClassByEnum<LineMode>("lineMode", LineMode.Segment)]
    public class Segment : Line 
    {
        public Segment() : base() 
        {
            LineMode = LineMode.Segment;
        }
    }

    [LuaClassByEnum<LineMode>("lineMode", LineMode.Segments)]
    public class Segments : Line 
    {
        public Segments() : base() 
        {
            LineMode = LineMode.Segments;
        }
    }

    [LuaClassByEnum<LineMode>("lineMode", LineMode.Free)]
    public class FreeLine : Line 
    {
        public FreeLine() : base() 
        {
            LineMode = LineMode.Free;
        }
    }

    #endregion

    #region TextBoxes


    #endregion
}
