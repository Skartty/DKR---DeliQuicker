using System.Collections.Generic;
using System.Linq;

namespace ProjetoDKR.Model
{
    public class CadastroFornModel
    {
        public CadastroFornModel(string cnpj, string razaoSocial, string nomeFantasia,
            string email, string senha, string confirmSenha, string telefone, string cep,
            string numero, string endereco, string complemento, bool entrega, string categoria)
        {
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Email = email;
            Senha = senha;
            ConfirmSenha = confirmSenha;
            Telefone = telefone;
            CEP = cep;
            Numero = numero;
            Endereco = endereco;
            Complemento = complemento;
            Entrega = entrega;
            Categoria = categoria;
        }

        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmSenha { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public bool Entrega { get; set; }
        public string Categoria { get; set; }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(CNPJ))
                erros.Add("CNPJ não preenchido");
            else if (!CNPJ.All(char.IsDigit))
                erros.Add("CNPJ deve conter apenas números");

            if (string.IsNullOrWhiteSpace(RazaoSocial))
                erros.Add("Razão Social não preenchida");

            if (string.IsNullOrWhiteSpace(Email))
                erros.Add("Email não preenchido");

            if (string.IsNullOrWhiteSpace(Senha))
                erros.Add("Senha não preenchida");

            if (string.IsNullOrWhiteSpace(ConfirmSenha))
                erros.Add("Confirmação de senha não preenchida");

            if (Senha != ConfirmSenha)
                erros.Add("Senha e confirmação não coincidem");

            if (string.IsNullOrWhiteSpace(Telefone))
                erros.Add("Telefone não preenchido");
            else if (!Telefone.All(char.IsDigit))
                erros.Add("Telefone deve conter apenas números");

            if (string.IsNullOrWhiteSpace(CEP))
                erros.Add("CEP não preenchido");
            else if (!CEP.All(char.IsDigit))
                erros.Add("CEP deve conter apenas números");

            if (string.IsNullOrWhiteSpace(Numero))
                erros.Add("Não preenchido");
            else if (!Numero.All(char.IsDigit))
                erros.Add("Numero deve conter apenas números");

            if (string.IsNullOrWhiteSpace(Endereco))
                erros.Add("Endereço não preenchido");

            if (string.IsNullOrWhiteSpace(Categoria))
                erros.Add("Categoria não preenchida");

            return erros;
        }

    }
}

