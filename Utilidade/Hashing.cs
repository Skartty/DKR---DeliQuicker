using System;
using System.Security.Cryptography;
using System.Text;

namespace DeliQuicker.Utilidades
{
    public static class Hashing
    {        
        private static readonly string chave = "ChaveUltraSecreta123";

        public static string Criptografar(string texto)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = Encoding.UTF8.GetBytes(chave.PadRight(32).Substring(0, 32));
                aes.GenerateIV(); 

                byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
                ICryptoTransform encryptor = aes.CreateEncryptor();

                byte[] criptografado = encryptor.TransformFinalBlock(textoBytes, 0, textoBytes.Length);
                                
                byte[] resultado = new byte[aes.IV.Length + criptografado.Length];
                Array.Copy(aes.IV, 0, resultado, 0, aes.IV.Length);
                Array.Copy(criptografado, 0, resultado, aes.IV.Length, criptografado.Length);

                return Convert.ToBase64String(resultado);
            }
        }

        public static string Descriptografar(string textoCriptografado)
        {
            byte[] dados = Convert.FromBase64String(textoCriptografado);

            using (Aes aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = Encoding.UTF8.GetBytes(chave.PadRight(32).Substring(0, 32));

                byte[] iv = new byte[16];
                Array.Copy(dados, 0, iv, 0, iv.Length);
                aes.IV = iv;

                byte[] criptografado = new byte[dados.Length - iv.Length];
                Array.Copy(dados, iv.Length, criptografado, 0, criptografado.Length);

                ICryptoTransform decryptor = aes.CreateDecryptor();
                byte[] textoBytes = decryptor.TransformFinalBlock(criptografado, 0, criptografado.Length);

                return Encoding.UTF8.GetString(textoBytes);
            }
        }

        public static bool VerifyPassword(string password, string storedEncryptedPassword)
        {
            try
            {
                string senhaDescriptografada = Descriptografar(storedEncryptedPassword);
                string Descriptografada = string.Empty;

                try 
                {
                    Descriptografada = Descriptografar(senhaDescriptografada);
                }
                catch
                {
                    Descriptografada = senhaDescriptografada;
                }
                
                return password == Descriptografada;
            }
            catch
            {
                return false;
            }
        }
    }
}
