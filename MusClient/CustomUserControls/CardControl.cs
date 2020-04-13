using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Enums;
using Common;
using MusClient.Enum;

namespace MusClient.CustomUserControls
{
    public partial class CardControl : UserControl
    {
        public CardControl()
        {
            InitializeComponent();
            this.Text = "CardControl";
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            chkDiscard.Visible = position == CardPosition.Bottom;
        }
        public CardPosition Position
        {
            get { return position; }
            set
            {
                if (position != value)
                {
                    position = value;
                    chkDiscard.Visible = position == CardPosition.Bottom;
                    this.Invalidate();
                }
            }
        }
        CardPosition position = CardPosition.Bottom;
        public MusCard Card
        {
            get { return card; }
            set
            {
                if (card != value)
                {
                    card = value;
                    this.Invalidate();
                }
            }
        }
        MusCard card = MusCard.Empty;

        public bool Discard
        {
            get { return chkDiscard.Visible && chkDiscard.Checked; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Image img = Cards.GetCard(card);
                Rectangle rect = DisplayRectangle;
                switch (position)
                {
                    case CardPosition.Bottom:
                        rect = new Rectangle(0, 0, this.Width, chkDiscard.Top - 2);
                        break;
                    case CardPosition.Top:
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case CardPosition.Left:
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case CardPosition.Right:
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
                e.Graphics.DrawImage(img, rect);
            }
            catch { }
            base.OnPaint(e);
        }
        protected override void OnResize(EventArgs e)
        {
            if (position == CardPosition.Bottom)
            {
                chkDiscard.Location = new Point((this.Width - chkDiscard.Width) / 2, this.Height - chkDiscard.Height - 2);
            }
            base.OnResize(e);
        }
    }
}
