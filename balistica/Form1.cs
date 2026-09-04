using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace balistica
{
    public partial class Form1 : Form
    {
        private const double TimeStep = 0.02;
        private const float ScalePixelsPerMeter = 6.0f;

        private Projectile _projectile;
        private PointF _launchOrigin;
        private readonly List<PointF> _trajectoryPoints = new List<PointF>();
        private bool _isFlying;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            LoadAssets();
            InitializeSimulation();
        }

        // Carrega os sprites da catapulta e da bala
        private void LoadAssets()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string catapultPath = Path.Combine(baseDir, "Assets", "melanpulta.png");
            string bulletPath = Path.Combine(baseDir, "Assets", "melan_bullet.png");

            if (!File.Exists(catapultPath))
            {
                catapultPath = Path.Combine(baseDir, "..", "..", "Assets", "melanpulta.png");
                bulletPath = Path.Combine(baseDir, "..", "..", "Assets", "melan_bullet.png");
            }

            if (File.Exists(catapultPath))
            {
                using (var temp = Image.FromFile(catapultPath))
                {
                    pictureBoxCatapult.Image = new Bitmap(temp);
                }
            }

            if (File.Exists(bulletPath))
            {
                using (var temp = Image.FromFile(bulletPath))
                {
                    pictureBoxBullet.Image = new Bitmap(temp);
                }
            }
        }

        private void InitializeSimulation()
        {
            _launchOrigin = new PointF(pictureBoxCatapult.Left + 75, pictureBoxCatapult.Top + 20);
            pictureBoxBullet.Location = new Point((int)_launchOrigin.X - (pictureBoxBullet.Width / 2),
                                                 (int)_launchOrigin.Y - (pictureBoxBullet.Height / 2));
            _projectile = new Projectile(20.0, 25.0);
            _trajectoryPoints.Clear();
            _isFlying = false;
        }

        // Converte o texto digitado pelo usuario para double aceitando ponto ou virgula
        private bool TryParseDouble(string input, out double value)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                value = 0;
                return false;
            }

            string sanitized = input.Trim().Replace(',', '.');
            return double.TryParse(sanitized, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private void buttonFire_Click(object sender, EventArgs e)
        {
            if (_isFlying)
            {
                return;
            }

            if (!TryParseDouble(textBoxX.Text, out double vx) || vx <= 0)
            {
                MessageBox.Show("Por favor, digite um valor numerico valido e positivo para a velocidade X!",
                                "Entrada Invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxX.Focus();
                return;
            }

            if (!TryParseDouble(textBoxY.Text, out double vy) || vy <= 0)
            {
                MessageBox.Show("Por favor, digite um valor numerico valido e positivo para a velocidade Y!",
                                "Entrada Invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxY.Focus();
                return;
            }

            _trajectoryPoints.Clear();
            _projectile.InitialVelocityX = vx;
            _projectile.InitialVelocityY = vy;
            _projectile.Reset();

            _isFlying = true;
            timerSimulation.Start();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            timerSimulation.Stop();
            InitializeSimulation();
            labelStats.Text = "Gravidade: 9.81 m/s² | Pronto para disparar";
            Invalidate();
        }

        private void timerSimulation_Tick(object sender, EventArgs e)
        {
            if (!_isFlying)
            {
                return;
            }

            double flightTime = _projectile.GetFlightTime();
            _projectile.AdvanceTime(TimeStep);
            double t = _projectile.ElapsedTime;

            bool reachedGround = (t >= flightTime && flightTime > 0);
            if (reachedGround)
            {
                t = flightTime;
            }

            double physX = _projectile.GetPositionX(t);
            double physY = reachedGround ? 0 : Math.Max(0, _projectile.GetPositionY(t));

            // Converte coordenadas fisicas (metros) para pixels da tela (eixo Y invertido)
            float screenX = _launchOrigin.X + (float)(physX * ScalePixelsPerMeter);
            float screenY = _launchOrigin.Y - (float)(physY * ScalePixelsPerMeter);

            PointF currentPoint = new PointF(screenX, screenY);
            _trajectoryPoints.Add(currentPoint);

            pictureBoxBullet.Location = new Point((int)screenX - (pictureBoxBullet.Width / 2),
                                                 (int)screenY - (pictureBoxBullet.Height / 2));

            double maxHeight = _projectile.GetMaxHeight();
            double maxRange = _projectile.GetMaxRange();

            labelStats.Text = string.Format(
                "Tempo: {0:0.00}s / {1:0.00}s | Posicao: X={2:0.0}m, Y={3:0.0}m | Hmax={4:0.0}m | Alcance={5:0.0}m",
                t, flightTime, physX, physY, maxHeight, maxRange
            );

            // Finaliza a simulacao no instante exato do impacto no solo
            if (reachedGround)
            {
                timerSimulation.Stop();
                _isFlying = false;
            }

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Desenha a linha da trajetoria percorrida pela bala
            if (_trajectoryPoints.Count > 1)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(220, 20, 60), 2.5f))
                {
                    pen.DashStyle = DashStyle.Dash;
                    e.Graphics.DrawCurve(pen, _trajectoryPoints.ToArray());
                }
            }
        }
    }
}
