using System;
using System.Windows.Forms;

namespace MyApp
{
    public class Form1 : Form
    {
        private TextBox txtNome;
        private Button btnAdicionar;
        private ComboBox cmbNomes;
        private Label lblQuantidade;

        public Form1()
        {
            txtNome = new TextBox { Left = 20, Top = 20, Width = 150 };
            btnAdicionar = new Button { Text = "Adicionar", Left = 20, Top = 50, Width = 100 };
            cmbNomes = new ComboBox { Left = 20, Top = 90, Width = 150 };
            lblQuantidade = new Label { Text = "Total: 0", Left = 20, Top = 130, AutoSize = true };

            btnAdicionar.Click += btnAdicionar_Click;

            Controls.Add(txtNome);
            Controls.Add(btnAdicionar);
            Controls.Add(cmbNomes);
            Controls.Add(lblQuantidade);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            cmbNomes.Items.Add(txtNome.Text);
            lblQuantidade.Text = "Total: " + cmbNomes.Items.Count;
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
