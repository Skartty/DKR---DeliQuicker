using ProjetoDKR.Entidades;
using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class TelaUsuarioCons : Form
    {
        private PerfilCons _perfilCons;
        private Perfil _perfil;

        private string senhaReal = "";
        private bool senhaVisivel = false;
        public TelaUsuarioCons(int id)
        {
            InitializeComponent();
            _perfil = new Perfil();

            PainelSairCons.Visible = false;

            _perfilCons = _perfil.BuscarPerfilCons(id);
            CarregarDadosPerfil(_perfilCons);
        } 
        
        private void CarregarDadosPerfil(PerfilCons perfilCons)
        {
            txtNomeUC.Text = perfilCons.Nome;
            txtCNPJCons2.Text = perfilCons.CNPJ;
            txtEmailCons2.Text = perfilCons.Email;

            senhaReal = perfilCons.Senha;
            txtSenhaCons2.Text = "*******";
            senhaVisivel = false;

            txtTelCons2.Text = perfilCons.Telefone;
            txtCEPCons2.Text = perfilCons.CEP;
            txtNumCons2.Text = perfilCons.Numero;
            txtEndCons2.Text = perfilCons.Endereco;
            txtComplCons2.Text = perfilCons.Complemento;

            if(perfilCons.Transporte)
            {
                RBSimCons1.Checked = true;
            }
            else
            {
                RBNaoCons1.Checked = true;
            }
        }

        private void btnEditarCons_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            EditarCons editarCons = new EditarCons();
            editarCons.Editar = true;
            editarCons.Perfil = _perfilCons;

            CadastroCons cadastroCons = new CadastroCons(editarCons);
            cadastroCons.Show();
        }


        private void iconBuscaCons_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            PesquisaProd pesquisaProd = new PesquisaProd("Consumidor", null, _perfilCons);
            pesquisaProd.Show();
        }

        private void MostrarSenhaOng_Click(object sender, System.EventArgs e)
        {
            if (senhaVisivel)
            {
                txtSenhaCons2.Text = "*******";
                senhaVisivel = false;
            }
            else
            {
                txtSenhaCons2.Text = senhaReal;
                senhaVisivel = true;
            }
        }

        private void IconMenuCons_Click(object sender, System.EventArgs e)
        {
            PainelSairCons.Visible = !PainelSairCons.Visible;
        }

        private void txtSairCons_Click(object sender, System.EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
            "Deseja realmente sair do programa?",
            "Confirmação de Saída",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
