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
using MusCommon.Enums;

namespace MusClient.CustomUserControls
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();

            this.Text = "PlayerControl";
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    this.Invalidate();
                }
            }
        }
        string userName;
        public string TeamName
        {
            get { return teamName; }
            set
            {
                if (teamName != value)
                {
                    teamName = value;
                    this.Invalidate();
                }
            }
        }
        string teamName;
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
            string userNameAndTeam = $"{UserName} ({TeamName})";
            int textWidth = (int)e.Graphics.MeasureString(userNameAndTeam, this.Font).Width + 1;
            e.Graphics.DrawString(userNameAndTeam, this.Font, Brushes.Black, (this.Width - textWidth) / 2, cardsControl1.Bottom + 8);
        }
    }
}
