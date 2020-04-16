namespace MusClient.CustomUserControls
{
    partial class GamePointsControl
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
            this.gamePointControl1 = new MusClient.CustomUserControls.GamePointControl();
            this.gamePointControl2 = new MusClient.CustomUserControls.GamePointControl();
            this.gamePointControl3 = new MusClient.CustomUserControls.GamePointControl();
            this.SuspendLayout();
            // 
            // gamePointControl1
            // 
            this.gamePointControl1.GameChecked = false;
            this.gamePointControl1.Location = new System.Drawing.Point(0, 0);
            this.gamePointControl1.Name = "gamePointControl1";
            this.gamePointControl1.Size = new System.Drawing.Size(18, 18);
            this.gamePointControl1.TabIndex = 0;
            this.gamePointControl1.GameCheckedChanged += new System.EventHandler(this.gamePointControl2_GameCheckedChanged);
            // 
            // gamePointControl2
            // 
            this.gamePointControl2.GameChecked = false;
            this.gamePointControl2.Location = new System.Drawing.Point(19, 0);
            this.gamePointControl2.Name = "gamePointControl2";
            this.gamePointControl2.Size = new System.Drawing.Size(18, 18);
            this.gamePointControl2.TabIndex = 1;
            this.gamePointControl2.GameCheckedChanged += new System.EventHandler(this.gamePointControl2_GameCheckedChanged);
            // 
            // gamePointControl3
            // 
            this.gamePointControl3.GameChecked = false;
            this.gamePointControl3.Location = new System.Drawing.Point(38, 0);
            this.gamePointControl3.Name = "gamePointControl3";
            this.gamePointControl3.Size = new System.Drawing.Size(18, 18);
            this.gamePointControl3.TabIndex = 2;
            this.gamePointControl3.GameCheckedChanged += new System.EventHandler(this.gamePointControl2_GameCheckedChanged);
            // 
            // GamePointsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gamePointControl3);
            this.Controls.Add(this.gamePointControl2);
            this.Controls.Add(this.gamePointControl1);
            this.Name = "GamePointsControl";
            this.Size = new System.Drawing.Size(56, 18);
            this.ResumeLayout(false);

        }

        #endregion

        private GamePointControl gamePointControl1;
        private GamePointControl gamePointControl2;
        private GamePointControl gamePointControl3;
    }
}
