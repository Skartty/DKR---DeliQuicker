using DeliQuicker.Utilidades;
using MySql.Data.MySqlClient;
using ProjetoDKR.Entidades;
using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public TelaLogin TelaLogin
        {
            get => default;
            set
            {
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
                _editarCons.Perfil.Nome = BoxNomeOng.Text.Trim();
                _editarCons.Perfil.CNPJ = BoxCNPJOng.Text.Trim().Replace(".", "").Replace("/", "").Replace("-", "");
                _editarCons.Perfil.Telefone = new string(BoxTelOng.Text.Trim().Where(char.IsDigit).ToArray());
                _editarCons.Perfil.Email = BoxEmailOng.Text.Trim();
                _editarCons.Perfil.CEP = BoxCEPOng.Text.Trim().Replace(".", "").Replace("-", "");
                _editarCons.Perfil.Numero = BoxNumOng.Text.Trim();
                _editarCons.Perfil.Endereco = BoxEndOng.Text.Trim();
                _editarCons.Perfil.Complemento = BoxComplOng.Text.Trim();
                _editarCons.Perfil.Transporte = RBSimOng.Checked;

                if (!string.IsNullOrWhiteSpace(BoxSenhaOng.Text.Trim()))
                {
                    if (BoxSenhaOng.Text.Trim() == BoxConfirmOng.Text.Trim())
                    {
                        _editarCons.Perfil.Senha = Hashing.Criptografar(BoxSenhaOng.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show("A nova senha e a confirmação não coincidem.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                Perfil editarPerfil = new Perfil();
                editarPerfil.EditarPerfilCons(_editarCons.Perfil);

                this.Hide();
                TelaUsuarioCons telaUsuario = new TelaUsuarioCons(_editarCons.Perfil.IdLogin);
                telaUsuario.Show();
            }
            else
            {
                string nome = BoxNomeOng.Text.Trim();
                string cnpj = BoxCNPJOng.Text.Trim().Replace(".", "").Replace("/", "").Replace("-", "");
                string telefone = BoxTelOng.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "");
                string email = BoxEmailOng.Text.Trim();
                string senha = BoxSenhaOng.Text.Trim();
                string confirmSenha = BoxConfirmOng.Text.Trim();
                string cep = BoxCEPOng.Text.Replace(".", "").Replace("-", "");
                string numero = BoxNumOng.Text.Trim();
                string endereco = BoxEndOng.Text.Trim();
                string complemento = BoxComplOng.Text.Trim();
                bool entrega = false;

                if (RBSimOng.Checked == true)
                {
                    entrega = true;
                }

                CadastroConsModel cadastroConsModel = new CadastroConsModel(nome, cnpj, telefone, email,
                senha, confirmSenha, cep, numero, endereco, complemento, entrega);

                List<string> erros = new List<string>();
                erros = cadastroConsModel.Validar();

                txtNomeOngErro.Text = "";
                txtCNPJOngErro.Text = "";
                txtTelOngErro.Text = "";
                txtEmailOngErro.Text = "";
                txtSenhaOngErro.Text = "";
                txtConfirmOngErro.Text = "";
                txtCEPOngErro.Text = "";
                txtNumOngErro.Text = "";
                txtEndOngErro.Text = "";

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
                    try
                    {
                        string senhaHasheada = Hashing.Criptografar(senha);

                        this.Hide();                        

                        Perfil perfil = new Perfil();
                        perfil.InserirPerfil(new PerfilCons
                        {
                            Nome = nome,
                            CNPJ = cnpj,
                            Email = email,
                            Senha = senhaHasheada,
                            Telefone = telefone,
                            CEP = cep,
                            Numero = numero,
                            Endereco = endereco,
                            Complemento = complemento,
                            Transporte = entrega
                        });

                        MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        new TelaLogin().Show();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Erro ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void PreencherCamposEdicao(EditarCons editarCons)
        {
            BoxNomeOng.Text = editarCons.Perfil.Nome;
            BoxCNPJOng.Text = editarCons.Perfil.CNPJ;
            BoxTelOng.Text = editarCons.Perfil.Telefone;
            BoxEmailOng.Text = editarCons.Perfil.Email;
            BoxCEPOng.Text = editarCons.Perfil.CEP;
            BoxNumOng.Text = editarCons.Perfil.Numero;
            BoxEndOng.Text = editarCons.Perfil.Endereco;
            BoxComplOng.Text = editarCons.Perfil.Complemento;

            BoxSenhaOng.Text = Hashing.Descriptografar(editarCons.Perfil.Senha);
            BoxConfirmOng.Text = Hashing.Descriptografar(editarCons.Perfil.Senha);

            if (editarCons.Perfil.Transporte)
            {
                RBSimOng.Checked = true;
            }
            else
            {
                RBNaoOng.Checked = true;
            }
        }

        private void BoxCNPJOng_TextChanged(object sender, EventArgs e)
        {
            MascaraUtil.AplicarMascaraCNPJ(BoxCNPJOng);
        }

        private void BoxTelOng_TextChanged(object sender, EventArgs e)
        {
            MascaraUtil.AplicarMascaraTelefone(BoxTelOng);
        }

        private void BoxCEPOng_TextChanged(object sender, EventArgs e)
        {
            MascaraUtil.AplicarMascaraCEP(BoxCEPOng);
        }
    }
}
