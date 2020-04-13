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
using Common.Enums;

namespace MusClient.CustomUserControls
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
            this.Text = "PlayerControl";
        }
        public string UserNameAndTeam
        {
            get { return userNameAndTeam; }
            set
            {
                if (userNameAndTeam != value)
                {
                    userNameAndTeam = value;
                    this.Invalidate();
                }
            }
        }
        string userNameAndTeam;
        public CardPosition Position
        {
            get { return position; }
            set
            {
                if (position != value)
                {
                    position = value;
                    cardsControl1.Position = value;
                }
            }
        }
        CardPosition position = CardPosition.Bottom;

        public List<MusCard> Cards
        {
            get { return cardsControl1.Cards; }
            set
            {
                cardsControl1.Cards = value;
            }
        }
        public List<MusCard> Discards
        {
            get
            {
                return cardsControl1.Discards;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int textWidth = (int)e.Graphics.MeasureString(userNameAndTeam, this.Font).Width + 1;
            e.Graphics.DrawString(userNameAndTeam, this.Font, Brushes.Black, (this.Width - textWidth) / 2, cardsControl1.Bottom + 8);
        }
    }
}
