using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryClock.Converters
{
    public static class IntegerToBooleanArrayConverter
    {
        public static bool[] ConvertToBools(int value, int length)
        {
            List<bool> boolList = new List<bool>();
            for(int i = 0; i < length; ++i)
            {
                var result = ((value >> i) & 1) == 1;
                boolList.Insert(0, result);
            }
            return boolList.ToArray();
        }
    }
}
