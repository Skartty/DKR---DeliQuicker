using DeliQuicker.Utilidades;
using ProjetoDKR.Entidades;
using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using System;
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

        public TelaLogin TelaLogin
        {
            get => default;
            set
            {
            }
        }

        private void CarregarDadosPerfil(PerfilCons perfilCons)
        {
            txtNomeUC.Text = perfilCons.Nome.Trim().Length > 28
                ? perfilCons.Nome.Trim().Substring(0, 28).Trim() + "..."
                : perfilCons.Nome.Trim();

            txtCNPJCons2.Text = MascaraUtil.AplicarMascaraCNPJTexto(perfilCons.CNPJ);
            txtEmailCons2.Text = perfilCons.Email;

            senhaReal = Hashing.Descriptografar(perfilCons.Senha);
            senhaReal = senhaReal.Length > 15
                ? senhaReal.Substring(0, 15) + "..."
                : senhaReal;

            txtSenhaCons2.Text = "*******";
            senhaVisivel = false;

            txtTelCons2.Text = MascaraUtil.AplicarMascaraTelefoneTexto(perfilCons.Telefone);
            txtCEPCons2.Text = MascaraUtil.AplicarMascaraCEPTexto(perfilCons.CEP);
            txtNumCons2.Text = perfilCons.Numero;
            txtEndCons2.Text = perfilCons.Endereco.Length > 25
                ? perfilCons.Endereco.Substring(0, 25) + "..."
                : perfilCons.Endereco;

            txtComplCons2.Text = perfilCons.Complemento.Length > 20
                ? perfilCons.Complemento.Substring(0, 20) + "..."
                : perfilCons.Complemento;

            if (perfilCons.Transporte)
            {
                RBSimCons1.Checked = true;
            }
            else
            {
                RBNaoCons1.Checked = true;
            }
        }

        private void btnEditarCons_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditarCons editarCons = new EditarCons();
            editarCons.Editar = true;
            editarCons.Perfil = _perfilCons;

            CadastroCons cadastroCons = new CadastroCons(editarCons);
            cadastroCons.Show();
        }


        private void iconBuscaCons_Click(object sender, EventArgs e)
        {
            this.Hide();
            PesquisaProd pesquisaProd = new PesquisaProd("Consumidor", null, _perfilCons);
            pesquisaProd.Show();
        }

        private void MostrarSenhaOng_Click(object sender, EventArgs e)
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

        private void IconMenuCons_Click(object sender, EventArgs e)
        {
            PainelSairCons.Visible = !PainelSairCons.Visible;
        }

        private void txtSairCons_Click(object sender, EventArgs e)
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

        private void txtExcluirCons_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show(
                    "Deseja realmente excluir a conta?",
                    "Confirmação de Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    _perfil.ExcluirPerfilCons(_perfilCons);
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao tentar excluir o perfil do usuario.");
            }
        }
    }
}
