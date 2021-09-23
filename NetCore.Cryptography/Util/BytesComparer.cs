using System;
using System.Threading.Tasks;

namespace NetCore.Cryptography.Util
{
    public class BytesComparer
    {
        public static bool Compare(byte[] first, byte[] second)
        {
            var result = first.Length == second.Length;

            for(var i = 0; i < first.Length && i < second.Length; ++i)
            {
                result &= first[i] == second[i];
            }

            return result;
        }
    }
}
