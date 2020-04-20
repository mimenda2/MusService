namespace MusClient.CustomUserControls
{
    partial class MakeTeamsControl
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
            this.btnOK = new System.Windows.Forms.Button();
            this.lblWaitingPlayers = new System.Windows.Forms.Label();
            this.radTeam1 = new System.Windows.Forms.RadioButton();
            this.radTeam2 = new System.Windows.Forms.RadioButton();
            this.radRandom = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(178, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblWaitingPlayers
            // 
            this.lblWaitingPlayers.AutoSize = true;
            this.lblWaitingPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitingPlayers.ForeColor = System.Drawing.Color.Blue;
            this.lblWaitingPlayers.Location = new System.Drawing.Point(9, 94);
            this.lblWaitingPlayers.Name = "lblWaitingPlayers";
            this.lblWaitingPlayers.Size = new System.Drawing.Size(0, 16);
            this.lblWaitingPlayers.TabIndex = 13;
            // 
            // radTeam1
            // 
            this.radTeam1.AutoSize = true;
            this.radTeam1.Checked = true;
            this.radTeam1.Location = new System.Drawing.Point(3, 14);
            this.radTeam1.Name = "radTeam1";
            this.radTeam1.Size = new System.Drawing.Size(67, 17);
            this.radTeam1.TabIndex = 14;
            this.radTeam1.TabStop = true;
            this.radTeam1.Text = "Equipo 1";
            this.radTeam1.UseVisualStyleBackColor = true;
            this.radTeam1.CheckedChanged += new System.EventHandler(this.radTeam_CheckedChanged);
            // 
            // radTeam2
            // 
            this.radTeam2.AutoSize = true;
            this.radTeam2.Location = new System.Drawing.Point(3, 37);
            this.radTeam2.Name = "radTeam2";
            this.radTeam2.Size = new System.Drawing.Size(67, 17);
            this.radTeam2.TabIndex = 15;
            this.radTeam2.Text = "Equipo 2";
            this.radTeam2.UseVisualStyleBackColor = true;
            this.radTeam2.CheckedChanged += new System.EventHandler(this.radTeam_CheckedChanged);
            // 
            // radRandom
            // 
            this.radRandom.AutoSize = true;
            this.radRandom.Location = new System.Drawing.Point(3, 60);
            this.radRandom.Name = "radRandom";
            this.radRandom.Size = new System.Drawing.Size(66, 17);
            this.radRandom.TabIndex = 16;
            this.radRandom.Text = "Aleatorio";
            this.radRandom.UseVisualStyleBackColor = true;
            this.radRandom.CheckedChanged += new System.EventHandler(this.radTeam_CheckedChanged);
            // 
            // MakeTeamsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radRandom);
            this.Controls.Add(this.radTeam2);
            this.Controls.Add(this.radTeam1);
            this.Controls.Add(this.lblWaitingPlayers);
            this.Controls.Add(this.btnOK);
            this.Name = "MakeTeamsControl";
            this.Size = new System.Drawing.Size(291, 130);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblWaitingPlayers;
        private System.Windows.Forms.RadioButton radTeam1;
        private System.Windows.Forms.RadioButton radTeam2;
        private System.Windows.Forms.RadioButton radRandom;
    }
}
