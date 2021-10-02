using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    /// <summary>
    /// класс работы с байтовыми массивами
    /// file format - sedf
    /// </summary>
    static class code
    {
        /// <summary>
        /// перевести байтовый массив в строку
        /// </summary>
        /// <param name="hex">байтовый массив</param>
        /// <returns>строка</returns>
        public static string ToHexString(this byte[] hex)
        {
            if (hex == null) return null;
            if (hex.Length == 0) return string.Empty;

            var s = new StringBuilder();
            foreach (byte b in hex)
            {
                s.Append(b.ToString("x2"));
            }
            return s.ToString();
        }
        /// <summary>
        /// перевести строку в байтовый массив
        /// </summary>
        /// <param name="hex">входная строка</param>
        /// <returns>байтовый массив</returns>
        public static byte[] ToHexBytes(this string hex)
        {
            if (hex == null) return null;
            if (hex.Length == 0) return new byte[0];

            int l = hex.Length / 2;
            var b = new byte[l];
            for (int i = 0; i < l; ++i)
            {
                b[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return b;
        }
        /// <summary>
        /// проверка равны ли байтовые массивы
        /// </summary>
        /// <param name="bytes">первый байтовый массив</param>
        /// <param name="bytesToCompare">второй байтовый массив</param>
        /// <returns>true или false</returns>
        public static bool EqualsTo(this byte[] bytes, byte[] bytesToCompare)
        {
            if (bytes == null && bytesToCompare == null) return true; // ?
            if (bytes == null || bytesToCompare == null) return false;
            if (object.ReferenceEquals(bytes, bytesToCompare)) return true;

            if (bytes.Length != bytesToCompare.Length) return false;

            for (int i = 0; i < bytes.Length; ++i)
            {
                if (bytes[i] != bytesToCompare[i]) return false;
            }
            return true;
        }
    }
}
