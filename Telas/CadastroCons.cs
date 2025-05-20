using ProjetoDKR.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class CadastroCons : Form
    {
        public CadastroCons()
        {
            InitializeComponent();
            RBNaoOng.Checked = true;
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
                        txtNomeOng.Text = "Nome *" + erro;
                    }
                    else if (erro.Contains("CNPJ"))
                    {
                        txtCNPJOng.Text = "CNPJ *" + erro;
                    }
                    else if (erro.Contains("Telefone"))
                    {
                        txtTelOng.Text = "Telefone *" + erro;
                    }
                    else if (erro.Contains("Email"))
                    {
                        txtEmailOng.Text = "Email *" + erro;
                    }
                    else if (erro.Contains("Senha não preenchida"))
                    {
                        txtSenhaOng.Text = "Senha *" + erro;
                    }
                    else if (erro.Contains("Confirmação"))
                    {
                        txtConfirmOng.Text = "Confirme sua Senha *" + erro;
                    }
                    else if (erro.Contains("CEP"))
                    {
                        txtCEPOng.Text = "CEP *" + erro;
                    }
                    else if (erro.Contains("Numero"))
                    {
                        txtNumOng.Text = "Numero *" + erro;
                    }
                    else if (erro.Contains("Endereço"))
                    {
                        txtEndOng.Text = "Endereço *" + erro;
                    }
                    else if (erro.Contains("Senha e confirmação não coincidem"))
                    {
                        txtConfirmOng.Text = "Confirme sua Senha *" + erro;
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
}
