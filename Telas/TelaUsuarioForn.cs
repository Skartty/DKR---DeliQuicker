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

        private void CarregarDadosPerfil(PerfilForn perfilForn)
        {
            txtNomeForn.Text = perfilForn.RazaoSocial;
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

        private void button1_Click(object sender, EventArgs e)
        {
            EditarForn editarForn = new EditarForn
            {
                Editar = true,
                Perfil = _perfilForn
            };

            CadastroForn cadastroForn = new CadastroForn(editarForn);

            cadastroForn.FormClosed += (s, args) =>
            {
                Perfil perfilRepo = new Perfil();
                var perfilAtualizado = perfilRepo.BuscarPerfilForn(_perfilForn.IdLogin);

                if (perfilAtualizado == null)
                {
                    MessageBox.Show("Erro: Perfil atualizado não encontrado.");
                    Application.Exit();
                    return;
                }

                TelaUsuarioForn novaTela = new TelaUsuarioForn(perfilAtualizado.IdLogin);
                novaTela.Show();
            };

            this.Close(); 
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
    }
}

