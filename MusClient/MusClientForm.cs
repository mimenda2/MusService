using MusClient.Interface;
using MusClient.CustomUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusClient
{
    public partial class MusClientForm : Form
    {
        IGeneralData generalData;
        LoginControl loginControl;
        MakeTeamsControl makeTeamsControl;
        GameControl gameControl;

        public MusClientForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                State = MusState.FinishGame;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            State = MusState.Login;
        }
        
        #region Wait for players
        void WaitForPlayers()
        {
            string[] players = null;

            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                players = null;
                while (players?.Length != 4)
                {
                    players = c.GetConnectedUsers(generalData.GameName);
                    if (players?.Length == 4)
                        State = MusState.MakeTeams;
                    else
                    {
                        Application.DoEvents();
                        Thread.Sleep(500);
                        Application.DoEvents();
                    }
                }
            }
        }
        #endregion

        #region Make teams
        void WaitForAllPlayersInNextRound()
        {
            while (true)
            {
                int round = -1;
                using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                {
                    var musData = c.GetMusData(generalData.GameName, generalData.UserName);
                    foreach (var t in musData.MusTeams)
                    {
                        if (round < 0)
                        {
                            if (t.RoundUserName1 != t.RoundUserName2)
                                break;
                            round = t.RoundUserName1;
                        }
                        if (t.RoundUserName1 != round || t.RoundUserName2 != round)
                        {
                            round = -1;
                            break;
                        }
                    }
                }
                if (round > 0)
                    break;
                else
                {
                    Application.DoEvents();
                    Thread.Sleep(500);
                    Application.DoEvents();
                }
            }
        }
        #endregion

        #region Make teams
        void MakeTeams()
        {
            loginControl.Visible = false;

            makeTeamsControl = new MakeTeamsControl(generalData);
            makeTeamsControl.Name = "makeTeamsControl";
            makeTeamsControl.Location = new Point(10, 50);
            makeTeamsControl.TeamsCreated += MakeTeamsControl_TeamsCreated;
            this.Controls.Add(makeTeamsControl);
        }
        private void MakeTeamsControl_TeamsCreated(object sender, EventArgs e)
        {
            State = MusState.StartGame;
        }
        #endregion

        #region DoLogin
        void DoLogin()
        {
            loginControl = new LoginControl();
            loginControl.Name = "loginControl";
            loginControl.Location = new Point(10, 50);
            loginControl.LoginFinished += LoginControl_LoginFinished;
            this.Controls.Add(loginControl);
        }
        private void LoginControl_LoginFinished(object sender, EventArgs e)
        {
            generalData = loginControl as IGeneralData;
            State = MusState.WaitingPlayers;
        }
        #endregion

        #region Start Game
        void StartGame()
        {
            makeTeamsControl.Visible = false;

            gameControl = new GameControl(generalData, makeTeamsControl.MusData);
            gameControl.Name = "gameControl";
            gameControl.Location = new Point(10, 10);
            gameControl.Dock = DockStyle.Fill;
            gameControl.NextRoundRequest += GameControl_NextRoundRequest;
            this.Controls.Add(gameControl);
        }

        private void GameControl_NextRoundRequest(object sender, EventArgs e)
        {
            State = MusState.NextRoundRequest;
        }
        #endregion

        void FinishGame()
        {
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                c.FinishGame(generalData.GameName);
        }

        MusState State
        {
            get { return musState; }
            set
            {
                if (musState != value)
                {
                    musState = value;
                    switch(musState)
                    {
                        case MusState.Login:
                            DoLogin();
                            break;
                        case MusState.WaitingPlayers:
                            WaitForPlayers();
                            break;
                        case MusState.MakeTeams:
                            MakeTeams();
                            break;
                        case MusState.StartGame:
                            StartGame();
                            break;
                        case MusState.NextRoundRequest:
                            WaitForAllPlayersInNextRound();
                            State = MusState.NextRound;
                            break;
                        case MusState.NextRound:
                            break;
                        case MusState.FinishGame:
                            FinishGame();
                            break;
                    }
                }
            }
        }
        MusState musState = MusState.Initial;

    }
}
