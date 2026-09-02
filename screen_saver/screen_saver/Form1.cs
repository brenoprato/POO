using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace screen_saver
{
    public partial class Form1 : Form
    {
        private const int DefaultTimerIntervalMs = 10;
        private const int DefaultSpeedX = 2;
        private const int DefaultSpeedY = 2;

        private readonly BouncingSprite _sprite;
        private readonly List<Image> _sprites = new List<Image>();
        private int _currentSpriteIndex = 0;

        public Form1()
        {
            InitializeComponent();

            // Evita oscilacao visual (flicker) durante a movimentacao continua
            DoubleBuffered = true;

            LoadSpriteCollection();

            _sprite = new BouncingSprite(
                initialPosition: pct.Location,
                size: pct.Size,
                velocityX: DefaultSpeedX,
                velocityY: DefaultSpeedY
            );

            timer1.Interval = DefaultTimerIntervalMs;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        // Carrega todas as imagens de jokers da pasta de Assets
        private void LoadSpriteCollection()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string assetsDir = Path.Combine(baseDir, "Assets", "jokers");

            if (!Directory.Exists(assetsDir))
            {
                assetsDir = Path.Combine(baseDir, "..", "..", "Assets", "jokers");
            }

            if (Directory.Exists(assetsDir))
            {
                string[] files = Directory.GetFiles(assetsDir, "*.png").OrderBy(f => f).ToArray();
                foreach (string file in files)
                {
                    try
                    {
                        using (var temp = Image.FromFile(file))
                        {
                            _sprites.Add(new Bitmap(temp));
                        }
                    }
                    catch
                    {
                        // Ignora arquivos que falharem no carregamento
                    }
                }
            }

            if (_sprites.Count > 0)
            {
                pct.Image = _sprites[0];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_sprite == null)
            {
                return;
            }

            bool bounced = _sprite.MoveAndBounce(ClientSize);
            pct.Location = _sprite.Position;

            // Ao colidir com a borda, avanca para o proximo sprite da colecao
            if (bounced && _sprites.Count > 1)
            {
                _currentSpriteIndex = (_currentSpriteIndex + 1) % _sprites.Count;
                pct.Image = _sprites[_currentSpriteIndex];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pct_Click(object sender, EventArgs e)
        {
        }
    }
}
