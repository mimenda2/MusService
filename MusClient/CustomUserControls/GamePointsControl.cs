using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusClient.Interface;

namespace MusClient.CustomUserControls
{
    public partial class GamePointsControl : UserControl, IMusChangePoints
    {
        public GamePointsControl()
        {
            InitializeComponent();
            BackColor = Color.Transparent;
        }

        public int? GamesWin
        {
            get
            {
                return this.Controls.OfType<GamePointControl>()?.Count(x => x.GameChecked);
            }
            set
            {
                
                int gamesWin = this.Controls.OfType<GamePointControl>()?.Count(x => x.GameChecked) ?? 0;
                if (gamesWin != value)
                {
                    while(gamesWin != value)
                    {
                        if (gamesWin > value) // des marcar
                            this.Controls.OfType<GamePointControl>().FirstOrDefault(x => x.GameChecked).GameChecked = false;
                        else // marcar
                            this.Controls.OfType<GamePointControl>().FirstOrDefault(x => !x.GameChecked).GameChecked = true;
                        gamesWin = this.Controls.OfType<GamePointControl>()?.Count(x => x.GameChecked) ?? 0;
                    }
                }
            }
        }
        public event EventHandler GamesWinChanged;

        private void gamePointControl2_GameCheckedChanged(object sender, EventArgs e)
        {
            GamesWinChanged?.Invoke(this, EventArgs.Empty);
        }

        public int UserPointsChanged { get; set; }
        public DateTime ChangePointsDate { get; set; } = DateTime.MaxValue;
        public int MusValor
        {
            get { return GamesWin.HasValue ? GamesWin.Value : 0; }
            set
            {
                this.GamesWin = value;
                this.Tag = value;
            }
        }
        public bool MusEnabled
        {
            get { return this.Enabled; }
            set { this.Enabled = value; }
        }
    }
}
