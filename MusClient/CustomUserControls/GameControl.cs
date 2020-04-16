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
            playerControl1.UserName = generalData.UserName;
            playerControl1.TeamName = generalData.TeamName;
            lblTeam1.Text = musData.MusTeams[0].TeamName;
            lblTeam2.Text = musData.MusTeams[1].TeamName;
            nudTeam1Points.Value = nudTeam2Points.Value = 0;
            nudTeam1Points.Tag = nudTeam2Points.Tag = (int)0;

            cmbHandUser.Items.Clear();
            bool primero = true;
            foreach (var t in musData.MusTeams)
            {
                if (t.UserName2 == generalData.UserName)
                    primero = false;
                cmbHandUser.Items.Add(t.UserName1);
                cmbHandUser.Items.Add(t.UserName2);
            }
            if (musData.MusTeams[1].UserName1 == generalData.UserName || musData.MusTeams[1].UserName2 == generalData.UserName)
                primero = !primero;

            foreach (var t in musData.MusTeams)
            {
                if (t.UserName1 == generalData.UserName || t.UserName2 == generalData.UserName)
                {
                    playerControl3.UserName = t.UserName1 != generalData.UserName ? t.UserName1 : t.UserName2;
                    playerControl3.TeamName = t.TeamName;
                }
                else if (primero)
                {
                    playerControl2.UserName = t.UserName1;
                    playerControl2.TeamName = t.TeamName;

                    playerControl4.UserName = t.UserName2;
                    playerControl4.TeamName = t.TeamName;
                }
                else
                {
                    playerControl2.UserName = t.UserName2;
                    playerControl2.TeamName = t.TeamName;

                    playerControl4.UserName = t.UserName1;
                    playerControl4.TeamName = t.TeamName;
                }
            }
            playerControl2.Cards = playerControl3.Cards = playerControl4.Cards =
                new List<MusCommon.Enums.MusCard>()
                {
                    MusCommon.Enums.MusCard.Back,
                    MusCommon.Enums.MusCard.Back,
                    MusCommon.Enums.MusCard.Back,
                    MusCommon.Enums.MusCard.Back,
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

            btnShowCards.Location = new Point(border, this.Height - btnShowCards.Height - border);

            base.OnResize(e);
        }

        #region Puntuacion
        private void btnChangePoints_Click(object sender, EventArgs e)
        {
            try
            {
                using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                {
                    if ((int)nudTeam1Points.Value != (int)nudTeam1Points.Tag)
                        c.ChangePoints(generalData.GameName, lblTeam1.Text, generalData.UserName, (int)nudTeam1Points.Value);
                    if ((int)nudTeam2Points.Value != (int)nudTeam2Points.Tag)
                        c.ChangePoints(generalData.GameName, lblTeam2.Text, generalData.UserName, (int)nudTeam2Points.Value);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cambiar puntos: " + ex.Message;
            }
            changingPoints = false;
        }

        DateTime lastTimeTimer = DateTime.MinValue;
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (this.Visible && 
                DateTime.Now - lastTimeTimer >= TimeSpan.FromMilliseconds(timerRefresh.Interval - 10))
            {
                lastTimeTimer = DateTime.Now;
                try
                {
                    if (!changingPoints)
                    {
                        using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                        {
                            musData = c.GetMusData(generalData.GameName, generalData.UserName);
                            if (musData != null && musData.MusTeams?.Length == 2)
                            {
                                nudTeam1Points.Value = musData.MusTeams[0].Points;
                                nudTeam2Points.Value = musData.MusTeams[1].Points;
                                nudTeam1Points.Tag = (int)nudTeam1Points.Value;
                                nudTeam2Points.Tag = (int)nudTeam2Points.Value;

                                var traces = c.GetTraces(generalData.GameName);
                                txtTraces.Text = String.Join(Environment.NewLine, traces);
                                if (this.txtTraces.Text.Length > 1)
                                {
                                    this.txtTraces.SelectionStart = txtTraces.Text.Length - 1;
                                    txtTraces.ScrollToCaret();
                                }

                                int remoteRound = -1;
                                foreach(var t in musData.MusTeams)
                                {
                                    if (t.RoundUserName1 != t.RoundUserName2)
                                    {
                                        remoteRound = -1;
                                        break;
                                    }
                                    else if (remoteRound == -1)
                                        remoteRound = t.RoundUserName1;
                                    else if (remoteRound != t.RoundUserName1)
                                    {
                                        remoteRound = -1;
                                        break;
                                    }
                                }
                                if (remoteRound != -1 && remoteRound != round)
                                {
                                    round = remoteRound;
                                    btnNextRound.Text = $"Siguiente ronda {(round + 1)}";
                                }
                                if (!string.IsNullOrEmpty(musData.HandUser))
                                {
                                    HandUser = musData.HandUser;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "ERROR EN EL TIMER: " + ex.Message;
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

        #region Next round
        int round = 0;
        private void btnNextRound_Click(object sender, EventArgs e)
        {
            btnNextRound.Enabled = false;
            btnNextRound.Text = "Esperando al resto...";
            Application.DoEvents();
            playerControl1.Cards = new List<MusCommon.Enums.MusCard>()
            {
                MusCommon.Enums.MusCard.Empty,
                MusCommon.Enums.MusCard.Empty,
                MusCommon.Enums.MusCard.Empty,
                MusCommon.Enums.MusCard.Empty
            };
            round++;
            MusCommon.ExecuteMethod.ExecuteMethodNTimes(GoToNextround, 3);

            NextRoundRequest?.Invoke(this, EventArgs.Empty);

            MusCommon.ExecuteMethod.ExecuteMethodNTimes(GetCards, 3);

            playerControl2.Cards = playerControl3.Cards = playerControl4.Cards = new List<MusCommon.Enums.MusCard>()
            {
                MusCommon.Enums.MusCard.Back,
                MusCommon.Enums.MusCard.Back,
                MusCommon.Enums.MusCard.Back,
                MusCommon.Enums.MusCard.Back
            };
            btnNextRound.Text = $"Siguiente ronda {(round+1)}";
            btnNextRound.Enabled = true;

            txtTraces.Select();
        }
        bool GoToNextround()
        {
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                c.NextRound(generalData.GameName, generalData.TeamName, generalData.UserName, round);
            }
            return true;
        }
        bool GetCards()
        {
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                var cards = c.GetCards(generalData.GameName, generalData.TeamName, generalData.UserName);
                playerControl1.Cards = cards.ToList();
            }
            return true;
        }
        public event EventHandler NextRoundRequest;
        #endregion  

        #region Cards
        private void btnDiscard_Click(object sender, EventArgs e)
        {
            if (playerControl1.Discards?.Count == 0)
                MessageBox.Show("Selecciona cartas para descartar!");
            else
            {
                MusCommon.ExecuteMethod.ExecuteMethodNTimes(Discard, 3);
            }
            playerControl1.CleanDiscards();
            txtTraces.Select();
        }
        bool Discard()
        {
            var discards = playerControl1.Discards;
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                var newCards = c.ChangeCards(generalData.GameName, generalData.TeamName, generalData.UserName, discards.ToArray());
                playerControl1.ChangeDiscards(newCards);
            }
            return true;
        }
        private void btnShowCards_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                var musData = c.GetAllUserCards(generalData.GameName, generalData.UserName);
                bool primero = true;
                foreach (var t in musData.MusTeams)
                {
                    if (t.UserName2 == generalData.UserName)
                        primero = false;
                }
                if (musData.MusTeams[1].UserName1 == generalData.UserName || musData.MusTeams[1].UserName2 == generalData.UserName)
                    primero = !primero;
                foreach (var t in musData.MusTeams)
                {
                    if (t.UserName1 == generalData.UserName || t.UserName2 == generalData.UserName)
                    {
                        playerControl3.Cards = t.UserName1 == generalData.UserName ? t.CardsUser2.ToList() : t.CardsUser1.ToList(); 
                    }
                    else if (primero)
                    {
                        playerControl2.Cards = t.CardsUser1.ToList(); 
                        playerControl4.Cards = t.CardsUser2.ToList();
                    }
                    else
                    {
                        playerControl2.Cards = t.CardsUser2.ToList();
                        playerControl4.Cards = t.CardsUser1.ToList();
                    }
                }
            }
            txtTraces.Select();
        }
        #endregion

        public string HandUser
        {
            set
            {
                if (handUser != value)
                {
                    handUser = value;
                    foreach (var ctrl in this.Controls.OfType<PlayerControl>())
                        ctrl.BackColor = (ctrl.UserName == handUser) ? Color.DarkMagenta : Color.Firebrick;

                    changeUser = false;
                    cmbHandUser.SelectedItem = handUser;
                    changeUser = true;
                }
            }
        }
        string handUser;

        bool changeUser = true;
        private void cmbHandUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changeUser)
            {
                using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                {
                    string newHand = cmbHandUser.SelectedItem.ToString();
                    c.ChangeHand(generalData.GameName, generalData.UserName, newHand);
                    HandUser = newHand;
                }
            }
        }
    }
}
