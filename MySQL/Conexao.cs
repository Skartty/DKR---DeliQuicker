using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ProjetoDKR.MySQL
{
    public class Conexao
    {
        private readonly string conexaoString;
        private MySqlConnection conexao;

        public Conexao()
        {
            conexaoString = ConfigurationManager.ConnectionStrings["projeto_dkr"].ConnectionString;
        }

        public MySqlConnection Abrir()
        {
            conexao = new MySqlConnection(conexaoString);
            conexao.Open();
            return conexao;
        }

        public void Fechar()
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
    }
}

