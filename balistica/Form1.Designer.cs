namespace balistica
{
    partial class Form1
    {
        /// <summary>
        /// Variavel de designer necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estao sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessario descartar os recursos gerenciados; caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codigo gerado pelo Windows Form Designer

        /// <summary>
        /// Metodo necessario para suporte ao Designer - nao modifique 
        /// o conteudo deste metodo com o editor de codigo.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControls = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonFire = new System.Windows.Forms.Button();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelStats = new System.Windows.Forms.Label();
            this.pictureBoxCatapult = new System.Windows.Forms.PictureBox();
            this.pictureBoxBullet = new System.Windows.Forms.PictureBox();
            this.timerSimulation = new System.Windows.Forms.Timer(this.components);
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCatapult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBullet)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.panelControls.Controls.Add(this.buttonReset);
            this.panelControls.Controls.Add(this.buttonFire);
            this.panelControls.Controls.Add(this.textBoxY);
            this.panelControls.Controls.Add(this.labelY);
            this.panelControls.Controls.Add(this.textBoxX);
            this.panelControls.Controls.Add(this.labelX);
            this.panelControls.Controls.Add(this.labelTitle);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(900, 75);
            this.panelControls.TabIndex = 0;
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.LightGray;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.buttonReset.Location = new System.Drawing.Point(780, 22);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(90, 34);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Limpar";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonFire
            // 
            this.buttonFire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.buttonFire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFire.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.buttonFire.ForeColor = System.Drawing.Color.White;
            this.buttonFire.Location = new System.Drawing.Point(670, 22);
            this.buttonFire.Name = "buttonFire";
            this.buttonFire.Size = new System.Drawing.Size(100, 34);
            this.buttonFire.TabIndex = 5;
            this.buttonFire.Text = "Disparar";
            this.buttonFire.UseVisualStyleBackColor = false;
            this.buttonFire.Click += new System.EventHandler(this.buttonFire_Click);
            // 
            // textBoxY
            // 
            this.textBoxY.Font = new System.Drawing.Font("Arial", 11F);
            this.textBoxY.Location = new System.Drawing.Point(570, 27);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(80, 24);
            this.textBoxY.TabIndex = 4;
            this.textBoxY.Text = "25.0";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelY.Location = new System.Drawing.Point(440, 31);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(124, 16);
            this.labelY.TabIndex = 3;
            this.labelY.Text = "Velocidade Y (m/s):";
            // 
            // textBoxX
            // 
            this.textBoxX.Font = new System.Drawing.Font("Arial", 11F);
            this.textBoxX.Location = new System.Drawing.Point(340, 27);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(80, 24);
            this.textBoxX.TabIndex = 2;
            this.textBoxX.Text = "20.0";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelX.Location = new System.Drawing.Point(210, 31);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(124, 16);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "Velocidade X (m/s):";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.labelTitle.Location = new System.Drawing.Point(15, 29);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(168, 19);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Simulador Balistico";
            // 
            // labelStats
            // 
            this.labelStats.AutoSize = true;
            this.labelStats.BackColor = System.Drawing.Color.Transparent;
            this.labelStats.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.labelStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.labelStats.Location = new System.Drawing.Point(20, 90);
            this.labelStats.Name = "labelStats";
            this.labelStats.Size = new System.Drawing.Size(400, 17);
            this.labelStats.TabIndex = 1;
            this.labelStats.Text = "Gravidade: 9.81 m/s² | Pronto para disparar";
            // 
            // pictureBoxCatapult
            // 
            this.pictureBoxCatapult.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCatapult.Location = new System.Drawing.Point(30, 400);
            this.pictureBoxCatapult.Name = "pictureBoxCatapult";
            this.pictureBoxCatapult.Size = new System.Drawing.Size(110, 125);
            this.pictureBoxCatapult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCatapult.TabIndex = 3;
            this.pictureBoxCatapult.TabStop = false;
            // 
            // pictureBoxBullet
            // 
            this.pictureBoxBullet.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBullet.Location = new System.Drawing.Point(105, 415);
            this.pictureBoxBullet.Name = "pictureBoxBullet";
            this.pictureBoxBullet.Size = new System.Drawing.Size(42, 38);
            this.pictureBoxBullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBullet.TabIndex = 4;
            this.pictureBoxBullet.TabStop = false;
            // 
            // timerSimulation
            // 
            this.timerSimulation.Interval = 16;
            this.timerSimulation.Tick += new System.EventHandler(this.timerSimulation_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pictureBoxBullet);
            this.Controls.Add(this.pictureBoxCatapult);
            this.Controls.Add(this.labelStats);
            this.Controls.Add(this.panelControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador de Balistica - Melanpulta";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCatapult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBullet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Button buttonFire;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelStats;
        private System.Windows.Forms.PictureBox pictureBoxCatapult;
        private System.Windows.Forms.PictureBox pictureBoxBullet;
        private System.Windows.Forms.Timer timerSimulation;
    }
}
