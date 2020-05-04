using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusClient.Enum;

namespace MusClient.CustomUserControls
{
    public partial class ButtonWithImage : UserControl
    {
        ToolTip toolTip = new ToolTip();
        public ButtonWithImage()
        {
            InitializeComponent();

            // Set up the delays for the ToolTip.
            toolTip.AutoPopDelay = 1000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = true;

            BackColor = Color.Transparent;
        }
        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (imgButton != null)
                    imgButton.Dispose();
                imgButton = null;
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            ButtonState = MusButtonState.Click;
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            ButtonState = MusButtonState.Normal;
            base.OnMouseUp(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            ButtonState = MusButtonState.Over;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            ButtonState = MusButtonState.Normal;
            base.OnMouseLeave(e);
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            ButtonState = Enabled ? MusButtonState.Normal : MusButtonState.Disable;
            base.OnEnabledChanged(e);
        }
        public Bitmap ImgButton
        {
            get { return imgButton; }
            set
            {
                if (imgButton != value)
                {
                    imgButton = value;
                    this.Invalidate();
                }
            }
        }
        Bitmap imgButton;
        public string TooltipText
        {
            get { return tooltipText; }
            set
            {
                if (tooltipText != value)
                {
                    tooltipText = value;
                    toolTip.SetToolTip(this, tooltipText);
                }
            }
        }
        string tooltipText;
        public MusButtonState ButtonState
        {
            get { return buttonState; }
            set
            {
                if (buttonState != value)
                {
                    if (Enabled)
                        buttonState = value;
                    else
                        buttonState = MusButtonState.Disable;
                    this.Invalidate();
                }
            }
        }
        MusButtonState buttonState;

        Image LastImage
        {
            get { return lastImage; }
            set
            {
                if (lastImage != null)
                    lastImage.Dispose();
                lastImage = value;
            }
        }
        Image lastImage;
        protected override void OnPaint(PaintEventArgs e)
        {
            if (imgButton != null && imgButton.Width > 0 && imgButton.Height > 0)
            {
                int imgH = imgButton.Height / System.Enum.GetValues(typeof(MusButtonState)).Length;
                int x = 0;
                int y = (int)buttonState * imgH;
                LastImage = imgButton.Clone(new Rectangle(x, y, imgButton.Width, imgH), imgButton.PixelFormat);
                e.Graphics.DrawImage(lastImage, this.DisplayRectangle);
            }
            base.OnPaint(e);
        }
    }
}
