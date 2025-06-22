using System.Text.RegularExpressions;
using System.Windows.Forms;

public static class MascaraUtil
{
    public static void AplicarMascaraCEP(TextBox textBox)
    {
        string numeros = Regex.Replace(textBox.Text, @"\D", ""); 
        if (numeros.Length > 8)
            numeros = numeros.Substring(0, 8); 

        if (numeros.Length >= 6)
        {
            textBox.Text = numeros.Insert(5, "-");
        }
        else
        {
            textBox.Text = numeros;
        }

        textBox.SelectionStart = textBox.Text.Length; 
    }

    public static void AplicarMascaraCPF(TextBox textBox)
    {
        textBox.MaxLength = 14;
        textBox.Text = AplicarFormato(textBox.Text, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
    }

    public static void AplicarMascaraCNPJ(TextBox textBox)
    {
        textBox.MaxLength = 18;
        textBox.Text = AplicarFormato(textBox.Text, @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5");
    }

    public static void AplicarMascaraData(TextBox textBox)
    {
        textBox.MaxLength = 10;
        textBox.Text = AplicarFormato(textBox.Text, @"(\d{2})(\d{2})(\d{4})", "$1/$2/$3");
    }

    public static void AplicarMascaraTelefone(TextBox textBox)
    {
        string somenteNumeros = Regex.Replace(textBox.Text, @"[^\d]", "");
        if (somenteNumeros.Length == 11)
        {
            textBox.MaxLength = 14;
            textBox.Text = AplicarFormato(somenteNumeros, @"(\d{2})(\d{5})(\d{4})", "($1)$2-$3");
        }
        else if (somenteNumeros.Length == 11)
        {
            textBox.MaxLength = 13;
            textBox.Text = AplicarFormato(somenteNumeros, @"(\d{2})(\d{4})(\d{4})", "($1)$2-$3");
        }
    }

    private static string AplicarFormato(string texto, string padrao, string mascara)
    {
        string numeros = Regex.Replace(texto, @"[^\d]", "");
        if (Regex.IsMatch(numeros, padrao))
        {
            return Regex.Replace(numeros, padrao, mascara);
        }
        return texto;
    }
}
