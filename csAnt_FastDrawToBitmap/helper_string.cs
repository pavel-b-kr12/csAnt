using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csAnt_FastDrawToBitmap
{
    static class string_helper
    {
        static string[] prefixeSI = { "y", "z", "a", "f", "p", "n", "µ", "m", "", "k", "M", "G", "T", "P", "E", "Z", "Y" };
        public static string numStr(double num)
        {
            int log10 = (int)Math.Log10(Math.Abs(num));
            if (log10 < -27)
                return "0.000";
            if (log10 % -3 < 0)
                log10 -= 3;
            int log1000 = Math.Max(-8, Math.Min(log10 / 3, 8));

            return ((double)num / Math.Pow(10, log1000 * 3)).ToString("###.###" + prefixeSI[log1000 + 8]);
        }
    }
}
