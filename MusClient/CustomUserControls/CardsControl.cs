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
using MusClient.Enum;

namespace MusClient.CustomUserControls
{
    public partial class CardsControl : UserControl
    {
        public CardsControl()
        {
            InitializeComponent();
            this.Text = "CardsControl";
        }

        public CardPosition Position
        {
            get { return position; }
            set
            {
                if (position != value)
                {
                    position = value;
                    foreach (var cardControl in this.Controls.OfType<CardControl>())
                        cardControl.Position = position;
                }
            }
        }
        CardPosition position = CardPosition.Bottom;

        public List<MusCard> Cards
        {
            get { return cards; }
            set
            {
                cards = value;
                if (cards?.Count == 4)
                {
                    card1.Card = cards[0];
                    card2.Card = cards[1];
                    card3.Card = cards[2];
                    card4.Card = cards[3];
                }
            }
        }
        List<MusCard> cards;

        public List<MusCard> Discards
        {
            get
            {
                List<MusCard> retVal = new List<MusCard>();
                foreach (var cardControl in this.Controls.OfType<CardControl>())
                {
                    if (cardControl.Discard)
                        retVal.Add(cardControl.Card);
                }
                return retVal;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            try
            {
                Size cardSize;
                if (position == CardPosition.Left || position == CardPosition.Right)
                    cardSize = new Size(this.Width, this.Height / 4);
                else
                    cardSize = new Size(this.Width / 4, this.Height);

                int x = 0;
                int y = 0;
                List<CardControl> lista = new List<CardControl>() { card1, card2, card3, card4 };
                foreach (var cardControl in lista)
                {
                    cardControl.Bounds = new Rectangle(x, y, cardSize.Width, cardSize.Height);
                    if (position == CardPosition.Left || position == CardPosition.Right)
                        y += cardControl.Height;
                    else
                        x += cardControl.Width;
                }
            }
            catch { }
        }
    }
}
