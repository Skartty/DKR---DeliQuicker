using MySql.Data.MySqlClient;
using ProjetoDKR.Entidades;
using System;
using System.Configuration;
using System.Windows.Forms;


namespace ProjetoDKR.MySQL
{
    public class Perfil
    {
        private readonly string _connectionString;

        public Perfil()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["projeto_dkr"].ConnectionString;
        }

        public PerfilCons BuscarPerfilCons(int idLogin)
        {
            PerfilCons perfil = null;
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM perfil_cons WHERE id_login = @id_login";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_login", idLogin);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            perfil = new PerfilCons
                            {
                                Id = reader.GetInt32("id"),
                                IdLogin = reader.GetInt32("id_login"),
                                Nome = reader.GetString("nome"),
                                CNPJ = reader.GetString("cnpj"),
                                Email = reader.GetString("email"),
                                Senha = reader.GetString("senha"),
                                Telefone = reader.GetString("telefone"),
                                CEP = reader.GetString("cep"),
                                Numero = reader.GetString("numero"),
                                Endereco = reader.GetString("endereco"),
                                Complemento = reader.GetString("complemento"),
                                Transporte = reader.GetBoolean("transporte")
                            };
                        }
                    }
                }
            }
            return perfil;
        }


        public void EditarPerfilCons(PerfilCons perfil)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE login l
                                 JOIN perfil_cons p ON l.id = p.id_login
                                 SET 
                                    l.senha = @senha, 
                                    p.nome = @nome,
                                    p.cnpj = @cnpj,
                                    p.email = @email,
                                    p.senha = @senha,
                                    p.telefone = @telefone,
                                    p.cep = @cep,
                                    p.numero = @numero,
                                    p.endereco = @endereco,
                                    p.complemento = @complemento,
                                    p.transporte = @transporte
                                 WHERE l.id = @idLogin";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@senha", perfil.Senha);
                        cmd.Parameters.AddWithValue("@nome", perfil.Nome);
                        cmd.Parameters.AddWithValue("@cnpj", perfil.CNPJ);
                        cmd.Parameters.AddWithValue("@email", perfil.Email);
                        cmd.Parameters.AddWithValue("@telefone", perfil.Telefone);
                        cmd.Parameters.AddWithValue("@cep", perfil.CEP);
                        cmd.Parameters.AddWithValue("@numero", perfil.Numero);
                        cmd.Parameters.AddWithValue("@endereco", perfil.Endereco);
                        cmd.Parameters.AddWithValue("@complemento", perfil.Complemento);
                        cmd.Parameters.AddWithValue("@transporte", perfil.Transporte);
                        cmd.Parameters.AddWithValue("@idLogin", perfil.IdLogin);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o perfil: " + ex.Message);
            }
        }


        public PerfilForn BuscarPerfilForn(int idLogin)
        {
            PerfilForn perfil = null;
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM perfil_forn WHERE id_login = @id_login";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_login", idLogin);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            perfil = new PerfilForn
                            {
                                Id = reader.GetInt32("id"),
                                IdLogin = reader.GetInt32("id_login"),
                                CNPJ = reader.GetString("cnpj"),
                                RazaoSocial = reader.GetString("razao_social"),
                                NomeFantasia = reader.GetString("nome_fantasia"),
                                Email = reader.GetString("email"),
                                Senha = reader.GetString("senha"),
                                Telefone = reader.GetString("telefone"),
                                CEP = reader.GetString("cep"),
                                Numero = reader.GetString("numero"),
                                Endereco = reader.GetString("endereco"),
                                Complemento = reader.GetString("complemento"),
                                Categoria = reader.GetString("categoria"),
                                Transporte = reader.GetBoolean("transporte")
                            };
                        }
                    }
                }
            }
            return perfil;
        }



        public void EditarPerfilForn(PerfilForn perfil)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE login l
                                 JOIN perfil_forn p ON l.id = p.id_login
                                 SET 
                                    l.senha = @senha,
                                    p.cnpj = @cnpj,
                                    p.razao_social = @razao_social,
                                    p.nome_fantasia = @nome_fantasia,
                                    p.email = @email,
                                    p.senha = @senha,
                                    p.telefone = @telefone,
                                    p.cep = @cep,
                                    p.numero = @numero,
                                    p.endereco = @endereco,
                                    p.complemento = @complemento,
                                    p.categoria = @categoria,
                                    p.transporte = @transporte
                                 WHERE l.id = @idLogin";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@senha", perfil.Senha);
                        cmd.Parameters.AddWithValue("@cnpj", perfil.CNPJ);
                        cmd.Parameters.AddWithValue("@razao_social", perfil.RazaoSocial);
                        cmd.Parameters.AddWithValue("@nome_fantasia", perfil.NomeFantasia);
                        cmd.Parameters.AddWithValue("@email", perfil.Email);
                        cmd.Parameters.AddWithValue("@telefone", perfil.Telefone);
                        cmd.Parameters.AddWithValue("@cep", perfil.CEP);
                        cmd.Parameters.AddWithValue("@numero", perfil.Numero);
                        cmd.Parameters.AddWithValue("@endereco", perfil.Endereco);
                        cmd.Parameters.AddWithValue("@complemento", perfil.Complemento);
                        cmd.Parameters.AddWithValue("@categoria", perfil.Categoria);
                        cmd.Parameters.AddWithValue("@transporte", perfil.Transporte);
                        cmd.Parameters.AddWithValue("@idLogin", perfil.IdLogin);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o perfil do fornecedor: " + ex.Message);
            }
        }
    }
}
