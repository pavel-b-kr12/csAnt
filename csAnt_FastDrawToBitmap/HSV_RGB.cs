using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace csAnt_FastDrawToBitmap
{
    static class hsvrgb // 0 - 360 for hue, and 0 - 1 for saturation or value.
    {
        static int h_mod=360;
        static int h_modDiv6=60;
        public static int H_mod { get => h_mod; set { h_mod = value; h_modDiv6 = h_mod / 6; } }
        public static void HToRgb(double h, out byte r, out byte g, out byte b)
        {
            double H = h % h_mod;

            byte R, G, B;

            {
                double hf = H / h_modDiv6; //!!opt replace with *
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                byte qv = (byte)((1.0 - f) * 255);
                byte tv = (byte)( f * 255);

                switch (i)
                {
                    // Red is the dominant color
                    case 0:
                        R = 255;
                        G = tv;
                        B = 0;
                        break;

                    // Green is the dominant color
                    case 1:
                        R = qv;
                        G = 255;
                        B = 0;
                        break;
                    case 2:
                        R = 0;
                        G = 255;
                        B = tv;
                        break;

                    // Blue is the dominant color
                    case 3:
                        R = 0;
                        G = qv;
                        B = 255;
                        break;
                    case 4:
                        R = tv;
                        G = 0;
                        B = 255;
                        break;

                    // Red is the dominant color
                    case 5:
                        R = 255;
                        G = 0;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.
                    case 6:
                        R = 255;
                        G = tv;
                        B = 0;
                        break;
                    case -1:
                        R = 255;
                        G = 0;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.
                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = 255; // Just pretend its black/white
                        break;
                }
            }
            r = R;
            g = G;
            b = B;
        }

        public static void HsvToRgb(double h, double S, double V, out byte r, out byte g, out byte b)
        {
            double H = h;
            //if (H < 0 ) H = (H % 360 + 360);
            // else
            //if( H >= 360) 
            H = H % 360; //2F https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb

            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else
            if (S <= 0)
            { R = G = B = V; }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {
                    // Red is the dominant color
                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color
                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color
                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color
                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.
                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
        }

        /// <summary>
        /// Clamp a value to 0-255
        /// </summary>
        static byte Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return (byte)i;
        }


        //================================================
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
    }

}
