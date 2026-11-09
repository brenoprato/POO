using System;
using System.Windows.Forms;

namespace MyApp
{
    public class Form1 : Form
    {
        private TextBox txt1;
        private TextBox txt2;
        private TextBox txt3;
        private Button btnCalcular;
        private Label lblResultado;

        public Form1()
        {
            txt1 = new TextBox { Left = 20, Top = 20, Width = 100 };
            txt2 = new TextBox { Left = 20, Top = 50, Width = 100 };
            txt3 = new TextBox { Left = 20, Top = 80, Width = 100 };
            btnCalcular = new Button { Text = "Calcular", Left = 20, Top = 110, Width = 100 };
            lblResultado = new Label { Text = "", Left = 20, Top = 150, AutoSize = true };

            btnCalcular.Click += btnCalcular_Click;

            Controls.Add(txt1);
            Controls.Add(txt2);
            Controls.Add(txt3);
            Controls.Add(btnCalcular);
            Controls.Add(lblResultado);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(txt1.Text);
            double n2 = double.Parse(txt2.Text);
            double n3 = double.Parse(txt3.Text);

            double maior = n1;
            if (n2 > maior)
            {
                maior = n2;
            }
            if (n3 > maior)
            {
                maior = n3;
            }

            lblResultado.Text = "Maior: " + maior;
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
