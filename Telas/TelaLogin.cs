using DeliQuicker.Utilidades;
using MySql.Data.MySqlClient;
using ProjetoDKR.Entidades;
using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnEntrar;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BoxUsername.Text) || string.IsNullOrWhiteSpace(BoxSenha.Text))
            {
                lblRetornoMsg.Text = "Por favor, preencha o usuário e a senha.";
                return;
            }

            UserLogin userLogin = new UserLogin
            {
                Email = BoxUsername.Text.Trim(),
                Senha = BoxSenha.Text.Trim()
            };

            LoginDAL loginDAL = new LoginDAL();
            Login usuarioVerificado = loginDAL.VerificarUsuario(userLogin);

            if (usuarioVerificado != null)
            {
                lblRetornoMsg.Text = "";

                if (usuarioVerificado.Tipo == "Consumidor")
                {
                    this.Hide();
                    TelaUsuarioCons telaUsuario = new TelaUsuarioCons(usuarioVerificado.Id);
                    telaUsuario.Show();
                }
                else if (usuarioVerificado.Tipo == "Fornecedor")
                {
                    this.Hide();
                    TelaUsuarioForn telaUsuarioForn = new TelaUsuarioForn(usuarioVerificado.Id);
                    telaUsuarioForn.Show();
                }
            }
            else
            {
                lblRetornoMsg.Text = "Usuário ou senha inválidos!";
            }
        }

        private void txtCadastrese_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroCons cadastroCons = new CadastroCons();
            cadastroCons.Show();
        }
    }

    public class LoginDAL
    {
        public LoginUsuario LoginUsuario
        {
            get => default;
            set
            {
            }
        }

        public Login VerificarUsuario(UserLogin userLogin)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["projeto_dkr"].ConnectionString;

                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT id, senha, tipo FROM login WHERE usuario = @usuario";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", userLogin.Email);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashSalvoNoBanco = reader.GetString("senha");

                                if (Hashing.VerifyPassword(userLogin.Senha, hashSalvoNoBanco))
                                {
                                    Login usuarioLogado = new Login
                                    {
                                        Id = reader.GetInt32("id"),
                                        Usuario = userLogin.Email,
                                        Tipo = reader.GetString("tipo")
                                    };
                                    return usuarioLogado;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no banco de dados: " + ex.Message);
            }

            return null;
        }
    }
}
