namespace MusClient.CustomUserControls
{
    partial class GameControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpPoints = new System.Windows.Forms.GroupBox();
            this.nudTeam2Points = new System.Windows.Forms.NumericUpDown();
            this.nudTeam1Points = new System.Windows.Forms.NumericUpDown();
            this.btnChangePoints = new System.Windows.Forms.Button();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.btnNextRound = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.txtTraces = new System.Windows.Forms.TextBox();
            this.btnShowCards = new System.Windows.Forms.Button();
            this.playerControl4 = new MusClient.CustomUserControls.PlayerControl();
            this.playerControl2 = new MusClient.CustomUserControls.PlayerControl();
            this.playerControl3 = new MusClient.CustomUserControls.PlayerControl();
            this.playerControl1 = new MusClient.CustomUserControls.PlayerControl();
            this.grpPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTeam2Points)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTeam1Points)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPoints
            // 
            this.grpPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPoints.Controls.Add(this.nudTeam2Points);
            this.grpPoints.Controls.Add(this.nudTeam1Points);
            this.grpPoints.Controls.Add(this.btnChangePoints);
            this.grpPoints.Controls.Add(this.lblTeam2);
            this.grpPoints.Controls.Add(this.lblTeam1);
            this.grpPoints.Location = new System.Drawing.Point(827, 3);
            this.grpPoints.Name = "grpPoints";
            this.grpPoints.Size = new System.Drawing.Size(155, 84);
            this.grpPoints.TabIndex = 9;
            this.grpPoints.TabStop = false;
            this.grpPoints.Text = "Puntuación";
            // 
            // nudTeam2Points
            // 
            this.nudTeam2Points.Location = new System.Drawing.Point(15, 40);
            this.nudTeam2Points.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudTeam2Points.Name = "nudTeam2Points";
            this.nudTeam2Points.Size = new System.Drawing.Size(41, 20);
            this.nudTeam2Points.TabIndex = 14;
            this.nudTeam2Points.Enter += new System.EventHandler(this.nudTeam2Points_Enter);
            this.nudTeam2Points.Leave += new System.EventHandler(this.nudTeam2Points_Leave);
            // 
            // nudTeam1Points
            // 
            this.nudTeam1Points.Location = new System.Drawing.Point(15, 18);
            this.nudTeam1Points.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudTeam1Points.Name = "nudTeam1Points";
            this.nudTeam1Points.Size = new System.Drawing.Size(41, 20);
            this.nudTeam1Points.TabIndex = 14;
            this.nudTeam1Points.Enter += new System.EventHandler(this.nudTeam1Points_Enter);
            this.nudTeam1Points.Leave += new System.EventHandler(this.nudTeam1Points_Leave);
            // 
            // btnChangePoints
            // 
            this.btnChangePoints.Location = new System.Drawing.Point(15, 62);
            this.btnChangePoints.Name = "btnChangePoints";
            this.btnChangePoints.Size = new System.Drawing.Size(61, 19);
            this.btnChangePoints.TabIndex = 13;
            this.btnChangePoints.Text = "Cambiar";
            this.btnChangePoints.UseVisualStyleBackColor = true;
            this.btnChangePoints.Click += new System.EventHandler(this.btnChangePoints_Click);
            // 
            // lblTeam2
            // 
            this.lblTeam2.AutoSize = true;
            this.lblTeam2.Location = new System.Drawing.Point(62, 42);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(49, 13);
            this.lblTeam2.TabIndex = 12;
            this.lblTeam2.Text = "Equipo 1";
            // 
            // lblTeam1
            // 
            this.lblTeam1.AutoSize = true;
            this.lblTeam1.Location = new System.Drawing.Point(62, 20);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(49, 13);
            this.lblTeam1.TabIndex = 10;
            this.lblTeam1.Text = "Equipo 1";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 2000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // btnNextRound
            // 
            this.btnNextRound.Location = new System.Drawing.Point(64, 9);
            this.btnNextRound.Name = "btnNextRound";
            this.btnNextRound.Size = new System.Drawing.Size(104, 54);
            this.btnNextRound.TabIndex = 10;
            this.btnNextRound.Text = "EMPEZAR!";
            this.btnNextRound.UseVisualStyleBackColor = true;
            this.btnNextRound.Click += new System.EventHandler(this.btnNextRound_Click);
            // 
            // btnDiscard
            // 
            this.btnDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscard.Location = new System.Drawing.Point(907, 731);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(75, 23);
            this.btnDiscard.TabIndex = 11;
            this.btnDiscard.Text = "Descartar";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // txtTraces
            // 
            this.txtTraces.Location = new System.Drawing.Point(350, 240);
            this.txtTraces.Multiline = true;
            this.txtTraces.Name = "txtTraces";
            this.txtTraces.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTraces.Size = new System.Drawing.Size(353, 265);
            this.txtTraces.TabIndex = 12;
            // 
            // btnShowCards
            // 
            this.btnShowCards.Location = new System.Drawing.Point(26, 706);
            this.btnShowCards.Name = "btnShowCards";
            this.btnShowCards.Size = new System.Drawing.Size(75, 34);
            this.btnShowCards.TabIndex = 13;
            this.btnShowCards.Text = "Enseñar cartas";
            this.btnShowCards.UseVisualStyleBackColor = true;
            this.btnShowCards.Click += new System.EventHandler(this.btnShowCards_Click);
            // 
            // playerControl4
            // 
            this.playerControl4.BackColor = System.Drawing.Color.Firebrick;
            this.playerControl4.Cards = null;
            this.playerControl4.Location = new System.Drawing.Point(55, 150);
            this.playerControl4.Name = "playerControl4";
            this.playerControl4.Position = MusClient.Enum.CardPosition.Left;
            this.playerControl4.Size = new System.Drawing.Size(170, 430);
            this.playerControl4.TabIndex = 3;
            this.playerControl4.UserNameAndTeam = null;
            // 
            // playerControl2
            // 
            this.playerControl2.BackColor = System.Drawing.Color.Firebrick;
            this.playerControl2.Cards = null;
            this.playerControl2.Location = new System.Drawing.Point(801, 150);
            this.playerControl2.Name = "playerControl2";
            this.playerControl2.Position = MusClient.Enum.CardPosition.Right;
            this.playerControl2.Size = new System.Drawing.Size(170, 430);
            this.playerControl2.TabIndex = 2;
            this.playerControl2.UserNameAndTeam = null;
            // 
            // playerControl3
            // 
            this.playerControl3.BackColor = System.Drawing.Color.Firebrick;
            this.playerControl3.Cards = null;
            this.playerControl3.Location = new System.Drawing.Point(277, 38);
            this.playerControl3.Name = "playerControl3";
            this.playerControl3.Position = MusClient.Enum.CardPosition.Top;
            this.playerControl3.Size = new System.Drawing.Size(430, 170);
            this.playerControl3.TabIndex = 1;
            this.playerControl3.UserNameAndTeam = null;
            // 
            // playerControl1
            // 
            this.playerControl1.BackColor = System.Drawing.Color.Firebrick;
            this.playerControl1.Cards = null;
            this.playerControl1.Location = new System.Drawing.Point(277, 539);
            this.playerControl1.Name = "playerControl1";
            this.playerControl1.Position = MusClient.Enum.CardPosition.Bottom;
            this.playerControl1.Size = new System.Drawing.Size(430, 170);
            this.playerControl1.TabIndex = 0;
            this.playerControl1.UserNameAndTeam = null;
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.Controls.Add(this.btnShowCards);
            this.Controls.Add(this.txtTraces);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnNextRound);
            this.Controls.Add(this.grpPoints);
            this.Controls.Add(this.playerControl4);
            this.Controls.Add(this.playerControl2);
            this.Controls.Add(this.playerControl3);
            this.Controls.Add(this.playerControl1);
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(1024, 768);
            this.grpPoints.ResumeLayout(false);
            this.grpPoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTeam2Points)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTeam1Points)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PlayerControl playerControl1;
        private PlayerControl playerControl3;
        private PlayerControl playerControl2;
        private PlayerControl playerControl4;
        private System.Windows.Forms.GroupBox grpPoints;
        private System.Windows.Forms.Button btnChangePoints;
        private System.Windows.Forms.Label lblTeam2;
        private System.Windows.Forms.Label lblTeam1;
        private System.Windows.Forms.NumericUpDown nudTeam2Points;
        private System.Windows.Forms.NumericUpDown nudTeam1Points;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button btnNextRound;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.TextBox txtTraces;
        private System.Windows.Forms.Button btnShowCards;
    }
}
