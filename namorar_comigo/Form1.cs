using System;
using System.Drawing;
using System.Windows.Forms;

namespace namorar_comigo
{
    public partial class Form1 : Form
    {
        private const int BoundaryPadding = 20;
        private readonly Random _random;

        public Form1()
        {
            InitializeComponent();
            _random = new Random();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SABE MUITO", "Resposta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RAPAZ... COMO?", "Resposta", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void buttonNo_MouseEnter(object sender, EventArgs e)
        {
            RepositionNoButton();
        }

        // Reposiciona o botao 'Nao' aleatoriamente garantindo que permaneca visivel e sem sobrepor outros controles
        private void RepositionNoButton()
        {
            int maxX = ClientSize.Width - buttonNo.Width - BoundaryPadding;
            int maxY = ClientSize.Height - buttonNo.Height - BoundaryPadding;

            if (maxX <= BoundaryPadding || maxY <= BoundaryPadding)
            {
                return;
            }

            int newX;
            int newY;
            int attempts = 0;

            do
            {
                newX = _random.Next(BoundaryPadding, maxX);
                newY = _random.Next(BoundaryPadding, maxY);
                attempts++;
            } while (attempts < 20 && (buttonYes.Bounds.IntersectsWith(new Rectangle(newX, newY, buttonNo.Width, buttonNo.Height)) ||
                                      labelTitle.Bounds.IntersectsWith(new Rectangle(newX, newY, buttonNo.Width, buttonNo.Height))));

            buttonNo.Location = new Point(newX, newY);
        }
    }
}
