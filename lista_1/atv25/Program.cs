using System;
using System.Windows.Forms;

namespace MyApp
{
    public class Form1 : Form
    {
        private TextBox txtNota1;
        private TextBox txtNota2;
        private TextBox txtNota3;
        private Button btnCalcular;
        private Label lblResultado;

        public Form1()
        {
            txtNota1 = new TextBox { Left = 20, Top = 20, Width = 100 };
            txtNota2 = new TextBox { Left = 20, Top = 50, Width = 100 };
            txtNota3 = new TextBox { Left = 20, Top = 80, Width = 100 };
            btnCalcular = new Button { Text = "Calcular média", Left = 20, Top = 110, Width = 120 };
            lblResultado = new Label { Text = "", Left = 20, Top = 150, AutoSize = true };

            btnCalcular.Click += btnCalcular_Click;

            Controls.Add(txtNota1);
            Controls.Add(txtNota2);
            Controls.Add(txtNota3);
            Controls.Add(btnCalcular);
            Controls.Add(lblResultado);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(txtNota1.Text);
            double n2 = double.Parse(txtNota2.Text);
            double n3 = double.Parse(txtNota3.Text);

            double media = (n1 + n2 + n3) / 3.0;

            if (media >= 6.0)
            {
                lblResultado.Text = $"Média: {media:F2} - Aprovado";
            }
            else
            {
                lblResultado.Text = $"Média: {media:F2} - Reprovado";
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
