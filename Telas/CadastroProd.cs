﻿using ProjetoDKR.Entidades;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class CadastroProd : Form
    {
        private readonly int _idForn;
        public CadastroProd(int idForn)
        {
            InitializeComponent();
            _idForn = idForn;
        }

        private void iconPerfilForn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaUsuarioForn telaUsuarioForn = new TelaUsuarioForn(_idForn);
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

            // Aqui você pode adicionar a lógica para salvar o novo produto no banco de dados ou em outro local
        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaUsuarioForn telaUsuarioForn = new TelaUsuarioForn(_idForn);
            telaUsuarioForn.Show();
        }

        private void BoxValidadeProd_TextChanged(object sender, EventArgs e)
        {
            MascaraUtil.AplicarMascaraData(BoxValidadeProd);
        }
    }
}
