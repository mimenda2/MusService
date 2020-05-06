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
        public void CleanDiscards()
        {
            foreach (var cardControl in this.Controls.OfType<CardControl>())
            {
                cardControl.Discard = false;
            }
        }
        public void ChangeDiscards(MusCard[] cards)
        {
            var checkedList = this.Controls.OfType<CardControl>().Where(x => x.Discard).ToList();
            for (int i = 0; i < cards.Length; i++)
            {
                checkedList[i].Card = cards[i];
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
        DateTime lastTimeDown = DateTime.MinValue;
        private void card1_MouseDown(object sender, MouseEventArgs e)
        {
            lastTimeDown = DateTime.Now;
            CardControl cardOrigin = sender as CardControl;
            cardOrigin.DoDragDrop(cardOrigin.GetHashCode().ToString(), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void card1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void card1_DragDrop(object sender, DragEventArgs e)
        {
            CardControl cardDest = sender as CardControl;
            string hashCodeOrigin = e.Data.GetData(DataFormats.Text).ToString();
            if (cardDest.GetHashCode().ToString() != hashCodeOrigin)
            {
                CardControl cardOrigin = this.Controls.OfType<CardControl>().First(x => x.GetHashCode().ToString() == hashCodeOrigin);
                MusCard musCardDest = cardDest.Card;
                cardDest.Card = cardOrigin.Card;
                cardOrigin.Card = musCardDest;
            }
            else
            {
                if ((DateTime.Now - lastTimeDown).TotalMilliseconds < 600)
                {
                    lastTimeDown = DateTime.MinValue;
                    CardControl card = sender as CardControl;
                    card.CheckCard = !card.CheckCard;
                }
            }
        }
    }
}
