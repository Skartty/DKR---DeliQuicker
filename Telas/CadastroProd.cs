﻿using ProjetoDKR.Entidades;
using ProjetoDKR.MySQL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class CadastroProd : Form
    {
        private readonly int _idForn;
        private readonly int _idLogin;
        public CadastroProd(int idLogin)
        {
            InitializeComponent();
            Perfil perfilForn = new Perfil();
            _idForn = perfilForn.BuscarPerfilForn(idLogin).Id;
            _idLogin = idLogin;
        }

        public TelaUsuarioForn TelaUsuarioForn
        {
            get => default;
            set
            {
            }
        }

        private void iconPerfilForn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaUsuarioForn telaUsuarioForn = new TelaUsuarioForn(_idLogin);
            telaUsuarioForn.Show();
        }

        private void txtAddImgProd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione uma imagem do produto";
                openFileDialog.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoImagem = openFileDialog.FileName;

                    ImgAddProd.Image = Image.FromFile(caminhoImagem);
                    ImgAddProd.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void txtSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeProd.Text) || string.IsNullOrWhiteSpace(BoxValidadeProd.Text) ||
                string.IsNullOrWhiteSpace(BoxQtdProd.Text) || CBCategoriaProd.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Produto novoProduto = new Produto
                {
                    IdForn = _idForn,
                    Categoria = CBCategoriaProd.Text,
                    NomeProduto = BoxNomeProd.Text,
                    Validade = BoxValidadeProd.Text,
                    Quantidade = Convert.ToInt32(BoxQtdProd.Text),
                    Descricao = BoxDescricaoProd.Text
                };

                if (ImgAddProd.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ImgAddProd.Image.Save(ms, ImgAddProd.Image.RawFormat);
                        novoProduto.Imagem = ms.ToArray();
                    }
                }
                Produtos prod = new Produtos();
                prod.InserirProduto(novoProduto);

                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                TelaUsuarioForn telaUsuarioForn = new TelaUsuarioForn(_idLogin);
                telaUsuarioForn.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar o produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }                    

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaUsuarioForn telaUsuarioForn = new TelaUsuarioForn(_idLogin);
            telaUsuarioForn.Show();
        }

        private void BoxValidadeProd_TextChanged(object sender, EventArgs e)
        {
            MascaraUtil.AplicarMascaraData(BoxValidadeProd);
        }
    }
}
