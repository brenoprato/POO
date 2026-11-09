using System;
using System.Windows.Forms;

namespace MyApp
{
    public class Form1 : Form
    {
        private ComboBox cmbCores;
        private Button btnAplicar;
        private Label lblResultado;

        public Form1()
        {
            cmbCores = new ComboBox { Left = 20, Top = 20, Width = 120 };
            cmbCores.Items.Add("Vermelho");
            cmbCores.Items.Add("Verde");
            cmbCores.Items.Add("Azul");

            btnAplicar = new Button { Text = "Aplicar", Left = 20, Top = 60, Width = 120 };
            lblResultado = new Label { Text = "", Left = 20, Top = 100, AutoSize = true };

            btnAplicar.Click += btnAplicar_Click;

            Controls.Add(cmbCores);
            Controls.Add(btnAplicar);
            Controls.Add(lblResultado);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (cmbCores.SelectedItem != null)
            {
                string cor = cmbCores.SelectedItem.ToString();
                lblResultado.Text = $"Você escolheu: {cor}";
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
