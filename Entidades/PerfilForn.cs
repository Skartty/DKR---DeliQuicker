namespace ProjetoDKR.Entidades
{
    public class PerfilForn
    {
        public int Id { get; set; }
        public int IdLogin { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Categoria { get; set; }
        public bool Transporte { get; set; }

        public Model.CadastroFornModel CadastroFornModel
        {
            get => default;
            set
            {
            }
        }
    }
}
