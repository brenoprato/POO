using System;
using System.Windows.Forms;

namespace MyApp
{
    public class Form1 : Form
    {
        private TextBox txt1;
        private TextBox txt2;
        private ComboBox cmbOperacoes;
        private Button btnCalcular;
        private Label lblResultado;

        public Form1()
        {
            txt1 = new TextBox { Left = 20, Top = 20, Width = 120 };
            txt2 = new TextBox { Left = 20, Top = 50, Width = 120 };

            cmbOperacoes = new ComboBox { Left = 20, Top = 80, Width = 120 };
            cmbOperacoes.Items.Add("Soma");
            cmbOperacoes.Items.Add("Subtração");
            cmbOperacoes.Items.Add("Multiplicação");
            cmbOperacoes.Items.Add("Divisão");

            btnCalcular = new Button { Text = "Calcular", Left = 20, Top = 110, Width = 120 };
            lblResultado = new Label { Text = "", Left = 20, Top = 150, AutoSize = true };

            btnCalcular.Click += btnCalcular_Click;

            Controls.Add(txt1);
            Controls.Add(txt2);
            Controls.Add(cmbOperacoes);
            Controls.Add(btnCalcular);
            Controls.Add(lblResultado);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(txt1.Text);
            double n2 = double.Parse(txt2.Text);
            double resultado = 0;

            if (cmbOperacoes.SelectedItem != null)
            {
                string op = cmbOperacoes.SelectedItem.ToString();

                if (op == "Soma")
                {
                    resultado = n1 + n2;
                }
                else if (op == "Subtração")
                {
                    resultado = n1 - n2;
                }
                else if (op == "Multiplicação")
                {
                    resultado = n1 * n2;
                }
                else if (op == "Divisão")
                {
                    resultado = n1 / n2;
                }

                lblResultado.Text = "Resultado: " + resultado;
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
