using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusClient.CustomUserControls
{
    public partial class GamePointsControl : UserControl
    {
        public GamePointsControl()
        {
            InitializeComponent();
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
    }
}
