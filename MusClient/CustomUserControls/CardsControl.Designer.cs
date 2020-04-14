namespace MusClient.CustomUserControls
{
    partial class CardsControl
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
            this.card4 = new MusClient.CustomUserControls.CardControl();
            this.card3 = new MusClient.CustomUserControls.CardControl();
            this.card2 = new MusClient.CustomUserControls.CardControl();
            this.card1 = new MusClient.CustomUserControls.CardControl();
            this.SuspendLayout();
            // 
            // card4
            // 
            this.card4.Card = MusCommon.Enums.MusCard.Empty;
            this.card4.Location = new System.Drawing.Point(389, 2);
            this.card4.Name = "card4";
            this.card4.Size = new System.Drawing.Size(120, 140);
            this.card4.TabIndex = 3;
            // 
            // card3
            // 
            this.card3.Card = MusCommon.Enums.MusCard.Empty;
            this.card3.Location = new System.Drawing.Point(260, 2);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(128, 141);
            this.card3.TabIndex = 2;
            // 
            // card2
            // 
            this.card2.Card = MusCommon.Enums.MusCard.Empty;
            this.card2.Location = new System.Drawing.Point(131, 2);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(128, 141);
            this.card2.TabIndex = 1;
            // 
            // card1
            // 
            this.card1.Card = MusCommon.Enums.MusCard.Empty;
            this.card1.Location = new System.Drawing.Point(2, 2);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(120, 140);
            this.card1.TabIndex = 0;
            // 
            // CardsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.card4);
            this.Controls.Add(this.card3);
            this.Controls.Add(this.card2);
            this.Controls.Add(this.card1);
            this.Name = "CardsControl";
            this.Size = new System.Drawing.Size(518, 147);
            this.ResumeLayout(false);

        }

        #endregion

        private CardControl card1;
        private CardControl card2;
        private CardControl card3;
        private CardControl card4;
    }
}
