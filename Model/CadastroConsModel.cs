using System.Collections.Generic;
using System.Linq;

namespace ProjetoDKR.Model
{
    public class CadastroConsModel
    {
        public CadastroConsModel(string nome, string cnpj, string telefone, string email,
            string senha, string confirmSenha, string cep, string numero, string endereco,
            string complemento, bool entrega)
        {
            Nome = nome;
            CNPJ = cnpj;
            Telefone = telefone;
            Email = email;
            Senha = senha;
            ConfirmSenha = confirmSenha;
            CEP = cep;
            Numero = numero;
            Endereco = endereco;
            Complemento = complemento;
            Entrega = entrega;
        }

        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmSenha { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public bool Entrega { get; set; }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(Nome)) 
                erros.Add("Nome não preenchido");

            if (string.IsNullOrWhiteSpace(CNPJ)) 
                erros.Add("CNPJ não preenchido");
            else if (!Telefone.All(char.IsDigit))
                erros.Add("CNPJ deve conter apenas números");

            if (string.IsNullOrWhiteSpace(Telefone))
                erros.Add("Telefone não preenchido");
            else if (!Telefone.All(char.IsDigit))
                erros.Add("Telefone deve conter apenas números");

            if (string.IsNullOrWhiteSpace(Email))
                erros.Add("Email não preenchido");

            if (string.IsNullOrWhiteSpace(Senha))
                erros.Add("Senha não preenchida");

            if (string.IsNullOrWhiteSpace(ConfirmSenha))
                erros.Add("Confirmação de senha não preenchida");

            if (Senha != ConfirmSenha)
                erros.Add("Senha e confirmação não coincidem");

            if (string.IsNullOrWhiteSpace(CEP))
                erros.Add("CEP não preenchido");
            else if (!CEP.All(char.IsDigit))
                erros.Add("CEP deve conter apenas números");

            if (string.IsNullOrWhiteSpace(Numero))
                erros.Add("Numero não preenchido");
            else if (!Numero.All(char.IsDigit))
                erros.Add("Numero deve conter apenas números");

            if (string.IsNullOrWhiteSpace(Endereco))
                erros.Add("Endereço não preenchido");

            return erros;
        }

    }

}
