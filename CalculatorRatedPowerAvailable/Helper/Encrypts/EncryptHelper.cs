using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorRatedPowerAvailable.Helper.Encrypts
{
    public static class EncryptHelper
    {
        private const string Salt1 = "8KUqmUDDTS4JboEvH423grs";
        private const string Salt2 = "calculate12312322222grs";

        public static string Encrypt(string key)
        {
            var crypto = new CommandEncrypter(Salt1, Salt2);
            return crypto.EncryptMessage(key);
        }

        public static string Decrypt(string hash)
        {
            var crypto = new CommandEncrypter(Salt1, Salt2);
            return crypto.DecryptMessage(hash);
        }
    }
}
