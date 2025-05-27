using ProjetoDKR.Entidades;
using ProjetoDKR.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoDKR.MySQL
{
    public class LoginUsuario
    {
        public LoginUsuario()
        {
            
        }

        public Login BuscaLoginUsuario(UserLogin user)
        {
            List<Login> list = new List<Login>();
            list.Add(new Login() { Id = 1, Senha = "123", Usuario = "Usuario.Teste@gmail.com", Tipo = "Consumidor" });
            list.Add(new Login() { Id = 2, Senha = "321", Usuario = "Usuario.Teste2@gmail.com", Tipo = "Fornecedor" });

            if(list.Any(a => a.Usuario == user.Email && a.Senha == user.Senha))
            {
                return list.Where(w =>  w.Usuario == user.Email && w.Senha == user.Senha).First();
            }
            return null;
        }
    }
}
