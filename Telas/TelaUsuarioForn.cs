using ProjetoDKR.Entidades;
using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class TelaUsuarioForn : Form
    {
        private PerfilForn _perfilForn;
        private Perfil _perfil;
        public TelaUsuarioForn(int id)
        {
            InitializeComponent();
            _perfil = new Perfil();

            _perfilForn = _perfil.BuscarPerfilForn(id);
            CarregarDadosPerfil(_perfilForn);
        }
        private void CarregarDadosPerfil(PerfilForn perfilForn)
        {
            txtNomeForn.Text = perfilForn.RazaoSocial;
            txtCNPJForn2.Text = perfilForn.CNPJ;
            txtNomeFan2.Text = perfilForn.NomeFantasia;
            txtEmailForn2.Text = perfilForn.Email;
            txtSenhaForn2.Text = perfilForn.Senha;
            txtTelForn2.Text = perfilForn.Telefone;
            txtCEPForn2.Text = perfilForn.CEP;
            txtNumForn2.Text = perfilForn.Numero;
            txtEndForn2.Text = perfilForn.Endereco;
            txtComplForn2.Text = perfilForn.Complemento;
            txtCatForn2.Text = perfilForn.Categoria;
            //Ver como arrumar o combobox categoria
            if (perfilForn.Transporte)
            {
                RBSimForn1.Checked = true;
            }
            else
            {
                RBNaoForn1.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
            //chamar a tela de pesquisa de produtos
        }

        private void btnCadastrarProd_Click(object sender, EventArgs e)
        {
            //chamar a tela de cadastrar produtos
        }

        private void iconBuscaForn_Click(object sender, EventArgs e)
        {
            //chamar a tela de pesquisa de produtos geral
        }
    }
}
