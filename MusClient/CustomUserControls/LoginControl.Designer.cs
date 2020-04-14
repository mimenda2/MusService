namespace MusClient.CustomUserControls
{
    partial class LoginControl
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
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.lblWaitingPlayers = new System.Windows.Forms.Label();
            this.lblIpAddr = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.lblWaitingPlayers);
            this.grpLogin.Controls.Add(this.lblIpAddr);
            this.grpLogin.Controls.Add(this.txtServerIP);
            this.grpLogin.Controls.Add(this.lblName);
            this.grpLogin.Controls.Add(this.lblGameName);
            this.grpLogin.Controls.Add(this.txtUserName);
            this.grpLogin.Controls.Add(this.txtGameName);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Location = new System.Drawing.Point(3, 3);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(303, 182);
            this.grpLogin.TabIndex = 11;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Datos Login";
            // 
            // lblWaitingPlayers
            // 
            this.lblWaitingPlayers.AutoSize = true;
            this.lblWaitingPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitingPlayers.ForeColor = System.Drawing.Color.Blue;
            this.lblWaitingPlayers.Location = new System.Drawing.Point(12, 156);
            this.lblWaitingPlayers.Name = "lblWaitingPlayers";
            this.lblWaitingPlayers.Size = new System.Drawing.Size(0, 16);
            this.lblWaitingPlayers.TabIndex = 12;
            // 
            // lblIpAddr
            // 
            this.lblIpAddr.AutoSize = true;
            this.lblIpAddr.Location = new System.Drawing.Point(12, 21);
            this.lblIpAddr.Name = "lblIpAddr";
            this.lblIpAddr.Size = new System.Drawing.Size(58, 13);
            this.lblIpAddr.TabIndex = 11;
            this.lblIpAddr.Text = "IP Address";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(114, 18);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(121, 20);
            this.txtServerIP.TabIndex = 10;
            this.txtServerIP.Text = "82.158.39.146";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 53);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(96, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Nombre de usuario";
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Location = new System.Drawing.Point(12, 85);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(94, 13);
            this.lblGameName.TabIndex = 9;
            this.lblGameName.Text = "Nombre de partida";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(114, 50);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 20);
            this.txtUserName.TabIndex = 5;
            // 
            // txtGameName
            // 
            this.txtGameName.Enabled = false;
            this.txtGameName.Location = new System.Drawing.Point(114, 82);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(121, 20);
            this.txtGameName.TabIndex = 8;
            this.txtGameName.Text = "LAS MESAS";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(15, 117);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpLogin);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(311, 192);
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Label lblWaitingPlayers;
        private System.Windows.Forms.Label lblIpAddr;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.Button btnLogin;
    }
}
