using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MusClient.CustomUserControls
{
    public partial class GamePointControl : UserControl
    {
        public GamePointControl()
        {
            InitializeComponent();

            BackColor = Color.Transparent;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            GameChecked = !GameChecked;
            base.OnMouseDown(e);
        }
        public bool GameChecked
        {
            get { return gameChecked; }
            set
            {
                if(gameChecked != value)
                {
                    gameChecked = value;
                    this.Invalidate();
                    GameCheckedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        bool gameChecked = false;
        public event EventHandler GameCheckedChanged;
        Image TickImage
        {
            get
            {
                if (tickImage == null)
                {
                    Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MusClient.Res.tick.png");
                    tickImage = new Bitmap(stream);
                }
                return tickImage;
            }
        }
        Image tickImage = null;

        Image UnTickImage
        {
            get
            {
                if (unTickImage == null)
                {
                    Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MusClient.Res.untick.png");
                    unTickImage = new Bitmap(stream);
                }
                return unTickImage;
            }
        }
        Image unTickImage = null;
        protected override void OnMouseEnter(EventArgs e)
        {
            Cursor = Cursors.Hand;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            Cursor = Cursors.Default;
            base.OnMouseLeave(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Visible)
            {
                if(gameChecked)
                {
                    e.Graphics.DrawImage(TickImage, DisplayRectangle);
                }
                else
                {
                    e.Graphics.DrawImage(UnTickImage, DisplayRectangle);
                }
            }
            base.OnPaint(e);
        }
    }
}
