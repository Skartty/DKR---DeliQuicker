using DeliQuicker.Utilidades;
using MySql.Data.MySqlClient;
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
                _editarCons.Perfil.Nome = BoxNomeOng.Text;
                _editarCons.Perfil.CNPJ = BoxCNPJOng.Text.Replace(".", "").Replace("/", "").Replace("-", "");
                _editarCons.Perfil.Telefone = new string(BoxTelOng.Text.Where(char.IsDigit).ToArray());
                _editarCons.Perfil.Email = BoxEmailOng.Text;
                _editarCons.Perfil.CEP = BoxCEPOng.Text.Replace(".", "").Replace("-", "");
                _editarCons.Perfil.Numero = BoxNumOng.Text;
                _editarCons.Perfil.Endereco = BoxEndOng.Text;
                _editarCons.Perfil.Complemento = BoxComplOng.Text;
                _editarCons.Perfil.Transporte = RBSimOng.Checked;

                if (!string.IsNullOrWhiteSpace(BoxSenhaOng.Text))
                {
                    if (BoxSenhaOng.Text == BoxConfirmOng.Text)
                    {
                        _editarCons.Perfil.Senha = Hashing.HashPassword(BoxSenhaOng.Text);
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
                        string senhaHasheada = Hashing.HashPassword(senha);

                        this.Hide();
                        Conexao conexao = new Conexao();

                        using (MySqlConnection conn = conexao.Abrir())
                        {
                            string sqlLogin = @"INSERT INTO login (usuario, senha, tipo)
                                                VALUES (@usuario, @senha, 'Consumidor');
                                                SELECT LAST_INSERT_ID();";

                            int idLogin;
                            using (MySqlCommand cmdLogin = new MySqlCommand(sqlLogin, conn))
                            {
                                cmdLogin.Parameters.AddWithValue("@usuario", email);
                                cmdLogin.Parameters.AddWithValue("@senha", senhaHasheada);
                                idLogin = Convert.ToInt32(cmdLogin.ExecuteScalar());
                            }

                            string sqlPerfil = @"INSERT INTO perfil_cons 
                                (id_login, nome, cnpj, email, senha, telefone, cep, numero, endereco, complemento, transporte)
                                VALUES
                                (@idLogin, @nome, @cnpj, @email, @senha, @telefone, @cep, @numero, @endereco, @complemento, @transporte);";

                            using (MySqlCommand cmdPerfil = new MySqlCommand(sqlPerfil, conn))
                            {
                                cmdPerfil.Parameters.AddWithValue("@idLogin", idLogin);
                                cmdPerfil.Parameters.AddWithValue("@nome", nome);
                                cmdPerfil.Parameters.AddWithValue("@cnpj", cnpj);
                                cmdPerfil.Parameters.AddWithValue("@email", email);
                                cmdPerfil.Parameters.AddWithValue("@senha", senhaHasheada);
                                cmdPerfil.Parameters.AddWithValue("@telefone", telefone);
                                cmdPerfil.Parameters.AddWithValue("@cep", cep);
                                cmdPerfil.Parameters.AddWithValue("@numero", numero);
                                cmdPerfil.Parameters.AddWithValue("@endereco", endereco);
                                cmdPerfil.Parameters.AddWithValue("@complemento", complemento);
                                cmdPerfil.Parameters.AddWithValue("@transporte", entrega);

                                cmdPerfil.ExecuteNonQuery();
                            }
                        }

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

            BoxSenhaOng.Text = "";
            BoxConfirmOng.Text = "";

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
