using ProjetoDKR.Model;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin
            {
                Email = BoxUsername.Text,
                Senha = BoxSenha.Text
            };

            lblRetornoMsg.Text = LoginValidacao.Logar(userLogin);
            
        }

        private void txtCadastrese_Click(object sender, EventArgs e)
        {
            Hide();
            CadastroCons cadastroCons = new CadastroCons();
            cadastroCons.Show();


        }
    }

}
