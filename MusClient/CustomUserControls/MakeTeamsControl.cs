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

namespace MusClient.CustomUserControls
{
    public partial class MakeTeamsControl : UserControl
    {
        IGeneralData generalData;
        public MakeTeamsControl(IGeneralData generalData)
        {
            InitializeComponent();
            this.generalData = generalData;
        }
        protected override void OnLoad(EventArgs e)
        {
            CheckTeamsCreated();

            base.OnLoad(e);
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
                    data = c.GetMusData(generalData.GameName, generalData.UserName);
                    if (data.MusTeams.Length == 2 &&
                        !string.IsNullOrEmpty(data.MusTeams[0].UserName1) &&
                        !string.IsNullOrEmpty(data.MusTeams[0].UserName2) &&
                        !string.IsNullOrEmpty(data.MusTeams[1].UserName1) &&
                        !string.IsNullOrEmpty(data.MusTeams[1].UserName2))
                    {
                        if (string.IsNullOrEmpty(generalData.TeamName))
                        {
                            if (data.MusTeams[0].UserName1 == generalData.UserName || data.MusTeams[0].UserName2 == generalData.UserName)
                                generalData.TeamName = data.MusTeams[0].TeamName;
                            else
                                generalData.TeamName = data.MusTeams[1].TeamName;
                        }
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

        public MusData MusData
        {
            get { return data; }
        }
        MusData data;
        public event EventHandler TeamsCreated;
    }
}
