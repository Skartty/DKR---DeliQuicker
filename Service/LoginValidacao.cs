using ProjetoDKR.Model;
using System;

namespace ProjetoDKR.Service
{
    public class LoginValidacao
    {
        public LoginValidacao()
        {
        }

        private static bool Autenticar(UserLogin userLogin)
        {
            if (userLogin != null)
            {
                if (string.IsNullOrEmpty (userLogin.Senha))
                {
                    Console.WriteLine("É necessario que seja inserida a senha");
                    return true;
                }
                if (string.IsNullOrEmpty(userLogin.Email))
                {
                    Console.WriteLine("É necessario que seja inserido o email");
                    return true;
                }
                return false;
            }
            return true;
        }

        public static string Logar(UserLogin userLogin)
        {
            if (!Autenticar(userLogin))
            {
                Console.WriteLine("Logado com sucesso");
                return "Logado com sucesso";
            }
            else
            {
                Console.WriteLine("Falha ao logar");
                return "Falha ao logar";
            }
        }
    }
}
