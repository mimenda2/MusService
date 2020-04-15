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
            CheckTeamsCreated(true);

            base.OnLoad(e);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                TraceClientExtensions.TraceMessage(System.Diagnostics.TraceEventType.Information, 1,
                    $"Uniendose a equipo {generalData.TeamName} con el usuario {generalData.UserName}");

                generalData.TeamName = radTeam1.Checked ? radTeam1.Text : radTeam2.Text;
                using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                {
                    string result = c.CreateTeam(generalData.GameName, generalData.TeamName, new string[] { generalData.UserName });
                    if (result != "OK")
                        MessageBox.Show("ERROR AL INTENTAR CREAR EL EQUIPO: " + result);
                    else
                    {
                        btnOK.Enabled = false;
                        lblWaitingPlayers.Text = "Esperando al resto de jugadores";
                        CheckTeamsCreated(false);
                    }
                }
            }
            catch (Exception ex)
            {
                TraceClientExtensions.TraceMessage(System.Diagnostics.TraceEventType.Error, 1, 
                    $"Error al entrar en el equipo {generalData.TeamName} con el usuario {generalData.UserName}: {ex.ToString()}");
                MessageBox.Show("Error al hacer login: " + ex.Message);
            }
        }
        void CheckTeamsCreated(bool onlyCheckOnce)
        {
            try
            {
                TraceClientExtensions.TraceMessage(System.Diagnostics.TraceEventType.Information, 1,
                    $"CheckTeamsCreated {generalData.TeamName} con el usuario {generalData.UserName}");

                using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                {
                    while (true)
                    {
                        if (IsDisposed || ParentForm.Disposing || ParentForm.IsDisposed)
                            return;
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
                            if (onlyCheckOnce)
                                return;
                            Application.DoEvents();
                            Thread.Sleep(1000);
                            Application.DoEvents();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TraceClientExtensions.TraceMessage(System.Diagnostics.TraceEventType.Error, 1,
                    $"Error al chequear equipos {generalData.TeamName} con el usuario {generalData.UserName}");
                MessageBox.Show("Error al chequear equipos: " + ex.Message);
            }
        }

        public MusData MusData
        {
            get { return data; }
        }
        MusData data;
        public event EventHandler TeamsCreated;

        private void radTeam1_CheckedChanged(object sender, EventArgs e)
        {
            if (radTeam1.Checked)
                radTeam2.Checked = false;
        }

        private void radTeam2_CheckedChanged(object sender, EventArgs e)
        {
            if (radTeam2.Checked)
                radTeam1.Checked = false;
        }
    }
}
