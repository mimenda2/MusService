using MusClient.Interface;
using MusClient.User_controls;
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
    public partial class MusClient : Form
    {
        IGeneralData generalData;
        LoginControl loginControl;
        MakeTeamsControl makeTeamsControl;
        GameControl gameControl;

        public MusClient()
        {
            InitializeComponent();
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
            txtServerIP.Text = generalData.ServerIP;
            txtUserName.Text = generalData.UserName;

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

            gameControl = new GameControl(generalData);
            gameControl.Name = "gameControl";
            gameControl.Location = new Point(10, 50);
            gameControl.Size = new Size(this.Width - 20, this.Height - 60);
            gameControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Controls.Add(gameControl);
        }
        #endregion

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
                    }
                }
            }
        }
        MusState musState = MusState.Initial;

    }
}
