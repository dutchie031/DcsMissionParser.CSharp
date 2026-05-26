using System;
using System.Drawing;

namespace DcsMissionParser.Net;

public class DcsColorConverter
{
    public static string ToStringColor(int a, int r, int g, int b)
    {
        if (a < 0 || a > 255) throw new ArgumentOutOfRangeException(nameof(a));
        if (r < 0 || r > 255) throw new ArgumentOutOfRangeException(nameof(r));
        if (g < 0 || g > 255) throw new ArgumentOutOfRangeException(nameof(g));
        if (b < 0 || b > 255) throw new ArgumentOutOfRangeException(nameof(b));

        return $"0x{r:X2}{g:X2}{b:X2}{a:X2}";
    }

    public static string ToStringColor(int r, int g, int b)
    {
        return ToStringColor(255, r, g, b);
    }

    public static string ToStringColor(Color color)
    {
        return ToStringColor(color.A, color.R, color.G, color.B);
    }
    
    public static Color FromDcsStringColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
        throw new ArgumentException("Color string cannot be null or empty", nameof(color));
    
        if (!color.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Color string must start with '0x'", nameof(color));
        
        // Remove "0x" prefix
        string hex = color.Substring(2);
        
        if (hex.Length != 8)
            throw new ArgumentException("Color string must be in format 0xRRGGBBAA", nameof(color));
        
        int r = Convert.ToInt32(hex.Substring(0, 2), 16);
        int g = Convert.ToInt32(hex.Substring(2, 2), 16);
        int b = Convert.ToInt32(hex.Substring(4, 2), 16);
        int a = Convert.ToInt32(hex.Substring(6, 2), 16);
        
        return Color.FromArgb(a, r, g, b);
    }

    public static bool TryFromDcsStringColor(string color, out Color result)
    {
        result = default;
        
        if (string.IsNullOrWhiteSpace(color))
            return false;
    
        if (!color.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            return false;
        
        // Remove "0x" prefix
        string hex = color.Substring(2);
        
        if (hex.Length != 8)
            return false;
        
        int r = Convert.ToInt32(hex.Substring(0, 2), 16);
        int g = Convert.ToInt32(hex.Substring(2, 2), 16);
        int b = Convert.ToInt32(hex.Substring(4, 2), 16);
        int a = Convert.ToInt32(hex.Substring(6, 2), 16);
        
        result =  Color.FromArgb(a, r, g, b);
        return true;
    }
}
