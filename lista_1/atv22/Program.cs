using System;
using System.Windows.Forms;

namespace MyApp
{
    public class Form1 : Form
    {
        private TextBox txtTexto;
        private Button btnContar;
        private Label lblResultado;

        public Form1()
        {
            txtTexto = new TextBox { Left = 20, Top = 20, Width = 200 };
            btnContar = new Button { Text = "Contar", Left = 20, Top = 50, Width = 100 };
            lblResultado = new Label { Text = "", Left = 20, Top = 90, AutoSize = true };

            btnContar.Click += btnContar_Click;

            Controls.Add(txtTexto);
            Controls.Add(btnContar);
            Controls.Add(lblResultado);
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            string texto = txtTexto.Text.ToLower();
            int contador = 0;

            foreach (char c in texto)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    contador++;
                }
            }

            lblResultado.Text = "Quantidade de vogais: " + contador;
        }
    }

    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
