using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxmarkUI
{
    public static class HexHelper
    {
        public static void FillArrayFromString(string hex, ref byte[] arr, int start = 0)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");
            hex = hex.ToUpper();
            int j = start;
            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                if (j >= arr.Length)
                    return;
                arr[j] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
                j++;
            }
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            //return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
        public static string ByteArrayToString(ref byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
