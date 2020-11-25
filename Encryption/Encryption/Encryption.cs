using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    /// <summary>
    /// класс кодировки
    /// </summary>
    class Encryption
    {
        private static string alphabet = "ABC#$%^&*()_- =QWER{}OMN>FGabcdefghijklmnopqrstuvwxyz0123456789";
        private static string key = "capybara";
        private static string default_key = "capybara";
        Dictionary<char, int> alph = new Dictionary<char, int>();
        Dictionary<int, char> alph_r = new Dictionary<int, char>();

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Alphabet">используемый алфавит</param>
        public Encryption()
        {
            int i = 0;
            foreach (char c in alphabet)
            {
                alph.Add(c, i);
                alph_r.Add(i++, c);
            }
        }

        /// <summary>
        /// Метод кодирования
        /// Желательно, чтобы длина алфавита была степень двойки (например 32)
        /// </summary>
        public string Crypt(string Text)
        {
            if (Form1.new_key_for_crypt.Length > 3)
            {
                Encryption.key = Form1.new_key_for_crypt;
            }
            else
            {
                Encryption.key = Encryption.default_key;
            }
            char[] message = Text.ToCharArray();

            char[] result = new char[message.Length];
            for (int i = 0, j = 0; i < message.Length; i++, j = (j + 1) % Encryption.key.Length)
            {
                result[i] = (char)(message[i] ^ Encryption.key[j]);
            }
            return string.Join("", result);
               
        }

        public string DeCrypt(string Text)
        {
            if (Form1.new_key_for_decrypt.Length > 3)
            {
                Encryption.key = Form1.new_key_for_decrypt;
            }
            else
            {
                Encryption.key = Encryption.default_key;
            }
            char[] message = Text.ToCharArray();

            char[] result = new char[message.Length];
            for (int i = 0, j = 0; i < message.Length; i++, j = (j + 1) % Encryption.key.Length)
            {
                result[i] = (char)(message[i] ^ Encryption.key[j]);
            }
            return string.Join("", result);
        }

        public string Crypt_for_online(string Text, string key)
        {
            Encryption.key = key;
            char[] message = Text.ToCharArray();

            char[] result = new char[message.Length];
            for (int i = 0, j = 0; i < message.Length; i++, j = (j + 1) % Encryption.key.Length)
            {
                result[i] = (char)(message[i] ^ Encryption.key[j]);
            }
            Encryption.key = Encryption.default_key;
            return string.Join("", result);
        }
        public string DeCrypt_for_online(string Text, string key)
        {
            Encryption.key = key;
            char[] message = Text.ToCharArray();

            char[] result = new char[message.Length];
            for (int i = 0, j = 0; i < message.Length; i++, j = (j + 1) % Encryption.key.Length)
            {
                result[i] = (char)(message[i] ^ Encryption.key[j]);
            }
            Encryption.key = Encryption.default_key;
            return string.Join("", result);
        }
    }
}

