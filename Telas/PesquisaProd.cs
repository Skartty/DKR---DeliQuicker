using ProjetoDKR.Components;
using ProjetoDKR.Entidades;
using ProjetoDKR.Model;
using ProjetoDKR.MySQL;
using ProjetoDKR.Utilidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class PesquisaProd : Form
    {
        private List<Produto> _produtoMercado;
        private List<Produto> _produtoHortifrutti;
        private List<Produto> _produtoRestaurante;
        private List<Produto> _produtoFornecedor;
        private List<Produto> listaProd;

        private readonly PerfilForn _perfilForn;
        private readonly PerfilCons _perfilCons;

        private Produtos produtosSql;

        public PesquisaProd(string tipo, PerfilForn perfilForn = null, PerfilCons perfilCons = null)
        {
            _perfilCons = perfilCons;
            _perfilForn = perfilForn;

            InitializeComponent();

            produtosSql = new Produtos();

            _produtoMercado = new List<Produto>();
            _produtoHortifrutti = new List<Produto>();
            _produtoRestaurante = new List<Produto>();
            _produtoFornecedor = new List<Produto>();

            if (!string.IsNullOrEmpty(tipo))
            {
                try
                {
                    if (tipo == "Consumidor")
                    {
                        listaProd = produtosSql.BuscarListaProdutos();

                        _produtoMercado = listaProd.Where(w => w.Categoria == "Mercado").ToList();
                        _produtoHortifrutti = listaProd.Where(w => w.Categoria == "Hortifrutti").ToList();
                        _produtoRestaurante = listaProd.Where(w => w.Categoria == "Restaurante").ToList();

                        CarregarProduto(listaProd);
                    }
                    else if (tipo == "Fornecedor")
                    {
                        txtFiltroMercado.Visible = false;
                        txtFiltroHortifrutti.Visible = false;
                        txtFiltroRestaurante.Text = "   Produtos";
                        txtFiltroRestaurante.Enabled = false;

                        _produtoFornecedor = produtosSql.BuscarListaProdutoForn(perfilForn.Id);
                        listaProd = _produtoFornecedor;

                        CarregarProduto(_produtoFornecedor);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro de argumentos passados em parametros. \nERRO: {ex.Message}");
                }
                catch (Exception ex)
                {
                    int idPerfil = 0;
                    string nomePerfil = string.Empty;
                    if (_perfilCons != null)
                    {
                        idPerfil = _perfilCons.Id;
                        nomePerfil = _perfilCons.Nome;
                    }
                    else if (_perfilForn != null)
                    {
                        idPerfil = _perfilForn.Id;
                        nomePerfil = _perfilForn.RazaoSocial;
                    }

                    DialogResult resultado = MessageBox.Show(
                        "Não foi possível carregar produtos",
                        "Erro interno!",
                        MessageBoxButtons.OK
                        );
                    
                    Console.WriteLine($"Não foi possível carregar produtos para o perfil {idPerfil} - {nomePerfil}. \nERRO: {ex.Message}");
                }
                
            }
        }

        private void CarregarProduto(List<Produto> listProd)
        {
            List<ProdutoModel> produtoModels = new List<ProdutoModel>();

            listProd.ForEach(f => produtoModels.Add(new ProdutoModel
            {
                Descricao = f.Descricao,
                NomeProduto = f.NomeProduto,
                Quantidade = f.Quantidade,
                Imagem = f.Imagem,
            }));

            painelProd.Controls.Clear();

            int y = 26;

            foreach (ProdutoModel produto in produtoModels)
            {
                var item = new ProdutoItem();

                item.Preencher(produto);
                item.Location = new System.Drawing.Point(27, y);
                item.Width = painelProd.Width -20;
                item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                painelProd.Controls.Add(item);
                y += item.Height + 10;
            }
        }        

        private void IconBuscaProd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(BoxPesquisaProd.Text))
            {
                List<Produto> listaRef = new List<Produto>();
                if (_perfilForn != null && _perfilForn.Id != 0)
                {
                    List<Produto> listaForn = new List<Produto>();
                    listaForn = produtosSql.BuscarListaProdutoForn(_perfilForn.Id);
                    listaRef = listaForn.Where(w => RemoverAcentos.Remover(w.NomeProduto.ToLower()).Contains(RemoverAcentos.Remover(BoxPesquisaProd.Text.ToLower()).Trim())).ToList();
                }
                else
                {
                    listaRef = produtosSql.BuscarListaProdutos(RemoverAcentos.Remover(BoxPesquisaProd.Text.Trim()));
                }

                if(listaRef.Count == 0)
                {
                    DialogResult resultado = MessageBox.Show(
                    "Produto não localizado",
                    "Busca",
                    MessageBoxButtons.OK
                    );

                    CarregarProduto(listaProd);
                }
                else
                {
                    CarregarProduto(listaRef);
                }
            }
            else
            {
                CarregarProduto(listaProd);
            }

            BoxPesquisaProd.Text = string.Empty;

            txtFiltroMercado.ForeColor = System.Drawing.Color.Black;
            txtFiltroRestaurante.ForeColor = System.Drawing.Color.Black;
            txtFiltroHortifrutti.ForeColor = System.Drawing.Color.Black;
        }

        private void txtFiltroMercado_Click(object sender, EventArgs e)
        {
            txtFiltroMercado.ForeColor = System.Drawing.Color.OrangeRed;
            txtFiltroRestaurante.ForeColor = System.Drawing.Color.Black;
            txtFiltroHortifrutti.ForeColor = System.Drawing.Color.Black;

            CarregarProduto(_produtoMercado);
        }

        private void txtFiltroRestaurante_Click(object sender, EventArgs e)
        {
            txtFiltroMercado.ForeColor = System.Drawing.Color.Black;
            txtFiltroRestaurante.ForeColor = System.Drawing.Color.OrangeRed;
            txtFiltroHortifrutti.ForeColor = System.Drawing.Color.Black;

            CarregarProduto(_produtoRestaurante);
        }

        private void txtFiltroHortifrutti_Click(object sender, EventArgs e)
        {
            txtFiltroMercado.ForeColor = System.Drawing.Color.Black;
            txtFiltroRestaurante.ForeColor = System.Drawing.Color.Black;
            txtFiltroHortifrutti.ForeColor = System.Drawing.Color.OrangeRed;

            CarregarProduto(_produtoHortifrutti);
        }

        private void iconBusca_Click(object sender, EventArgs e)
        {
            CarregarProduto(listaProd);
            txtFiltroMercado.ForeColor = System.Drawing.Color.Black;
            txtFiltroRestaurante.ForeColor = System.Drawing.Color.Black;
            txtFiltroHortifrutti.ForeColor = System.Drawing.Color.Black;
        }

        private void iconPerfilProd_Click(object sender, EventArgs e)
        {
            if (_perfilCons != null)
            {
                this.Hide();
                TelaUsuarioCons telaUsuarioCons = new TelaUsuarioCons(_perfilCons.IdLogin);
                telaUsuarioCons.Show();
            }
            else if (_perfilForn != null)
            {
                this.Hide();
                TelaUsuarioForn telaUsuarioForn = new TelaUsuarioForn(_perfilForn.IdLogin);
                telaUsuarioForn.Show();
            }
        }

        private void BoxPesquisaProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IconBuscaProd_Click(sender, e);
                e.SuppressKeyPress = true; 
            }
        }
    }
}
