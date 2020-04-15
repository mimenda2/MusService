using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusCommon.Enums;
using MusCommon;
using MusClient.Enum;

namespace MusClient.CustomUserControls
{
    public partial class CardControl : UserControl
    {
        Image imgCard = null;
        public CardControl()
        {
            InitializeComponent();

            imgCard = Cards.GetCard(card);

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
                    if (imgCard != null)
                        imgCard.Dispose();
                    card = value;
                    imgCard = Cards.GetCard(card);
                    this.Invalidate();
                }
            }
        }
        MusCard card = MusCard.Empty;

        public bool Discard
        {
            get { return chkDiscard.Visible && chkDiscard.Checked; }
            set
            {
                if (chkDiscard.Visible)
                {
                    chkDiscard.Checked = value;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Rectangle rect = DisplayRectangle;
                switch (position)
                {
                    case CardPosition.Bottom:
                        rect = new Rectangle(0, 0, this.Width, chkDiscard.Top - 2);
                        break;
                    case CardPosition.Top:
                        imgCard.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case CardPosition.Left:
                        imgCard.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case CardPosition.Right:
                        imgCard.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
                e.Graphics.DrawImage(imgCard, rect);
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
