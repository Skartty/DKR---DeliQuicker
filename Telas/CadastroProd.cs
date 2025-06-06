using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class CadastroProd : Form
    {
        public CadastroProd()
        {
            InitializeComponent();
        }

        private void iconPerfilForn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaUsuarioForn telaUsuarioForn = new TelaUsuarioForn(2);
            telaUsuarioForn.Show();
        }

        private void txtAddImgProd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione uma imagem do produto";
                openFileDialog.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoImagem = openFileDialog.FileName;

                    ImgAddProd.Image = Image.FromFile(caminhoImagem);
                    ImgAddProd.SizeMode = PictureBoxSizeMode.Zoom; 
                }
            }
        }
    }
}
