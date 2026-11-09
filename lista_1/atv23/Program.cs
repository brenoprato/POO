using System;
using System.Windows.Forms;

namespace MyApp
{
    public class Form1 : Form
    {
        private TextBox txtNumero;
        private Button btnGerar;
        private TextBox txtResultado;

        public Form1()
        {
            txtNumero = new TextBox { Left = 20, Top = 20, Width = 100 };
            btnGerar = new Button { Text = "Gerar", Left = 20, Top = 50, Width = 100 };
            txtResultado = new TextBox { Left = 20, Top = 90, Width = 150, Height = 180, Multiline = true };

            btnGerar.Click += btnGerar_Click;

            Controls.Add(txtNumero);
            Controls.Add(btnGerar);
            Controls.Add(txtResultado);
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtNumero.Text);
            txtResultado.Text = "";

            for (int i = 1; i <= 10; i++)
            {
                txtResultado.Text += $"{n} x {i} = {n * i}\r\n";
            }
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
