using Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerador_de_Folha_de_Pagamento_Desktop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Process.GetProcessesByName("Gerador_de_Folha_de_Pagamento_Desktop").Length > 0 && Process.GetProcessesByName("Gerador_de_Folha_de_Pagamento_Desktop").Length <= 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }

            else
            {
                MessageBox.Show("Uma janela do programa já esta aberta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
