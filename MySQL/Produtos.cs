using MySql.Data.MySqlClient;
using ProjetoDKR.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ProjetoDKR.MySQL
{
    public class Produtos
    {
        private readonly string _connectionString;

        public Produtos()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["projeto_dkr"].ConnectionString;
        }

        public void InserirProduto(Produto produto)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string sql = @"INSERT INTO produto 
                    (id_forn, nome_produto, categoria, validade, quantidade, descricao, imagem)
                    VALUES
                    (@idForn, @nome, @categoria, @validade, @quantidade, @descricao, @imagem)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idForn", produto.IdForn);
                    cmd.Parameters.AddWithValue("@nome", produto.NomeProduto);
                    cmd.Parameters.AddWithValue("@categoria", produto.Categoria);
                    cmd.Parameters.AddWithValue("@validade", DateTime.Parse(produto.Validade).ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                    cmd.Parameters.AddWithValue("@descricao", produto.Descricao ?? "");

                    if (produto.Imagem != null)
                        cmd.Parameters.Add("@imagem", MySqlDbType.LongBlob).Value = produto.Imagem;
                    else
                        cmd.Parameters.Add("@imagem", MySqlDbType.LongBlob).Value = DBNull.Value;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Produto> BuscarListaProdutos(string referencia = null)
        {
            List<Produto> produtos = new List<Produto>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string sql = @"SELECT * FROM produto";

                if (!string.IsNullOrEmpty(referencia))
                {
                    sql += " WHERE nome_produto LIKE @referencia";
                }

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(referencia))
                    {
                        cmd.Parameters.AddWithValue("@referencia", "%" + referencia + "%");
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                Id = reader.GetInt32("id"),
                                IdForn = reader.GetInt32("id_forn"),
                                NomeProduto = reader.GetString("nome_produto"),
                                Categoria = reader.GetString("categoria"),
                                Validade = reader.GetDateTime("validade").ToString("yyyy-MM-dd"),
                                Quantidade = reader.GetInt32("quantidade"),
                                Descricao = reader.GetString("descricao"),
                                Imagem = reader["imagem"] != DBNull.Value ? (byte[])reader["imagem"] : null
                            };

                            produtos.Add(produto);
                        }
                    }
                }
            }

            return produtos;
        }


        public List<Produto> BuscarListaProdutoForn(int idForn)
        {
            List<Produto> produtos = new List<Produto>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string sql = @"SELECT * FROM produto WHERE id_forn = @idForn";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idForn", idForn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                Id = reader.GetInt32("id"),
                                IdForn = reader.GetInt32("id_forn"),
                                NomeProduto = reader.GetString("nome_produto"),
                                Categoria = reader.GetString("categoria"),
                                Validade = reader.GetDateTime("validade").ToString("yyyy-MM-dd"),
                                Quantidade = reader.GetInt32("quantidade"),
                                Descricao = reader.GetString("descricao"),
                                Imagem = reader["imagem"] != DBNull.Value ? (byte[])reader["imagem"] : null
                            };

                            produtos.Add(produto);
                        }
                    }
                }
            }

            return produtos;
        }
    }
}
