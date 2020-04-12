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
using System.Threading;
using MusClient.ServiceMusReference;

namespace MusClient.User_controls
{
    public partial class MakeTeamsControl : UserControl
    {
        IGeneralData generalData;
        public MakeTeamsControl(IGeneralData generalData)
        {
            InitializeComponent();
            this.generalData = generalData;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            generalData.TeamName = cmbTeam.Text;
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                string result = c.CreateTeam(generalData.GameName, generalData.TeamName, new string[] { generalData.UserName });
                if (result != "OK")
                    MessageBox.Show("ERROR AL INTENTAR CREAR EL EQUIPO: " + result);
                else
                {
                    btnOK.Enabled = false;
                    lblWaitingPlayers.Text = "Esperando al resto de jugadores";
                    CheckTeamsCreated();
                }
            }
        }
        void CheckTeamsCreated()
        {
            using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
            {
                while (true)
                {
                    MusData data = c.GetMusData(generalData.GameName);
                    if (data.MusTeams.Length == 2 &&
                        !string.IsNullOrEmpty(data.MusTeams[0].UserName1) &&
                        !string.IsNullOrEmpty(data.MusTeams[0].UserName2) &&
                        !string.IsNullOrEmpty(data.MusTeams[1].UserName1) &&
                        !string.IsNullOrEmpty(data.MusTeams[1].UserName2))
                    {
                        TeamsCreated?.Invoke(this, EventArgs.Empty);
                        break;
                    }
                    else
                    {
                        Application.DoEvents();
                        Thread.Sleep(500);
                        Application.DoEvents();
                    }
                }
            }
        }
        public event EventHandler TeamsCreated;
    }
}
