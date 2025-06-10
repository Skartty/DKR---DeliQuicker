namespace ProjetoDKR.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public int IdForn { get; set; }
        public string NomeProduto { get; set; }
        public string Categoria { get; set; }
        public string Validade { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; } = null;
    }
}
