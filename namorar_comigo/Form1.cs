using System;
using System.Drawing;
using System.Windows.Forms;

namespace namorar_comigo
{
    public partial class Form1 : Form
    {
        private const int BoundaryPadding = 20;
        private const int MouseSafetyMargin = 60;
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

        private void buttonNo_MouseMove(object sender, MouseEventArgs e)
        {
            RepositionNoButton();
        }

        // Reposiciona o botao 'Nao' garantindo que fique longe do cursor atual do mouse
        private void RepositionNoButton()
        {
            int maxX = ClientSize.Width - buttonNo.Width - BoundaryPadding;
            int maxY = ClientSize.Height - buttonNo.Height - BoundaryPadding;

            if (maxX <= BoundaryPadding || maxY <= BoundaryPadding)
            {
                return;
            }

            Point mousePos = PointToClient(Cursor.Position);
            Rectangle mouseAvoidZone = new Rectangle(
                mousePos.X - MouseSafetyMargin,
                mousePos.Y - MouseSafetyMargin,
                MouseSafetyMargin * 2,
                MouseSafetyMargin * 2
            );

            int newX = buttonNo.Location.X;
            int newY = buttonNo.Location.Y;
            int attempts = 0;

            // Sorteia nova posicao evitando o cursor do mouse, o botao Sim e o titulo
            while (attempts < 30)
            {
                int candidateX = _random.Next(BoundaryPadding, maxX);
                int candidateY = _random.Next(BoundaryPadding, maxY);
                Rectangle candidateRect = new Rectangle(candidateX, candidateY, buttonNo.Width, buttonNo.Height);

                bool overlapsMouse = candidateRect.IntersectsWith(mouseAvoidZone);
                bool overlapsYes = candidateRect.IntersectsWith(buttonYes.Bounds);
                bool overlapsTitle = candidateRect.IntersectsWith(labelTitle.Bounds);

                if (!overlapsMouse && !overlapsYes && !overlapsTitle)
                {
                    newX = candidateX;
                    newY = candidateY;
                    break;
                }

                attempts++;
            }

            // Caso nao encontre uma posicao perfeita no loop, escolhe o quadrante oposto ao mouse
            if (attempts >= 30)
            {
                newX = (mousePos.X < ClientSize.Width / 2) ? maxX : BoundaryPadding;
                newY = (mousePos.Y < ClientSize.Height / 2) ? maxY : BoundaryPadding;
            }

            buttonNo.Location = new Point(newX, newY);
        }
    }
}
