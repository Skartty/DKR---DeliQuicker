using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace DeliQuicker.Utilidades
{
    public static class Criptografia
    {
        private static readonly string chave = "minhaChaveSecreta123";

        public static string Criptografar(string texto)
        {
            byte[] key = Encoding.UTF8.GetBytes(chave.Substring(0, 16));

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = key;
                using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(texto);
                    byte[] criptografado = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
                    return Convert.ToBase64String(criptografado);
                }
            }
        }

        public static string Descriptografar(string textoCriptografado)
        {
            byte[] key = Encoding.UTF8.GetBytes(chave.Substring(0, 16));

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = key;
                using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                {
                    byte[] bytes = Convert.FromBase64String(textoCriptografado);
                    byte[] texto = decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
                    return Encoding.UTF8.GetString(texto);
                }
            }
        }
    }
}

