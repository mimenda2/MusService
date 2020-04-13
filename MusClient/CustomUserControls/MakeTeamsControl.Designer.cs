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
            this.cmbTeam = new System.Windows.Forms.ComboBox();
            this.lblWaitingPlayers = new System.Windows.Forms.Label();
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
            // cmbTeam
            // 
            this.cmbTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeam.FormattingEnabled = true;
            this.cmbTeam.Items.AddRange(new object[] {
            "Equipo 1",
            "Equipo 2"});
            this.cmbTeam.Location = new System.Drawing.Point(12, 14);
            this.cmbTeam.Name = "cmbTeam";
            this.cmbTeam.Size = new System.Drawing.Size(150, 21);
            this.cmbTeam.TabIndex = 1;
            // 
            // lblWaitingPlayers
            // 
            this.lblWaitingPlayers.AutoSize = true;
            this.lblWaitingPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitingPlayers.ForeColor = System.Drawing.Color.Blue;
            this.lblWaitingPlayers.Location = new System.Drawing.Point(13, 56);
            this.lblWaitingPlayers.Name = "lblWaitingPlayers";
            this.lblWaitingPlayers.Size = new System.Drawing.Size(0, 16);
            this.lblWaitingPlayers.TabIndex = 13;
            // 
            // MakeTeamsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblWaitingPlayers);
            this.Controls.Add(this.cmbTeam);
            this.Controls.Add(this.btnOK);
            this.Name = "MakeTeamsControl";
            this.Size = new System.Drawing.Size(271, 93);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbTeam;
        private System.Windows.Forms.Label lblWaitingPlayers;
    }
}
