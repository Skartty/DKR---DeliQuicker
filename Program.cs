using DeliQuicker.Utilidades;
using System;
using System.Configuration;
using System.Windows.Forms;


namespace ProjetoDKR
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connStr = ConfigurationManager.ConnectionStrings["projeto_dkr"].ConnectionString;
            BancoInitializer.InicializarBanco(connStr);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IntroAnimada());
        }
    }
}
