using MySql.Data.MySqlClient;
using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DeliQuicker.Utilidades;
using ProjetoDKR.Entidades;

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
            if (_editarForn != null && _editarForn.Editar)
            {
                _editarForn.Perfil.CNPJ = BoxCNPJForn.Text.Trim().Replace(".", "").Replace("/", "").Replace("-", "");
                _editarForn.Perfil.RazaoSocial = BoxRazaoForn.Text.Trim();
                _editarForn.Perfil.NomeFantasia = BoxNomeForn.Text.Trim();
                _editarForn.Perfil.Email = BoxEmailForn.Text.Trim();
                _editarForn.Perfil.Telefone = new string(BoxTelForn.Text.Trim().Where(char.IsDigit).ToArray());
                _editarForn.Perfil.CEP = BoxCEPForn.Text.Trim().Replace(".", "").Replace("-", "");
                _editarForn.Perfil.Numero = BoxNumForn.Text.Trim();
                _editarForn.Perfil.Endereco = BoxEndForn.Text.Trim();
                _editarForn.Perfil.Complemento = BoxComplForn.Text.Trim();
                _editarForn.Perfil.Categoria = CBCategoria.Text.Trim();
                _editarForn.Perfil.Transporte = RBSimForn.Checked;

                if (!string.IsNullOrWhiteSpace(BoxSenhaForn.Text.Trim()))
                {
                    if (BoxSenhaForn.Text.Trim() == BoxConfirmForn.Text.Trim())
                    {
                        _editarForn.Perfil.Senha = Hashing.Criptografar(BoxSenhaForn.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show("A nova senha e a confirmação não coincidem.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                Perfil editarPerfil = new Perfil();
                editarPerfil.EditarPerfilForn(_editarForn.Perfil);

                this.Hide();
                TelaUsuarioForn telaUsuario = new TelaUsuarioForn(_editarForn.Perfil.IdLogin);
                telaUsuario.Show();
            }
            else
            {
                string cnpj = BoxCNPJForn.Text.Trim().Replace(".", "").Replace("/", "").Replace("-", "");
                string razaoSocial = BoxRazaoForn.Text.Trim();
                string nomeFantasia = BoxNomeForn.Text.Trim();
                string email = BoxEmailForn.Text.Trim();
                string senha = BoxSenhaForn.Text.Trim();
                string confirmSenha = BoxConfirmForn.Text.Trim();
                string telefone = BoxTelForn.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "");
                string cep = BoxCEPForn.Text.Trim().Replace(".", "").Replace("-", "");
                string numero = BoxNumForn.Text.Trim();
                string endereco = BoxEndForn.Text.Trim();
                string complemento = BoxComplForn.Text.Trim();
                string categoria = CBCategoria.Text.Trim();
                bool entrega = false;

                if (RBSimForn.Checked == true)
                {
                    entrega = true;
                }

                CadastroFornModel cadastroFornModel = new CadastroFornModel(cnpj, razaoSocial, nomeFantasia,
                email, senha, confirmSenha, telefone, cep, numero, endereco, complemento, entrega, categoria);

                List<string> erros = new List<string>();
                erros = cadastroFornModel.Validar();

                txtCNPJFornErro.Text = "";
                txtRazaoFornErro.Text = "";
                txtTelFornErro.Text = "";
                txtEmailFornErro.Text = "";
                txtSenhaFornErro.Text = "";
                txtConfirmFornErro.Text = "";
                txtCEPFornErro.Text = "";
                txtNumFornErro.Text = "";
                txtEndFornErro.Text = "";
                txtCategoriaErro.Text = "";

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
                        else if (erro.Contains("Categoria"))
                        {
                            txtCategoriaErro.Text = "* " + erro;
                        }
                    }
                }
                else
                {
                    try
                    {
                        LoginUsuario loginExistente = new LoginUsuario();
                        
                        bool exist = loginExistente.BuscaLoginExistente(email);

                        if(!exist)
                        {
                            this.Hide();
                            Conexao conexao = new Conexao();

                            PerfilForn novoPerfil = new PerfilForn
                            {
                                CNPJ = cnpj,
                                RazaoSocial = razaoSocial,
                                NomeFantasia = nomeFantasia,
                                Email = email,
                                Senha = Hashing.Criptografar(senha),
                                Telefone = telefone,
                                CEP = cep,
                                Numero = numero,
                                Endereco = endereco,
                                Complemento = complemento,
                                Transporte = entrega,
                                Categoria = categoria
                            };

                            Perfil perfil = new Perfil();

                            perfil.InserirPerfilForn(novoPerfil);

                            MessageBox.Show("Cadastro de fornecedor realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            new TelaLogin().Show();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possivel cadastrar este usuário", "Usuário ja cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            this.Hide();
                            TelaLogin telaLogin = new TelaLogin();
                            telaLogin.Show();
                        }

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Erro ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possivel cadastrar este usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.Hide();
                        TelaLogin telaLogin = new TelaLogin();
                        telaLogin.Show();
                    }
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
            BoxCEPForn.Text = editarForn.Perfil.CEP;
            BoxNumForn.Text = editarForn.Perfil.Numero;
            BoxEndForn.Text = editarForn.Perfil.Endereco;
            BoxComplForn.Text = editarForn.Perfil.Complemento;
            CBCategoria.SelectedItem = editarForn.Perfil.Categoria;

            BoxSenhaForn.Text = Hashing.Descriptografar(editarForn.Perfil.Senha);
            BoxConfirmForn.Text = Hashing.Descriptografar(editarForn.Perfil.Senha);

            if (editarForn.Perfil.Transporte)
            {
                RBSimForn.Checked = true;
            }
            else
            {
                RBNaoForn.Checked = true;
            }
        }

        private void BoxCNPJForn_TextChanged(object sender, System.EventArgs e)
        {
            MascaraUtil.AplicarMascaraCNPJ(BoxCNPJForn);
        }

        private void BoxTelForn_TextChanged(object sender, System.EventArgs e)
        {
            MascaraUtil.AplicarMascaraTelefone(BoxTelForn);
        }

        private void BoxCEPForn_TextChanged(object sender, System.EventArgs e)
        {
            MascaraUtil.AplicarMascaraCEP(BoxCEPForn);
        }
    }
}

