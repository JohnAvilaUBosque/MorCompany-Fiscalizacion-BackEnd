using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MorCompany.Fiscalizacion.Utilidades.Ayudantes
{
    public static class AyudanteSeguridad
    {
        public static string EncriptarConAes(string text, string keyString)
        {
            byte[] iv = new byte[16];

            var key = Encoding.UTF8.GetBytes(keyString);

            using (Aes aes = Aes.Create())
            {
                //aes.Padding = PaddingMode.Zeros;
                aes.IV = iv;
                using (ICryptoTransform encryptor = aes.CreateEncryptor(key, aes.IV))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                            {
                                streamWriter.Write(text);
                            }
                        }

                        var buffer = memoryStream.ToArray();

                        return Convert.ToBase64String(buffer);
                    }
                }
            }
        }

        public static string DesencriptarConAes(string cipherText, string keyString)
        {
            byte[] iv = new byte[16];

            var buffer = Convert.FromBase64String(cipherText);

            var key = Encoding.UTF8.GetBytes(keyString);

            using (Aes aes = Aes.Create())
            {
                //aes.Padding = PaddingMode.Zeros;
                aes.IV = iv;
                using (ICryptoTransform decryptor = aes.CreateDecryptor(key, aes.IV))
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader(cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}
