using ProjetoDKR.Model;
using System;

namespace ProjetoDKR.Service
{
    public class LoginValidacao
    {
        public LoginValidacao()
        {
        }

        public static string Autenticar(UserLogin userLogin)
        {
            if (userLogin != null)
            {
                if (string.IsNullOrEmpty (userLogin.Senha) || string.IsNullOrEmpty(userLogin.Email))
                {
                    return "É necessario que os dados sejam inseridos corretamente";
                }
                return null;
            }
            return "Deve Inserir os dados para Login";
        }
    }
}
