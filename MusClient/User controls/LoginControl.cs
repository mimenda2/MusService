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

namespace MusClient.User_controls
{
    public partial class LoginControl : UserControl, IGeneralData
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ServerIP = txtServerIP.Text;
            GameName = txtGameName.Text;
            UserName = txtUserName.Text;
            using (MyServiceClient c = new MyServiceClient(ServerIP))
            {
                string result = c.Login(UserName, GameName, "");
                if (result != "OK")
                    MessageBox.Show("ERROR AL LOGGUEAR: " + result);
                else
                {
                    grpLogin.Enabled = false;
                    lblWaitingPlayers.Text = "Esperando al resto de jugadores";
                    LoginFinished?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public string ServerIP { get; set; } = "";
        public string GameName { get; set; } = "LAS MESAS";
        public string TeamName { get; set; }
        public string UserName { get; set; } = "";

        public event EventHandler LoginFinished;
    }
}
