using System;
using System.Drawing;
using System.Windows.Forms;

namespace cara_coroa
{
    public partial class Form1 : Form
    {
        private const int InitialAnimationIntervalMs = 60;
        private const int IntervalStepMs = 10;
        private const int MaxAnimationIntervalMs = 400;

        private readonly Coin _coin;
        private CoinSide _finalOutcome;
        private bool _isGameRunning;

        public Form1()
        {
            InitializeComponent();
            _coin = new Coin(CoinSide.Heads);
            UpdateCoinDisplay(CoinSide.Heads);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show(
                    "Escolha Cara ou Coroa antes de jogar!",
                    "Escolha um lado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (_isGameRunning)
            {
                return;
            }

            StartGame();
        }

        private void StartGame()
        {
            _isGameRunning = true;
            _finalOutcome = _coin.Flip();

            SetControlsEnabled(false);

            timer1.Interval = InitialAnimationIntervalMs;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Toggle coin face to animate flipping
            _coin.ToggleSide();
            UpdateCoinDisplay(_coin.CurrentSide);

            timer1.Interval += IntervalStepMs;

            if (timer1.Interval > MaxAnimationIntervalMs)
            {
                timer1.Stop();
                FinishGame();
            }
        }

        private void FinishGame()
        {
            UpdateCoinDisplay(_finalOutcome);
            DisplayResult();
            SetControlsEnabled(true);
            _isGameRunning = false;
        }

        private void UpdateCoinDisplay(CoinSide side)
        {
            pictureBox1.Visible = (side == CoinSide.Heads);
            pictureBox2.Visible = (side == CoinSide.Tails);
        }

        private void DisplayResult()
        {
            CoinSide playerPrediction = radioButton1.Checked ? CoinSide.Heads : CoinSide.Tails;
            bool isWinner = (playerPrediction == _finalOutcome);

            if (_finalOutcome == CoinSide.Heads)
            {
                if (isWinner)
                {
                    MessageBox.Show(
                        "Deu CARA! Você ganhou!!!!! PARABÉNS!",
                        "Resultado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Deu CARA! Você perdeu!!!!",
                        "Resultado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            else // Tails
            {
                if (isWinner)
                {
                    MessageBox.Show(
                        "Deu COROA!\n\nVocê ganhou!!!!! PARABÉNS!",
                        "Resultado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Deu COROA!\n\nVocê perdeu!!!!",
                        "Resultado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            button1.Enabled = enabled;
            radioButton1.Enabled = enabled;
            radioButton2.Enabled = enabled;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
