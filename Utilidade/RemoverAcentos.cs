using System.Text;
using System.Text.RegularExpressions;

namespace ProjetoDKR.Utilidade
{
    public static class RemoverAcentos
    {
        public static string Remover(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return texto;
            }

            texto = texto.Normalize(NormalizationForm.FormD);
            return Regex.Replace(texto, @"\p{Mn}", string.Empty);
        }
    }
}
