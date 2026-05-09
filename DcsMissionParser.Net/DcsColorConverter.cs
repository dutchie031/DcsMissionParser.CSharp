using System;
using System.Drawing;

namespace DcsMissionParser.Net;

public class DcsColorConverter
{
    public string ToStringColor(int a, int r, int g, int b)
    {
        if (a < 0 || a > 255) throw new ArgumentOutOfRangeException(nameof(a));
        if (r < 0 || r > 255) throw new ArgumentOutOfRangeException(nameof(r));
        if (g < 0 || g > 255) throw new ArgumentOutOfRangeException(nameof(g));
        if (b < 0 || b > 255) throw new ArgumentOutOfRangeException(nameof(b));

        return $"0x{r:X2}{g:X2}{b:X2}{a:X2}";
    }

    public string ToStringColor(int r, int g, int b)
    {
        return ToStringColor(255, r, g, b);
    }

    public string ToStringColor(Color color)
    {
        return ToStringColor(color.A, color.R, color.G, color.B);
    }


}
