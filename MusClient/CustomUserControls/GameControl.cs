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
using MusClient.ServiceMusReference;
using System.IO;

namespace MusClient.CustomUserControls
{
    public partial class GameControl : UserControl
    {
        IGeneralData generalData;
        MusData musData;
        public GameControl(IGeneralData generalData, MusData musData)
        {
            InitializeComponent();
            this.Text = "GameControl";

            Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MusClient.Res.tapeteverde.jpg");
            this.BackgroundImage = new Bitmap(stream);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            this.generalData = generalData;
            this.musData = musData;
            playerControl1.UserNameAndTeam = generalData.UserName + $" ({generalData.TeamName})";
            lblTeam1.Text = musData.MusTeams[0].TeamName;
            lblTeam2.Text = musData.MusTeams[1].TeamName;
            nudTeam1Points.Value = nudTeam2Points.Value = 0;
            foreach (var c in musData.MusTeams)
            {
                if (c.UserName1 == generalData.UserName || c.UserName2 == generalData.UserName)
                {
                    playerControl3.UserNameAndTeam = c.UserName1 != generalData.UserName ? c.UserName1 : c.UserName2;
                    playerControl3.UserNameAndTeam += $" ({c.TeamName})";
                }
                else
                {
                    playerControl2.UserNameAndTeam = c.UserName1 + $" ({c.TeamName})";
                    playerControl4.UserNameAndTeam = c.UserName2 + $" ({c.TeamName})";
                }
            }
            playerControl2.Cards = playerControl3.Cards = playerControl4.Cards =
                new List<Common.Enums.MusCard>()
                {
                    Common.Enums.MusCard.Back,
                    Common.Enums.MusCard.Back,
                    Common.Enums.MusCard.Back,
                    Common.Enums.MusCard.Back,
                };
        }

        protected override void OnResize(EventArgs e)
        {
            int border = 20;
            playerControl1.Location = new Point((this.Width - playerControl1.Width) / 2, this.Height - playerControl1.Height - border);
            playerControl3.Location = new Point(playerControl1.Left, border);

            playerControl2.Location = new Point(this.Width - playerControl2.Width - border, (this.Height - playerControl2.Height) / 2);
            playerControl4.Location = new Point(border, playerControl2.Top);

            txtTraces.Bounds = new Rectangle(playerControl4.Right + border, playerControl3.Bottom + border,
                playerControl2.Left - playerControl4.Right - (2 * border),
                playerControl1.Top - playerControl3.Bottom - (2 * border));
            base.OnResize(e);
        }

        #region Puntuacion
        private void btnChangePoints_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                c.ChangePoints(generalData.GameName, lblTeam1.Text, generalData.UserName, (int)nudTeam1Points.Value);
                c.ChangePoints(generalData.GameName, lblTeam2.Text, generalData.UserName, (int)nudTeam2Points.Value);
            }
            changingPoints = false;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (!changingPoints)
            {
                using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                {
                    var data = c.GetMusData(generalData.GameName, generalData.UserName);
                    nudTeam1Points.Value = data.MusTeams[0].Points;
                    nudTeam2Points.Value = data.MusTeams[1].Points;
                    var traces = c.GetTraces(generalData.GameName);
                    txtTraces.Text = String.Join(Environment.NewLine, traces); 
                }
            }
        }
        bool changingPoints = false;
        private void nudTeam1Points_Enter(object sender, EventArgs e)
        {
            changingPoints = true;
        }

        private void nudTeam2Points_Enter(object sender, EventArgs e)
        {
            changingPoints = true;
        }

        private void nudTeam2Points_Leave(object sender, EventArgs e)
        {
            changingPoints = false;
        }

        private void nudTeam1Points_Leave(object sender, EventArgs e)
        {
            changingPoints = false;
        }
        #endregion

        int round = 0;
        private void btnNextRound_Click(object sender, EventArgs e)
        {
            playerControl1.Cards = new List<Common.Enums.MusCard>()
            {
                Common.Enums.MusCard.Empty,
                Common.Enums.MusCard.Empty,
                Common.Enums.MusCard.Empty,
                Common.Enums.MusCard.Empty
            };
            round++;
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                c.NextRound(generalData.GameName, generalData.TeamName, generalData.UserName, round);
            }
            NextRoundRequest?.Invoke(this, EventArgs.Empty);
            btnNextRound.Text = $"Siguiente ronda {(round+1)}";
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                var cards = c.GetCards(generalData.GameName, generalData.UserName);
                playerControl1.Cards = cards.ToList();
            }
        }
        public event EventHandler NextRoundRequest;

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            var discards = playerControl1.Discards;
            if (discards?.Count == 0)
                MessageBox.Show("Selecciona cartas para descartar!");
            else
            {
                using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                {
                    var newCards = c.ChangeCards(generalData.GameName, generalData.UserName, discards.ToArray());
                    var cards = playerControl1.Cards;
                    int j = 0;
                    for(int i = 0; i < cards.Count; i++)
                    {
                        if (discards.Contains(cards[i]))
                        {
                            cards[i] = newCards[j];
                            j++;
                        }
                    }
                    playerControl1.Cards = cards;
                }
            }
        }

        private void btnShowCards_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                var cardsPerUser = c.GetAllUserCards(generalData.GameName, generalData.UserName);
            }
        }
    }
}
