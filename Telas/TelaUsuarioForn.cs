using DeliQuicker.Utilidades;
using ProjetoDKR.Entidades;
using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using System;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class TelaUsuarioForn : Form
    {
        private PerfilForn _perfilForn;
        private Perfil _perfil;

        private string senhaReal = "";
        private bool senhaVisivel = false;

        public TelaUsuarioForn(int idLogin)
        {
            InitializeComponent();
            _perfil = new Perfil();
            PainelSairForn.Visible = false;

            _perfilForn = _perfil.BuscarPerfilForn(idLogin);

            if (_perfilForn == null)
            {
                MessageBox.Show("Erro: Perfil do fornecedor não encontrado.");
                Close();
                return;
            }

            CarregarDadosPerfil(_perfilForn);
        }

        public TelaLogin TelaLogin
        {
            get => default;
            set
            {
            }
        }

        private void CarregarDadosPerfil(PerfilForn perfilForn)
        {
            txtNomeForn.Text = perfilForn.RazaoSocial.Trim().Length > 28
                ? perfilForn.RazaoSocial.Trim().Substring(0, 28).Trim() + "..."
                : perfilForn.RazaoSocial.Trim();

            txtCNPJForn2.Text = MascaraUtil.AplicarMascaraCNPJTexto(perfilForn.CNPJ);
            txtNomeFan2.Text = perfilForn.NomeFantasia;
            txtEmailForn2.Text = perfilForn.Email;

            senhaReal = Hashing.Descriptografar(perfilForn.Senha);
            senhaReal = senhaReal.Length > 15 
                ? senhaReal.Substring(0, 15) + "..." 
                : senhaReal;

            txtSenhaForn2.Text = "*******";
            senhaVisivel = false;

            txtTelForn2.Text = MascaraUtil.AplicarMascaraTelefoneTexto(perfilForn.Telefone);
            txtCEPForn2.Text = MascaraUtil.AplicarMascaraCEPTexto(perfilForn.CEP);
            txtNumForn2.Text = perfilForn.Numero;
            txtEndForn2.Text = perfilForn.Endereco.Length > 25 
                ? perfilForn.Endereco.Substring(0, 25) + "..." 
                : perfilForn.Endereco;

            txtComplForn2.Text = perfilForn.Complemento.Length > 20 
                ? perfilForn.Complemento.Substring(0, 20) + "..." 
                : perfilForn.Complemento;

            txtCatForn2.Text = perfilForn.Categoria;

            if (perfilForn.Transporte)
                RBSimForn1.Checked = true;
            else
                RBNaoForn1.Checked = true;
        }

        private void btnEditarForn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditarForn editarForn = new EditarForn();
            editarForn.Editar = true;
            editarForn.Perfil = _perfilForn;

            CadastroForn cadastroForn = new CadastroForn(editarForn);
            cadastroForn.Show();
        }

        private void btnMeusProd_Click(object sender, EventArgs e)
        {
            this.Hide();
            PesquisaProd pesquisaProd = new PesquisaProd("Fornecedor", _perfilForn);
            pesquisaProd.Show();
        }

        private void btnCadastrarProd_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroProd cadastroProd = new CadastroProd(_perfilForn.IdLogin);
            cadastroProd.Show();
        }

        private void iconBuscaForn_Click(object sender, EventArgs e)
        {
            this.Hide();
            PesquisaProd pesquisaProd = new PesquisaProd("Fornecedor", _perfilForn);
            pesquisaProd.Show();
        }

        private void MostrarSenhaForn_Click(object sender, EventArgs e)
        {
            if (senhaVisivel)
            {
                txtSenhaForn2.Text = "*******";
                senhaVisivel = false;
            }
            else
            {
                txtSenhaForn2.Text = senhaReal;
                senhaVisivel = true;
            }
        }

        private void IconMenuForn_Click(object sender, EventArgs e)
        {
            PainelSairForn.Visible = !PainelSairForn.Visible;
        }

        private void txtSairForn_Click(object sender, EventArgs e)
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

        private void txtExcluirForn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show(
                    "Deseja realmente exluir a conta?",
                    "Confirmação de Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    _perfil.ExcluirPerfilForn(_perfilForn);
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

