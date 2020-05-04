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
            this.gamePointsTeam2 = new MusClient.CustomUserControls.GamePointsControl();
            this.gamePointsTeam1 = new MusClient.CustomUserControls.GamePointsControl();
            this.nudTeam2Points = new MusClient.CustomUserControls.MusNumericUpDown();
            this.nudTeam1Points = new MusClient.CustomUserControls.MusNumericUpDown();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.btnNextRound = new MusClient.CustomUserControls.ButtonWithImage();
            this.btnDiscard = new MusClient.CustomUserControls.ButtonWithImage();
            this.txtTraces = new System.Windows.Forms.TextBox();
            this.btnShowCards = new MusClient.CustomUserControls.ButtonWithImage();
            this.lblError = new System.Windows.Forms.Label();
            this.cmbHandUser = new System.Windows.Forms.ComboBox();
            this.lblHand = new System.Windows.Forms.Label();
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
            this.grpPoints.Controls.Add(this.gamePointsTeam2);
            this.grpPoints.Controls.Add(this.gamePointsTeam1);
            this.grpPoints.Controls.Add(this.nudTeam2Points);
            this.grpPoints.Controls.Add(this.nudTeam1Points);
            this.grpPoints.Controls.Add(this.lblTeam2);
            this.grpPoints.Controls.Add(this.lblTeam1);
            this.grpPoints.Location = new System.Drawing.Point(830, 9);
            this.grpPoints.Name = "grpPoints";
            this.grpPoints.Size = new System.Drawing.Size(176, 84);
            this.grpPoints.TabIndex = 9;
            this.grpPoints.TabStop = false;
            this.grpPoints.Text = "Puntuación";
            // 
            // gamePointsTeam2
            // 
            this.gamePointsTeam2.BackColor = System.Drawing.Color.Red;
            this.gamePointsTeam2.ChangePointsDate = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.gamePointsTeam2.GamesWin = 0;
            this.gamePointsTeam2.Location = new System.Drawing.Point(92, 60);
            this.gamePointsTeam2.MusEnabled = true;
            this.gamePointsTeam2.MusValor = 0;
            this.gamePointsTeam2.Name = "gamePointsTeam2";
            this.gamePointsTeam2.Size = new System.Drawing.Size(56, 18);
            this.gamePointsTeam2.TabIndex = 15;
            this.gamePointsTeam2.Tag = 0;
            this.gamePointsTeam2.UserPointsChanged = 0;
            // 
            // gamePointsTeam1
            // 
            this.gamePointsTeam1.BackColor = System.Drawing.Color.Red;
            this.gamePointsTeam1.ChangePointsDate = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.gamePointsTeam1.GamesWin = 0;
            this.gamePointsTeam1.Location = new System.Drawing.Point(10, 60);
            this.gamePointsTeam1.MusEnabled = true;
            this.gamePointsTeam1.MusValor = 0;
            this.gamePointsTeam1.Name = "gamePointsTeam1";
            this.gamePointsTeam1.Size = new System.Drawing.Size(56, 18);
            this.gamePointsTeam1.TabIndex = 15;
            this.gamePointsTeam1.Tag = 0;
            this.gamePointsTeam1.UserPointsChanged = 0;
            // 
            // nudTeam2Points
            // 
            this.nudTeam2Points.ChangePointsDate = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.nudTeam2Points.Location = new System.Drawing.Point(92, 35);
            this.nudTeam2Points.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudTeam2Points.MusEnabled = true;
            this.nudTeam2Points.MusValor = 0;
            this.nudTeam2Points.Name = "nudTeam2Points";
            this.nudTeam2Points.Size = new System.Drawing.Size(41, 20);
            this.nudTeam2Points.TabIndex = 14;
            this.nudTeam2Points.Tag = 0;
            this.nudTeam2Points.UserPointsChanged = 0;
            // 
            // nudTeam1Points
            // 
            this.nudTeam1Points.ChangePointsDate = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.nudTeam1Points.Location = new System.Drawing.Point(10, 35);
            this.nudTeam1Points.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudTeam1Points.MusEnabled = true;
            this.nudTeam1Points.MusValor = 0;
            this.nudTeam1Points.Name = "nudTeam1Points";
            this.nudTeam1Points.Size = new System.Drawing.Size(41, 20);
            this.nudTeam1Points.TabIndex = 14;
            this.nudTeam1Points.Tag = 0;
            this.nudTeam1Points.UserPointsChanged = 0;
            // 
            // lblTeam2
            // 
            this.lblTeam2.AutoSize = true;
            this.lblTeam2.Location = new System.Drawing.Point(89, 17);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(49, 13);
            this.lblTeam2.TabIndex = 12;
            this.lblTeam2.Text = "Equipo 1";
            // 
            // lblTeam1
            // 
            this.lblTeam1.AutoSize = true;
            this.lblTeam1.Location = new System.Drawing.Point(7, 17);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(49, 13);
            this.lblTeam1.TabIndex = 10;
            this.lblTeam1.Text = "Equipo 1";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 2000;
            // 
            // btnNextRound
            // 
            this.btnNextRound.BackColor = System.Drawing.Color.Transparent;
            this.btnNextRound.ImgButton = null;
            this.btnNextRound.Location = new System.Drawing.Point(30, 10);
            this.btnNextRound.Name = "btnNextRound";
            this.btnNextRound.Size = new System.Drawing.Size(128, 33);
            this.btnNextRound.TabIndex = 10;
            this.btnNextRound.TooltipText = null;
            // 
            // btnDiscard
            // 
            this.btnDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscard.BackColor = System.Drawing.Color.Transparent;
            this.btnDiscard.ButtonState = MusClient.Enum.MusButtonState.Normal;
            this.btnDiscard.ImgButton = null;
            this.btnDiscard.Location = new System.Drawing.Point(894, 684);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(84, 74);
            this.btnDiscard.TabIndex = 11;
            this.btnDiscard.TooltipText = null;
            // 
            // txtTraces
            // 
            this.txtTraces.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraces.Location = new System.Drawing.Point(350, 240);
            this.txtTraces.Multiline = true;
            this.txtTraces.Name = "txtTraces";
            this.txtTraces.ReadOnly = true;
            this.txtTraces.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTraces.Size = new System.Drawing.Size(353, 265);
            this.txtTraces.TabIndex = 12;
            // 
            // btnShowCards
            // 
            this.btnShowCards.BackColor = System.Drawing.Color.Transparent;
            this.btnShowCards.ButtonState = MusClient.Enum.MusButtonState.Normal;
            this.btnShowCards.ImgButton = null;
            this.btnShowCards.Location = new System.Drawing.Point(26, 684);
            this.btnShowCards.Name = "btnShowCards";
            this.btnShowCards.Size = new System.Drawing.Size(75, 56);
            this.btnShowCards.TabIndex = 13;
            this.btnShowCards.TooltipText = null;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(27, 752);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 14;
            // 
            // cmbHandUser
            // 
            this.cmbHandUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHandUser.FormattingEnabled = true;
            this.cmbHandUser.Location = new System.Drawing.Point(66, 57);
            this.cmbHandUser.Name = "cmbHandUser";
            this.cmbHandUser.Size = new System.Drawing.Size(129, 21);
            this.cmbHandUser.TabIndex = 15;
            // 
            // lblHand
            // 
            this.lblHand.AutoSize = true;
            this.lblHand.Location = new System.Drawing.Point(30, 62);
            this.lblHand.Name = "lblHand";
            this.lblHand.Size = new System.Drawing.Size(34, 13);
            this.lblHand.TabIndex = 16;
            this.lblHand.Text = "Mano";
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
            this.playerControl4.TeamName = null;
            this.playerControl4.UserName = null;
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
            this.playerControl2.TeamName = null;
            this.playerControl2.UserName = null;
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
            this.playerControl3.TeamName = null;
            this.playerControl3.UserName = null;
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
            this.playerControl1.TeamName = null;
            this.playerControl1.UserName = null;
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.Controls.Add(this.lblHand);
            this.Controls.Add(this.cmbHandUser);
            this.Controls.Add(this.lblError);
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

        private void NudTeam1Points_ValueChanged(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private PlayerControl playerControl1;
        private PlayerControl playerControl3;
        private PlayerControl playerControl2;
        private PlayerControl playerControl4;
        private System.Windows.Forms.GroupBox grpPoints;
        private System.Windows.Forms.Label lblTeam2;
        private System.Windows.Forms.Label lblTeam1;
        private MusNumericUpDown nudTeam2Points;
        private MusNumericUpDown nudTeam1Points;
        private System.Windows.Forms.Timer timerRefresh;
        private ButtonWithImage btnNextRound;
        private ButtonWithImage btnDiscard;
        private System.Windows.Forms.TextBox txtTraces;
        private ButtonWithImage btnShowCards;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ComboBox cmbHandUser;
        private System.Windows.Forms.Label lblHand;
        private GamePointsControl gamePointsTeam2;
        private GamePointsControl gamePointsTeam1;
    }
}
