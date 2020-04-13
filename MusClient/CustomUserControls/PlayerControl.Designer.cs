namespace MusClient.CustomUserControls
{
    partial class PlayerControl
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
            this.cardsControl1 = new MusClient.CustomUserControls.CardsControl();
            this.SuspendLayout();
            // 
            // cardsControl1
            // 
            this.cardsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardsControl1.Cards = null;
            this.cardsControl1.Location = new System.Drawing.Point(3, 4);
            this.cardsControl1.Name = "cardsControl1";
            this.cardsControl1.Position = MusClient.Enum.CardPosition.Bottom;
            this.cardsControl1.Size = new System.Drawing.Size(456, 146);
            this.cardsControl1.TabIndex = 0;
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.Controls.Add(this.cardsControl1);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(464, 176);
            this.ResumeLayout(false);

        }

        #endregion

        private CardsControl cardsControl1;
    }
}
