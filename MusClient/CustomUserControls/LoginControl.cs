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
using System.Diagnostics;

namespace MusClient.CustomUserControls
{
    public partial class LoginControl : UserControl, IMusGeneralData
    {
        public LoginControl()
        {
            InitializeComponent();

            cmbGameName.SelectedIndex = 0;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            TraceClientExtensions.TraceMessage(TraceEventType.Information, 1, $"Intentando hacer login con el usuario {txtUserName.Text}");
            if (string.IsNullOrEmpty(txtUserName.Text))
                MessageBox.Show("Necesito un nombre de usuario");
            else
            {
                ServerIP = txtServerIP.Text;
                GameName = cmbGameName.Text;
                UserName = txtUserName.Text;
                try
                {
                    using (MyServiceClient c = new MyServiceClient(ServerIP))
                    {
                        string result = c.Login(UserName, GameName, "");
                        if (result != "OK")
                        {
                            TraceClientExtensions.TraceMessage(TraceEventType.Error, 1, 
                                $"Error al hacer login con el usuario {txtUserName.Text}: {result}");
                            MessageBox.Show("ERROR AL LOGGUEAR: " + result);
                        }
                        else
                        {
                            grpLogin.Enabled = false;
                            lblWaitingPlayers.Text = "Esperando al resto de jugadores";
                            LoginFinished?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
                catch(Exception ex)
                {
                    TraceClientExtensions.TraceMessage(TraceEventType.Error, 1, $"Error al hacer login con el usuario {txtUserName.Text}: {ex.ToString()}");
                    MessageBox.Show("Error al hacer login: " + ex.Message);

                }
            }
        }

        public string ServerIP { get; set; } = "";
        public string GameName { get; set; } = "LAS MESAS";
        public string TeamName { get; set; }
        public string UserName { get; set; } = "";

        public event EventHandler LoginFinished;


        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnLogin_Click(this, EventArgs.Empty);
        }
    }
}
