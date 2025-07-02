using MySql.Data.MySqlClient;
using ProjetoDKR.Entidades;
using ProjetoDKR.Model;
using System;
using System.Configuration;

namespace ProjetoDKR.MySQL
{
    public class LoginUsuario
    {
        private string _connectionString;

        public LoginUsuario()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["projeto_dkr"].ConnectionString;
        }

        public Login BuscaLoginUsuario(UserLogin user)
        {
            Login login = null;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = @"SELECT id, usuario, senha, tipo
                                     FROM login
                                     WHERE usuario = @usuario AND senha = @senha";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", user.Email);
                        cmd.Parameters.AddWithValue("@senha", user.Senha);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                login = new Login
                                {
                                    Id = reader.GetInt32("id"),
                                    Usuario = reader.GetString("usuario"),
                                    Senha = reader.GetString("senha"),
                                    Tipo = reader.GetString("tipo")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar login: " + ex.Message);
            }

            return login;

        }
        public bool BuscaLoginExistente(string email)
        {
            Login login = null;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = @"SELECT id, usuario, senha, tipo
                                     FROM login
                                     WHERE usuario = @usuario";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", email);                        

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                login = new Login
                                {
                                    Id = reader.GetInt32("id"),
                                    Usuario = reader.GetString("usuario"),
                                    Senha = reader.GetString("senha"),
                                    Tipo = reader.GetString("tipo")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            if (login == null)
            {
                return false;
            }
            
            return true;
        }

    }
}
