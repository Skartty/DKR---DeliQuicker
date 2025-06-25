using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DeliQuicker.Utilidades
{
    public static class CriptografiaSimples
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int Iterations = 10000;

        public static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    public static class Hashing
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int Iterations = 10000;

        // Deve ser guardada em local seguro, como Azure Key Vault ou variáveis de ambiente
        private static readonly string chave = "ChaveUltraSecreta123"; // Deve ter 16, 24 ou 32 bytes

        public static string Criptografar(string texto)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(chave.PadRight(32).Substring(0, 32));
                aes.GenerateIV();

                ICryptoTransform encryptor = aes.CreateEncryptor();
                byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
                byte[] criptografado = encryptor.TransformFinalBlock(textoBytes, 0, textoBytes.Length);

                // Junta o IV + criptografado para conseguir descriptografar depois
                byte[] resultado = new byte[aes.IV.Length + criptografado.Length];
                Array.Copy(aes.IV, 0, resultado, 0, aes.IV.Length);
                Array.Copy(criptografado, 0, resultado, aes.IV.Length, criptografado.Length);

                return Convert.ToBase64String(resultado);
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            string senhaDesc = Descriptografar(storedHash);

            if(password == senhaDesc)
            {
                return true;
            }

            return false;
        }


        public static string Descriptografar(string textoCriptografado)
        {
            byte[] dados = Convert.FromBase64String(textoCriptografado);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(chave.PadRight(32).Substring(0, 32));

                byte[] iv = new byte[16];
                Array.Copy(dados, iv, iv.Length);
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor();
                byte[] textoBytes = decryptor.TransformFinalBlock(dados, iv.Length, dados.Length - iv.Length);

                return Encoding.UTF8.GetString(textoBytes);
            }
        }
    }
}
