namespace MusClient.CustomUserControls
{
    partial class CardControl
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
            this.chkDiscard = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkDiscard
            // 
            this.chkDiscard.AutoSize = true;
            this.chkDiscard.Location = new System.Drawing.Point(70, 133);
            this.chkDiscard.Name = "chkDiscard";
            this.chkDiscard.Size = new System.Drawing.Size(15, 14);
            this.chkDiscard.TabIndex = 0;
            this.chkDiscard.UseVisualStyleBackColor = true;
            this.chkDiscard.Visible = false;
            // 
            // CardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkDiscard);
            this.Name = "CardControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDiscard;
    }
}
