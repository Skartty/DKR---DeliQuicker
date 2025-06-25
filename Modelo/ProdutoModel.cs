
namespace ProjetoDKR.Model
{
    public class ProdutoModel
    {
        public string NomeProduto { get; set; }
        public string Validade { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }

        public Components.ProdutoItem ProdutoItem
        {
            get => default;
            set
            {
            }
        }
    }
}
