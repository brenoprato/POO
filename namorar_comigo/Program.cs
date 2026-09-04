using System;
using System.Windows.Forms;

namespace namorar_comigo
{
    internal static class Program
    {
        // Ponto de entrada principal para o aplicativo
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}