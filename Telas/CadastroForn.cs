using System.Drawing;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class CadastroForn : Form
    {
        public CadastroForn()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }


        private void txtVoltarForn_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();
        }

        private void btnOngF_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            CadastroCons cadastroCons = new CadastroCons();
            cadastroCons.Show();
        }
    }
}
