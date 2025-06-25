using ProjetoDKR.Model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetoDKR.Components
{
    public partial class ProdutoItem : UserControl
    {
        public ProdutoItem()
        {
            InitializeComponent();
        }

        public void Preencher(ProdutoModel produto)
        {
            txtProd.Text = produto.NomeProduto;

            if (!string.IsNullOrEmpty(txtDescricao.Text) && produto.Descricao.Length > 35)
            {
                txtDescricao.Text = produto.Descricao.Substring(0,35) + "...";
            }
            else
            {
                txtDescricao.Text = produto.Descricao;
            }
                        
            txtQuant.Text = produto.Quantidade.ToString("D2");

            try
            {
                if (produto.Imagem != null && produto.Imagem.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(produto.Imagem))
                    {
                        ImgProd.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
            }
        }
    }
}
