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
        IMusGeneralData generalData;
        MusData musData;
        public GameControl(IMusGeneralData generalData, MusData musData)
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
            gamePointsTeam1.GamesWin = gamePointsTeam2.GamesWin = 0;
            gamePointsTeam1.Tag = gamePointsTeam2.Tag = 0;


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

            EngageEvents();
        }
        void EngageEvents()
        {
            this.gamePointsTeam2.GamesWinChanged += gamePointsTeam1_GamesWinChanged;
            this.gamePointsTeam1.GamesWinChanged += gamePointsTeam1_GamesWinChanged;
            this.nudTeam2Points.ValueChanged += nudTeamPoints_ValueChanged;
            this.nudTeam1Points.ValueChanged += nudTeamPoints_ValueChanged;

            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 2000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);

            this.btnNextRound.Click += new System.EventHandler(this.btnNextRound_Click);
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            this.btnShowCards.Click += new System.EventHandler(this.btnShowCards_Click);
            this.cmbHandUser.SelectedIndexChanged += new System.EventHandler(this.cmbHandUser_SelectedIndexChanged);
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
        delegate void RefreshMusTracesDelegate(string[] traces);
        delegate void RefreshMusPointsDataDelegate(MusData musData);
        DateTime lastTimeTimer = DateTime.MinValue;
        bool ignoreChangePoints = false;

        void FinishChangePoints(IMusChangePoints iMusCtrl)
        {
            iMusCtrl.ChangePointsDate = DateTime.MaxValue;
        }
        private void ChangePointsNow()
        {
            try
            {
                using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                {
                    if ((DateTime.Now - nudTeam1Points.ChangePointsDate).TotalMilliseconds > 1000)
                        c.ChangePointsAsync(generalData.GameName, lblTeam1.Text, generalData.UserName, (int)nudTeam1Points.Value).
                            ContinueWith(x => FinishChangePoints(nudTeam1Points));
                    if ((DateTime.Now - nudTeam2Points.ChangePointsDate).TotalMilliseconds > 1000)
                        c.ChangePointsAsync(generalData.GameName, lblTeam2.Text, generalData.UserName, (int)nudTeam2Points.Value).
                            ContinueWith(x => FinishChangePoints(nudTeam2Points));
                    if ((DateTime.Now - gamePointsTeam1.ChangePointsDate).TotalMilliseconds > 1000)
                        c.ChangeGamePointsAsync(generalData.GameName, lblTeam1.Text, generalData.UserName, gamePointsTeam1.GamesWin ?? 0).
                            ContinueWith(x => FinishChangePoints(gamePointsTeam1));
                    if ((DateTime.Now - gamePointsTeam2.ChangePointsDate).TotalMilliseconds > 1000)
                        c.ChangeGamePointsAsync(generalData.GameName, lblTeam2.Text, generalData.UserName, gamePointsTeam2.GamesWin ?? 0).
                            ContinueWith(x => FinishChangePoints(gamePointsTeam2));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cambiar puntos: " + ex.Message;
            }
        }
        void RefreshMusPointsData(MusData musDataTemp)
        {
            if (musDataTemp != null && musData != null && musData.MusTeams?.Length == 2)
            {
                if (txtTraces.InvokeRequired)
                    txtTraces.BeginInvoke(new RefreshMusPointsDataDelegate(RefreshMusPointsData), new object[] { musDataTemp });
                else
                {
                    if (musDataTemp != null && musData != null && musData.MusTeams?.Length == 2)
                    {
                        this.musData = musDataTemp;

                        ChangePointsInControl(nudTeam1Points, musData.MusTeams[0].Points);
                        ChangePointsInControl(nudTeam2Points,  musData.MusTeams[1].Points);

                        ChangePointsInControl(gamePointsTeam1, musData.MusTeams[0].GamePoints);
                        ChangePointsInControl(gamePointsTeam2, musData.MusTeams[1].GamePoints);
                    }
                }
            }
        }
        void ChangePointsInControl(IMusChangePoints musCtrl, int valor)
        {
            if (musCtrl != null && musCtrl.ChangePointsDate == DateTime.MaxValue &&
                musCtrl.MusValor != valor)
            {
                musCtrl.MusEnabled = false;
                if (musCtrl != null && musCtrl.ChangePointsDate == DateTime.MaxValue && musCtrl.MusValor != valor)
                {
                    ignoreChangePoints = true;
                    musCtrl.MusValor = valor;
                    ignoreChangePoints = false;
                }
                musCtrl.MusEnabled = true;
            }
        }
        void RefreshMusTraces(string[] traces)
        {
            if (txtTraces.InvokeRequired)
                txtTraces.BeginInvoke(new RefreshMusTracesDelegate(RefreshMusTraces), new object[] { traces });
            else
            {
                txtTraces.Text = String.Join(Environment.NewLine, traces);
                if (this.txtTraces.Text.Length > 1)
                {
                    this.txtTraces.SelectionStart = txtTraces.Text.Length - 1;
                    txtTraces.ScrollToCaret();
                }

                if (btnNextRound.Enabled)
                {
                    int remoteRound = -1;
                    foreach (var t in musData.MusTeams)
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
                }
                if (!string.IsNullOrEmpty(musData.HandUser))
                {
                    HandUser = musData.HandUser;
                }
            }
        }
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (this.Visible &&
                DateTime.Now - lastTimeTimer >= TimeSpan.FromMilliseconds(timerRefresh.Interval - 10))
            {
                lastTimeTimer = DateTime.Now;
                try
                {
                    ChangePointsNow();

                    using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                    {
                        c.GetMusDataAsync(generalData.GameName, generalData.UserName).
                                ContinueWith(req => RefreshMusPointsData(req.Result as MusData));
                        c.GetTracesAsync(generalData.GameName).
                            ContinueWith(req => RefreshMusTraces(req.Result as string[]));
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "ERROR EN EL TIMER: " + ex.Message;
                }
            }
        }
        private void nudTeamPoints_ValueChanged(object sender, EventArgs e)
        {
            if (!ignoreChangePoints)
                (sender as IMusChangePoints).ChangePointsDate = DateTime.Now;
        }
        private void gamePointsTeam1_GamesWinChanged(object sender, EventArgs e)
        {
            if (!ignoreChangePoints)
                (sender as IMusChangePoints).ChangePointsDate = DateTime.Now;
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

        #region Hand
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
        #endregion
    }
}
