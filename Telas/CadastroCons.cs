using ProjetoDKR.Entidades;
using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class CadastroCons : Form
    {
        private EditarCons _editarCons;
        public CadastroCons(EditarCons editar = null)
        {
            _editarCons = editar;
            InitializeComponent();
            if (editar != null)
            {
                if (editar.Editar)
                {
                    btnOngO.Visible = false;
                    btnFornO.Visible = false;
                    txtVoltarOng.Visible = false;
                    btnEntrarOng.Text = "Salvar";
                }
                PreencherCamposEdicao(editar);
            }
            else
            {
                RBNaoOng.Checked = true;
            }                
        }

        private void txtVoltarOng_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();
        }
        private void btnFornO_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroForn cadastroForn = new CadastroForn();
            cadastroForn.Show();
        }

        private void btnEntrarOng_Click(object sender, EventArgs e)
        {
            if (_editarCons != null && _editarCons.Editar)
            {
                Perfil editarPerfil = new Perfil();
                editarPerfil.EditarPerfilCons(_editarCons.Perfil);

                this.Hide();
                TelaUsuarioCons telaUsuario = new TelaUsuarioCons(_editarCons.Perfil.Id);
                telaUsuario.Show();
            }
            else
            {
                string nome = BoxNomeOng.Text;
                string cnpj = BoxCNPJOng.Text.Replace(".", "").Replace("/", "").Replace("-", "");
                string telefone = BoxTelOng.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                string email = BoxEmailOng.Text;
                string senha = BoxSenhaOng.Text;
                string confirmSenha = BoxConfirmOng.Text;
                string cep = BoxCEPOng.Text.Replace(".", "").Replace("-", "");
                string numero = BoxNumOng.Text;
                string endereco = BoxEndOng.Text;
                string complemento = BoxComplOng.Text;

                bool entrega = false;

                if (RBSimOng.Checked == true)
                {
                    entrega = true;
                }

                CadastroConsModel cadastroConsModel = new CadastroConsModel(nome, cnpj, telefone, email,
                    senha, confirmSenha, cep, numero, endereco, complemento, entrega);

                List<string> erros = new List<string>();
                erros = cadastroConsModel.Validar();

                txtNomeOng.Text = "Nome";
                txtCNPJOng.Text = "CNPJ";
                txtTelOng.Text = "Telefone";
                txtEmailOng.Text = "Email";
                txtSenhaOng.Text = "Senha";
                txtConfirmOng.Text = "Confirme sua Senha";
                txtCEPOng.Text = "CEP";
                txtNumOng.Text = "Numero";
                txtEndOng.Text = "Endereço";

                if (erros.Count > 0)
                {
                    foreach (var erro in erros)
                    {
                        if (erro.Contains("Nome"))
                        {
                            txtNomeOngErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("CNPJ"))
                        {
                            txtCNPJOngErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Telefone"))
                        {
                            txtTelOngErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Email"))
                        {
                            txtEmailOngErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Senha não preenchida"))
                        {
                            txtSenhaOngErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Confirmação"))
                        {
                            txtConfirmOngErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("CEP"))
                        {
                            txtCEPOngErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Numero"))
                        {
                            txtNumOngErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Endereço"))
                        {
                            txtEndOngErro.Text = "* " + erro;
                        }
                        else if (erro.Contains("Senha e confirmação não coincidem"))
                        {
                            txtConfirmOngErro.Text = "* " + erro;
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
    
        private void PreencherCamposEdicao(EditarCons editarCons)
        {
            BoxNomeOng.Text = editarCons.Perfil.Nome;
            BoxCNPJOng.Text = editarCons.Perfil.CNPJ;
            BoxTelOng.Text = editarCons.Perfil.Telefone;
            BoxEmailOng.Text = editarCons.Perfil.Email;
            BoxSenhaOng.Text = editarCons.Perfil.Senha;
            BoxConfirmOng.Text = editarCons.Perfil.Senha;
            BoxCEPOng.Text = editarCons.Perfil.CEP;
            BoxNumOng.Text = editarCons.Perfil.Numero;
            BoxEndOng.Text = editarCons.Perfil.Endereco;
            BoxComplOng.Text = editarCons.Perfil.Complemento;

            if (editarCons.Perfil.Transporte)
            {
                RBSimOng.Checked = true;
            }
            else
            {
                RBNaoOng.Checked = true;
            }
        }
    }
}
