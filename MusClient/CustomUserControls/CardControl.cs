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
using System.Diagnostics;

namespace MusClient.CustomUserControls
{
    public partial class CardControl : UserControl
    {
        Image imgCard = null;
        public CardControl()
        {
            InitializeComponent();

            GetCard();

            this.Text = "CardControl";
        }

        void GetCard()
        {
            imgCard = Cards.GetCard(card);
            switch (position)
            {
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
                    GetCard();
                    if (position == CardPosition.Bottom)
                        xCoord = -imgCard.Width;
                    this.Invalidate();
                }
            }
        }
        MusCard card = MusCard.Empty;
        public bool CheckCard
        {
            get { return chkDiscard.Visible && chkDiscard.Checked; }
            set
            {
                if (chkDiscard.Visible)
                    chkDiscard.Checked = value;
            }
        }
        public bool Discard
        {
            get { return chkDiscard.Visible && chkDiscard.Checked; }
            set
            {
                if (chkDiscard.Visible)
                {
                    chkDiscard.Checked = value;
                    this.Invalidate();
                }
            }
        }
        int xCoord = 0;
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Rectangle rect = DisplayRectangle;
                if (position == CardPosition.Bottom)
                    rect = new Rectangle(xCoord, 0, this.Width, chkDiscard.Top - 2);
                e.Graphics.DrawImage(imgCard, rect);
                if (xCoord < 0)
                {
                    xCoord = Math.Min(0, xCoord + 2);
                    System.Threading.Thread.Sleep(0);
                    Application.DoEvents();
                    this.Invalidate();
                }
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
