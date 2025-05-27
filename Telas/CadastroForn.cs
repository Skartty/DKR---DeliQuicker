using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class CadastroForn : Form
    {
        private EditarForn _editarForn;
        public CadastroForn(EditarForn editar = null)
        {
            _editarForn = editar;
            InitializeComponent();
            if (editar != null)
            {
                if (editar.Editar)
                {
                    btnOngF.Visible = false;
                    btnFornF.Visible = false;
                    txtVoltarForn.Visible = false;
                    btnEntrarForn.Text = "Salvar";
                }
                PreencherCamposEdicao(editar);
            }
            else
            {
                RBNaoForn.Checked = true;
            }
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

        private void btnEntrarForn_Click(object sender, System.EventArgs e)
        {
            if(_editarForn.Editar)
            {
                Perfil editarPerfil = new Perfil();
                editarPerfil.EditarPerfilForn(_editarForn.Perfil);

                this.Hide();
                TelaUsuarioForn telaUsuario = new TelaUsuarioForn(_editarForn.Perfil.Id);
                telaUsuario.Show();
            }
            else
            {
                string cnpj = BoxCNPJForn.Text.Replace(".", "").Replace("/", "").Replace("-", "");
                string razaoSocial = BoxRazaoForn.Text;
                string nomeFantasia = BoxNomeForn.Text;
                string email = BoxEmailForn.Text;
                string senha = BoxSenhaForn.Text;
                string confirmSenha = BoxConfirmForn.Text;
                string telefone = BoxTelForn.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                string cep = BoxCEPForn.Text.Replace(".", "").Replace("-", "");
                string numero = BoxNumForn.Text;
                string endereco = BoxEndForn.Text;
                string complemento = BoxComplForn.Text;
                //ver como validar combobox categoria

                bool entrega = false;

                if (RBSimForn.Checked == true)
                {
                    entrega = true;
                }

                CadastroFornModel cadastroFornModel = new CadastroFornModel(cnpj, razaoSocial, nomeFantasia,
                email, senha, confirmSenha, telefone, cep, numero, endereco, complemento, entrega);

                List<string> erros = new List<string>();
                erros = cadastroFornModel.Validar();

                txtCNPJForn.Text = "CNPJ";
                txtRazaoForn.Text = "Razão Social";
                txtNomeForn.Text = "Nome Fantasia";
                txtTelForn.Text = "Telefone";
                txtEmailForn.Text = "Email";
                txtSenhaForn.Text = "Senha";
                txtConfirmForn.Text = "Confirme sua Senha";
                txtCEPForn.Text = "CEP";
                txtNumForn.Text = "Numero";
                txtEndForn.Text = "Endereço";

                if (erros.Count > 0)
                {
                    foreach (var erro in erros)
                    {
                        if (erro.Contains("CNPJ"))
                        {
                            txtCNPJFornErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Razão Social"))
                        {
                            txtRazaoFornErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Email"))
                        {
                            txtEmailFornErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Senha não preenchida"))
                        {
                            txtSenhaFornErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Confirmação"))
                        {
                            txtConfirmFornErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Telefone"))
                        {
                            txtTelFornErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("CEP"))
                        {
                            txtCEPFornErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Numero"))
                        {
                            txtNumFornErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Endereço"))
                        {
                            txtEndFornErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Senha e confirmação não coincidem"))
                        {
                            txtConfirmFornErro.Text = "* " + erro;
                        }
                    }
                }
                else
                {
                    this.Hide();
                    // Aqui você pode adicionar o código para salvar os dados do cadastro no banco de dados
                    TelaLogin telaLogin = new TelaLogin();
                    telaLogin.Show();
                }
            }
        }         

        private void PreencherCamposEdicao(EditarForn editarForn)
        {
            BoxCNPJForn.Text = editarForn.Perfil.CNPJ;
            BoxRazaoForn.Text = editarForn.Perfil.RazaoSocial;
            BoxNomeForn.Text = editarForn.Perfil.NomeFantasia;
            BoxTelForn.Text = editarForn.Perfil.Telefone;
            BoxEmailForn.Text = editarForn.Perfil.Email;
            BoxSenhaForn.Text = editarForn.Perfil.Senha;
            BoxConfirmForn.Text = editarForn.Perfil.Senha;
            BoxCEPForn.Text = editarForn.Perfil.CEP;
            BoxNumForn.Text = editarForn.Perfil.Numero;
            BoxEndForn.Text = editarForn.Perfil.Endereco;
            BoxComplForn.Text = editarForn.Perfil.Complemento;

            //Ver como editar o combobox de categoria

            if (editarForn.Perfil.Transporte)
            {
                RBSimForn.Checked = true;
            }
            else
            {
                RBNaoForn.Checked = true;
            }
        }
    }
}

