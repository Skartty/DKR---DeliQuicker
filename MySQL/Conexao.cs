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

        public TelaLogin TelaLogin
        {
            get => default;
            set
            {
            }
        }

        public CadastroForn CadastroForn
        {
            get => default;
            set
            {
            }
        }

        public CadastroCons CadastroCons
        {
            get => default;
            set
            {
            }
        }

        public CadastroProd CadastroProd
        {
            get => default;
            set
            {
            }
        }

        public PesquisaProd PesquisaProd
        {
            get => default;
            set
            {
            }
        }

        public TelaUsuarioCons TelaUsuarioCons
        {
            get => default;
            set
            {
            }
        }

        public TelaUsuarioForn TelaUsuarioForn
        {
            get => default;
            set
            {
            }
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
            {
                conexao.Close();
            }
        }
    }
}

