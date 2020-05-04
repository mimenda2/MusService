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
        IMusGeneralData generalData;
        public MakeTeamsControl(IMusGeneralData generalData)
        {
            InitializeComponent();
            this.generalData = generalData;
        }
        protected override void OnLoad(EventArgs e)
        {
            CheckTeamsCreated(true);
            btnOK.Select();
            base.OnLoad(e);
        }
        int tries = 0;
        private void btnOK_Click(object sender, EventArgs e)
        {
            generalData.TeamName = radTeam1.Checked ? radTeam1.Text : radTeam2.Checked ? radTeam2.Text : GetRandomTeam();
            ConnectToTeam();
        }
        void ConnectToTeam()
        { 
            try
            {
                tries++;
                TraceClientExtensions.TraceMessage(System.Diagnostics.TraceEventType.Information, 1,
                    $"Uniendose a equipo {generalData.TeamName} con el usuario {generalData.UserName}");

                using (MyServiceClient c = new MyServiceClient(generalData.ServerIP))
                {
                    string result = c.CreateTeam(generalData.GameName, generalData.TeamName, new string[] { generalData.UserName });
                    if (result != "OK")
                    {
                        if (radRandom.Checked && tries < 2)
                        {
                            generalData.TeamName = generalData.TeamName == radTeam1.Text ? radTeam2.Text : radTeam1.Text;
                            ConnectToTeam();
                        }
                        else
                            MessageBox.Show("ERROR AL INTENTAR CREAR EL EQUIPO: " + result);
                    }
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
        string GetRandomTeam()
        {
            return (DateTime.Now.Second % 2 == 0) ? radTeam1.Text: radTeam2.Text;
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
                            {
                                if (data.MusTeams.Length > 0)
                                {
                                    foreach(var t in data.MusTeams)
                                    {
                                        if (t.UserName1 == generalData.UserName || t.UserName2 == generalData.UserName)
                                        {
                                            radTeam1.Checked = t.TeamName == radTeam1.Text ? true : false;
                                            radTeam2.Checked = t.TeamName == radTeam2.Text ? true : false;
                                            break;
                                        }
                                    }
                                }
                                return;
                            }
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

        bool changing = false;
        private void radTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (!changing)
            {
                changing = true;
                radTeam1.Checked = sender == radTeam1;
                radTeam2.Checked = sender == radTeam2;
                radRandom.Checked = sender == radRandom;
                changing = false;
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(this, EventArgs.Empty);
            }
            base.OnKeyDown(e);
        }
    }
}
