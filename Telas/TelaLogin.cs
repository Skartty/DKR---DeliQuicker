using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using ProjetoDKR.Service;
using System;
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
            UserLogin userLogin = new UserLogin
            {
                Email = BoxUsername.Text,
                Senha = BoxSenha.Text
            };

            var retorno = LoginValidacao.Autenticar(userLogin);
            if (string.IsNullOrEmpty(retorno))
            {
                LoginUsuario loginUsuario = new LoginUsuario();
                var usuario = loginUsuario.BuscaLoginUsuario(userLogin);

                if(usuario == null || string.IsNullOrEmpty(usuario.Usuario))
                {
                    lblRetornoMsg.Text = "Usuario não encontrado na base de dados!";
                }
                else
                {
                    if (usuario.Tipo == "Consumidor")
                    {
                        this.Hide();
                        TelaUsuarioCons telaUsuario = new TelaUsuarioCons(usuario.Id);
                        telaUsuario.Show();
                    }
                    else if (usuario.Tipo == "Fornecedor")
                    {
                        this.Hide();
                        TelaUsuarioForn telaUsuarioForn = new TelaUsuarioForn(usuario.Id);
                        telaUsuarioForn.Show();
                    }
                }                
            }
            else
            {
                lblRetornoMsg.Text = retorno;
            }
        }

        private void txtCadastrese_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroCons cadastroCons = new CadastroCons();
            cadastroCons.Show();
        }
    }

}
