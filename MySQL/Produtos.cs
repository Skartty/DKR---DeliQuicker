using ProjetoDKR.Entidades;
using ProjetoDKR.Utilidade;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoDKR.MySQL
{
    public class Produtos
    {
        private List<Produto> produtos;

        public Produtos()
        {
            produtos = new List<Produto>()
            {
                new Produto { Id = 1, IdForn = 1, Categoria = "Mercado", NomeProduto = "Arroz Integral 1kg", Validade = "2025-01-10", Quantidade = 15, Descricao = "Pacote de arroz integral de 1kg", Imagem = "arroz.jpg" },
                new Produto { Id = 2, IdForn = 1, Categoria = "Mercado", NomeProduto = "Feijão Carioca", Validade = "2024-12-15", Quantidade = 20, Descricao = "Feijão carioca tipo 1", Imagem = "feijao.jpg" },
                new Produto { Id = 3, IdForn = 1, Categoria = "Mercado", NomeProduto = "Pão Francês", Validade = "2025-06-05", Quantidade = 100, Descricao = "Pão francês fresco de padaria", Imagem = "pao.jpg" },
                new Produto { Id = 4, IdForn = 2, Categoria = "Mercado", NomeProduto = "Alface Crespa", Validade = "2025-06-08", Quantidade = 30, Descricao = "Alface fresca, direto do hortifrutti", Imagem = "alface.jpg" },
                new Produto { Id = 5, IdForn = 2, Categoria = "Mercado", NomeProduto = "Tomate Italiano", Validade = "2025-06-06", Quantidade = 25, Descricao = "Tomates maduros para salada ou molho", Imagem = "tomate.jpg" },
                new Produto { Id = 6, IdForn = 2, Categoria = "Mercado", NomeProduto = "Frango Congelado", Validade = "2025-06-04", Quantidade = 10, Descricao = "Frango congelado", Imagem = "frango.jpg" },
                new Produto { Id = 7, IdForn = 2, Categoria = "Mercado", NomeProduto = "Yakissoba Congelado", Validade = "2025-06-04", Quantidade = 12, Descricao = "Prato pronto de macarrão ao molho de Shoyu", Imagem = "macarrao.jpg" },
                new Produto { Id = 8, IdForn = 2, Categoria = "Mercado", NomeProduto = "Banana Prata", Validade = "2025-06-09", Quantidade = 40, Descricao = "Cacho de banana prata madura", Imagem = "banana.jpg" },
                new Produto { Id = 9, IdForn = 2, Categoria = "Mercado", NomeProduto = "Leite Integral 1L", Validade = "2025-07-01", Quantidade = 18, Descricao = "Leite de caixinha integral", Imagem = "leite.jpg" },
                new Produto { Id = 10, IdForn = 2, Categoria = "Mercado", NomeProduto = "Sopa de Legumes (congelada)", Validade = "2025-06-20", Quantidade = 8, Descricao = "Sopa caseira congelada pronta para consumo", Imagem = "sopa.jpg" },
                new Produto { Id = 11, Categoria = "Hortifrutti", NomeProduto = "Banana Nanica", Validade = "2025-06-07", Quantidade = 30, Descricao = "Cacho de bananas maduras, ideal para consumo imediato", Imagem = "banana_nanica.jpg" },
                new Produto { Id = 12, Categoria = "Hortifrutti", NomeProduto = "Maçã Fuji", Validade = "2025-06-10", Quantidade = 20, Descricao = "Maçãs vermelhas e crocantes, excelente para lanche", Imagem = "maca_fuji.jpg" },
                new Produto { Id = 13, Categoria = "Hortifrutti", NomeProduto = "Alface Americana", Validade = "2025-06-05", Quantidade = 15, Descricao = "Alface crocante ideal para saladas", Imagem = "alface.jpg" },
                new Produto { Id = 14, Categoria = "Hortifrutti", NomeProduto = "Cenoura", Validade = "2025-06-15", Quantidade = 25, Descricao = "Cenouras frescas, boas para sucos ou cozimento", Imagem = "cenoura.jpg" },
                new Produto { Id = 15, Categoria = "Hortifrutti", NomeProduto = "Tomate Italiano", Validade = "2025-06-06", Quantidade = 22, Descricao = "Tomate ideal para molhos e saladas", Imagem = "tomate.jpg" },
                new Produto { Id = 16, Categoria = "Hortifrutti", NomeProduto = "Cebola Roxa", Validade = "2025-06-12", Quantidade = 18, Descricao = "Cebola roxa fresca, ótima para refogados e saladas", Imagem = "cebola_roxa.jpg" },
                new Produto { Id = 17, Categoria = "Hortifrutti", NomeProduto = "Abobrinha", Validade = "2025-06-08", Quantidade = 14, Descricao = "Abobrinha verde fresca, ideal para grelhar ou refogar", Imagem = "abobrinha.jpg" },
                new Produto { Id = 18, Categoria = "Hortifrutti", NomeProduto = "Batata Doce", Validade = "2025-06-20", Quantidade = 19, Descricao = "Fonte de energia saudável, ideal para assar", Imagem = "batata_doce.jpg" },
                new Produto { Id = 19, Categoria = "Hortifrutti", NomeProduto = "Repolho Roxo", Validade = "2025-06-09", Quantidade = 10, Descricao = "Repolho crocante, bom para saladas e refogados", Imagem = "repolho_roxo.jpg" },
                new Produto { Id = 20, Categoria = "Hortifrutti", NomeProduto = "Manga Palmer", Validade = "2025-06-11", Quantidade = 16, Descricao = "Mangas doces e suculentas, prontas para consumo", Imagem = "manga.jpg" },
                new Produto { Id = 21, Categoria = "Restaurante", NomeProduto = "Feijoada Completa", Validade = "2025-06-05", Quantidade = 5, Descricao = "Feijoada com arroz, farofa, couve e laranja", Imagem = "feijoada.jpg" },
                new Produto { Id = 22, Categoria = "Restaurante", NomeProduto = "Escondidinho de Carne Seca", Validade = "2025-06-04", Quantidade = 8, Descricao = "Escondidinho de mandioca com carne seca desfiada", Imagem = "escondidinho.jpg" },
                new Produto { Id = 23, Categoria = "Restaurante", NomeProduto = "Frango à Parmegiana", Validade = "2025-06-06", Quantidade = 10, Descricao = "Filé de frango empanado com molho de tomate e queijo", Imagem = "parmegiana.jpg" },
                new Produto { Id = 24, Categoria = "Restaurante", NomeProduto = "Lasanha Bolonhesa", Validade = "2025-06-07", Quantidade = 6, Descricao = "Lasanha de carne com molho à bolonhesa", Imagem = "lasanha.jpg" },
                new Produto { Id = 25, Categoria = "Restaurante", NomeProduto = "Strogonoff de Frango", Validade = "2025-06-05", Quantidade = 12, Descricao = "Strogonoff acompanhado de arroz branco e batata palha", Imagem = "strogonoff.jpg" },
                new Produto { Id = 26, Categoria = "Restaurante", NomeProduto = "Quiche de Alho-Poró", Validade = "2025-06-03", Quantidade = 4, Descricao = "Quiche artesanal de alho-poró", Imagem = "quiche.jpg" },
                new Produto { Id = 27, Categoria = "Restaurante", NomeProduto = "Tilápia Grelhada", Validade = "2025-06-06", Quantidade = 7, Descricao = "Filé de tilápia grelhado com legumes assados", Imagem = "tilapia.jpg" },
                new Produto { Id = 28, Categoria = "Restaurante", NomeProduto = "Torta de Frango", Validade = "2025-06-08", Quantidade = 9, Descricao = "Torta salgada recheada com frango desfiado e catupiry", Imagem = "torta_frango.jpg" },
                new Produto { Id = 29, Categoria = "Restaurante", NomeProduto = "Salada Caesar", Validade = "2025-06-03", Quantidade = 10, Descricao = "Salada de alface, frango grelhado, parmesão e croutons", Imagem = "salada_caesar.jpg" },
                new Produto { Id = 30, Categoria = "Restaurante", NomeProduto = "Panqueca de Espinafre", Validade = "2025-06-04", Quantidade = 6, Descricao = "Panqueca recheada com espinafre e ricota", Imagem = "panqueca.jpg" }
            };
        }

        public List<Produto> BuscarListaProdutos(string referencia = null)
        {
            if (string.IsNullOrEmpty(referencia))
            {
                return produtos;
            }
            else
            {
                referencia = RemoverAcentos.Remover(referencia).ToLower();
                var retorno = produtos.Where(w => RemoverAcentos.Remover(w.NomeProduto.ToLower()).Contains(referencia)).ToList();
                return retorno;
            }
        }


        public List<Produto> BuscarListaProdutoForn(int idForn)
        {
            List<Produto> produtosForn = new List<Produto>();
            produtosForn.AddRange(produtos.Where(w => w.IdForn == idForn).ToList());

            return produtosForn;
        }
    }
}
