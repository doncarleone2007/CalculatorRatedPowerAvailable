using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CalculatorRatedPowerAvailable.Helper.Encrypts
{
    internal class CommandEncrypter
    {
        private string _firstKey { get; set; }

        private string _secondKey { get; set; }

        private string Key { get; set; }

        public CommandEncrypter(string firstParam, string secondParam)
        {
            this._firstKey = firstParam;
            this._secondKey = secondParam;
            this.GenerateKey();
        }

        private void GenerateKey()
        {
            this.Key = "_!eeT!%" + this._firstKey + "!@eG7e" + this._secondKey + "_o0Gtan#@g#" + this._firstKey + this._secondKey;
        }

        public string EncryptMessage(string message)
        {
            try
            {
                return this.Encrypt(this.Encrypt(message));
            }
            catch
            {
                return "";
            }
        }

        private string Encrypt(string text)
        {
            try
            {
                string str = "";
                byte[] bytes = Encoding.Unicode.GetBytes(text);
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(this.Key, new byte[13]
                    {
            (byte) 73,
            (byte) 118,
            (byte) 97,
            (byte) 110,
            (byte) 32,
            (byte) 77,
            (byte) 101,
            (byte) 100,
            (byte) 118,
            (byte) 101,
            (byte) 100,
            (byte) 101,
            (byte) 118
                    });
                    aes.Key = rfc2898DeriveBytes.GetBytes(32);
                    aes.IV = rfc2898DeriveBytes.GetBytes(16);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(bytes, 0, bytes.Length);
                            cryptoStream.Close();
                        }
                        str = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
                return str;
            }
            catch
            {
                return "";
            }
        }

        public string DecryptMessage(string message)
        {
            try
            {
                return this.Decrypt(this.Decrypt(message));
            }
            catch
            {
                return "";
            }
        }

        private string Decrypt(string text)
        {
            try
            {
                string str = "";
                byte[] buffer = Convert.FromBase64String(text);
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(this.Key, new byte[13]
                    {
            (byte) 73,
            (byte) 118,
            (byte) 97,
            (byte) 110,
            (byte) 32,
            (byte) 77,
            (byte) 101,
            (byte) 100,
            (byte) 118,
            (byte) 101,
            (byte) 100,
            (byte) 101,
            (byte) 118
                    });
                    aes.Key = rfc2898DeriveBytes.GetBytes(32);
                    aes.IV = rfc2898DeriveBytes.GetBytes(16);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(buffer, 0, buffer.Length);
                            cryptoStream.Close();
                        }
                        str = Encoding.Unicode.GetString(memoryStream.ToArray());
                    }
                }
                return str;
            }
            catch
            {
                return "";
            }
        }
    }
}