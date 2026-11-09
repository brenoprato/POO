using System;
using System.Windows.Forms;

namespace MyApp
{
    public class Form1 : Form
    {
        private TextBox txt1;
        private TextBox txt2;
        private Button btnSomar;
        private Label lblResultado;

        public Form1()
        {
            txt1 = new TextBox { Left = 20, Top = 20, Width = 100 };
            txt2 = new TextBox { Left = 20, Top = 50, Width = 100 };
            btnSomar = new Button { Text = "Somar", Left = 20, Top = 80, Width = 100 };
            lblResultado = new Label { Text = "Resultado:", Left = 20, Top = 120, AutoSize = true };

            btnSomar.Click += btnSomar_Click;

            Controls.Add(txt1);
            Controls.Add(txt2);
            Controls.Add(btnSomar);
            Controls.Add(lblResultado);
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(txt1.Text);
            double n2 = double.Parse(txt2.Text);
            double soma = n1 + n2;
            lblResultado.Text = "Resultado: " + soma;
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
