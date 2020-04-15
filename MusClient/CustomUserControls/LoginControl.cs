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

namespace MusClient.CustomUserControls
{
    public partial class LoginControl : UserControl, IGeneralData
    {
        public LoginControl()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UserName))
                MessageBox.Show("Necesito un nombre de usuario");
            else
            {
                ServerIP = txtServerIP.Text;
                GameName = txtGameName.Text;
                UserName = txtUserName.Text;
                try
                {
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
                catch(Exception ex)
                {
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
