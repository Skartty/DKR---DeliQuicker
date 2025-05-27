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
        public TelaUsuarioCons(int id)
        {
            InitializeComponent();
            _perfil = new Perfil();

            _perfilCons = _perfil.BuscarPerfilCons(id);
            CarregarDadosPerfil(_perfilCons);
        } 
        
        private void CarregarDadosPerfil(PerfilCons perfilCons)
        {
            txtNomeUC.Text = perfilCons.Nome;
            txtCNPJCons2.Text = perfilCons.CNPJ;
            txtEmailCons2.Text = perfilCons.Email;
            txtSenhaCons2.Text = perfilCons.Senha;
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
            //chamar a tela de pesquisa de produtos geral
        }
    }
}
