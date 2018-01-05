using System;
using System.Windows.Forms;
using Sklep.Csv;
using MainMenu = Sklep.Forms.MainMenu;

namespace Sklep
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CsvDataService.Instance.Load();

            Application.Run(new MainMenu());
        }
    }
}