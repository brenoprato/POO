using System;
using System.Drawing;
using System.Windows.Forms;

namespace foto
{
    public partial class Form1 : Form
    {
        private const int DefaultTimerIntervalMs = 10;
        private const int DefaultSpeedX = 2;
        private const int DefaultSpeedY = 2;

        private BouncingSprite _sprite;

        public Form1()
        {
            InitializeComponent();

            // Enable double buffering to prevent screen tearing/flickering
            DoubleBuffered = true;

            // Configure PictureBox display
            pct.SizeMode = PictureBoxSizeMode.Zoom;

            // Instantiate the bouncing sprite physics model
            _sprite = new BouncingSprite(
                initialPosition: pct.Location,
                size: pct.Size,
                velocityX: DefaultSpeedX,
                velocityY: DefaultSpeedY
            );

            // Configure animation timer
            timer1.Interval = DefaultTimerIntervalMs;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_sprite == null)
            {
                return;
            }

            _sprite.MoveAndBounce(ClientSize);
            pct.Location = _sprite.Position;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pct_Click(object sender, EventArgs e)
        {
        }
    }
}
