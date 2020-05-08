using MusCommon.Enums;
using PruebasServicioMus.MusServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebasServicioMus
{
    public partial class Form : System.Windows.Forms.Form
    {
        const string serverIP = "localhost";
        public Form()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                string result = c.Login(txtUserName.Text, txtGameName.Text, "");
            }
            if (txtUserName.Text == "MIMENDA1")
                txtUserName.Text = "MIMENDA2";
            else if (txtUserName.Text == "MIMENDA2")
                txtUserName.Text = "MIMENDA3";
            else if (txtUserName.Text == "MIMENDA3")
                txtUserName.Text = "MIMENDA4";
        }

        private void btngetConnectedUsers_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                var users = c.GetConnectedUsers(txtGameName.Text);
                txtConnectedUsers.Text = String.Join(",", users);
            }
        }

        private void btnCreateTeam1_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                var result = c.CreateTeam(txtGameName.Text, txtTeamName1.Text, 
                    new string[2] { txtTeamUserA1.Text, txtTeamUserA2.Text});
            }
        }

        private void btnCreateTeam2_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                var result = c.CreateTeam(txtGameName.Text, txtTeamName2.Text,
                    new string[2] { txtTeamUserB1.Text, txtTeamUserB2.Text });
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                var result = c.StartGame(txtGameName.Text, int.Parse(txtPointToWin.Text));
            }

            MusData musData;
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                musData = c.GetMusData(txtGameName.Text,
                    txtTeamName1.Text, 
                    txtSelectedPlayer.Text);
            }
            txtNumCuentasA.Text = musData.MusTeams[0].Points.ToString();
            txtNumCuentasB.Text = musData.MusTeams[1].Points.ToString();

            bool isInA = musData.MusTeams[0].UserName1 == txtSelectedPlayer.Text ||
                musData.MusTeams[0].UserName2 == txtSelectedPlayer.Text;
            txtPlayer1A.Text = txtSelectedPlayer.Text;
            if (isInA)
            {
                bool isFirst = musData.MusTeams[0].UserName1 == txtSelectedPlayer.Text;
                txtPlayer2A.Text = isFirst ?
                    musData.MusTeams[0].UserName2 : musData.MusTeams[0].UserName1;
                if (isFirst)
                {
                    txtPlayer1B.Text = musData.MusTeams[1].UserName1;
                    txtPlayer2B.Text = musData.MusTeams[1].UserName2;
                }
                else
                {
                    txtPlayer1B.Text = musData.MusTeams[1].UserName2;
                    txtPlayer2B.Text = musData.MusTeams[1].UserName1;
                }
            }
            else
            {
                bool isFirst = musData.MusTeams[1].UserName1 == txtSelectedPlayer.Text;
                txtPlayer2A.Text = isFirst ?
                    musData.MusTeams[1].UserName2 : musData.MusTeams[1].UserName1;
                if (isFirst)
                {
                    txtPlayer1B.Text = musData.MusTeams[0].UserName2;
                    txtPlayer2B.Text = musData.MusTeams[0].UserName1;
                }
                else
                {
                    txtPlayer1B.Text = musData.MusTeams[0].UserName1;
                    txtPlayer2B.Text = musData.MusTeams[0].UserName2;
                }
            }

        }


        private void btnGetCards_Click(object sender, EventArgs e)
        {
            GetCards(txtTeamUserA1.Text);
            GetCards(txtTeamUserA2.Text);
            GetCards(txtTeamUserB1.Text);
            GetCards(txtTeamUserB2.Text);
        }
        void GetCards(string userName)
        { 
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                MusCard[] cards = c.GetCards(txtGameName.Text,
                    userName == txtPlayer1B.Text || userName == txtPlayer2B.Text ? txtTeamName2.Text : txtTeamName1.Text,
                    userName);
                TextBox card1 = txtPlayer1ACard1;
                TextBox card2 = txtPlayer1ACard2;
                TextBox card3 = txtPlayer1ACard3;
                TextBox card4 = txtPlayer1ACard4;
                if (userName == txtPlayer2A.Text)
                {
                    card1 = txtPlayer2ACard1;
                    card2 = txtPlayer2ACard2;
                    card3 = txtPlayer2ACard3;
                    card4 = txtPlayer2ACard4;
                }
                else if (userName == txtPlayer1B.Text)
                {
                    card1 = txtPlayer1BCard1;
                    card2 = txtPlayer1BCard2;
                    card3 = txtPlayer1BCard3;
                    card4 = txtPlayer1BCard4;
                }
                else if (userName == txtPlayer2B.Text)
                {
                    card1 = txtPlayer2BCard1;
                    card2 = txtPlayer2BCard2;
                    card3 = txtPlayer2BCard3;
                    card4 = txtPlayer2BCard4;
                }
                card1.Text = cards[0].ToString();
                card2.Text = cards[1].ToString();
                card3.Text = cards[2].ToString();
                card4.Text = cards[3].ToString();

            }
        }

        private void btnChangeNumA_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                c.ChangePoints(txtGameName.Text, 
                    txtTeamName1.Text, txtSelectedPlayer.Text, int.Parse(txtNumCuentasA.Text));
            }
        }

        private void btnChangeNumB_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                c.ChangePoints(txtGameName.Text,
                    txtTeamName2.Text, txtSelectedPlayer.Text, int.Parse(txtNumCuentasB.Text));
            }
        }

        private void btnNextRound_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                c.ResetRound(txtGameName.Text);
            }
            btnGetCards_Click(sender, e);
        }

        private void btnDiscardCards_Click(object sender, EventArgs e)
        {
            using (MyServiceClient c = new MyServiceClient(serverIP))
            {
                List<MusCard> discards = new List<MusCard>();
                if (chkPlayer2BCard1.Checked)
                    discards.Add((MusCard)Enum.Parse(typeof(MusCard), txtPlayer2BCard1.Text));
                if (chkPlayer2BCard2.Checked)
                    discards.Add((MusCard)Enum.Parse(typeof(MusCard), txtPlayer2BCard2.Text));
                if (chkPlayer2BCard3.Checked)
                    discards.Add((MusCard)Enum.Parse(typeof(MusCard), txtPlayer2BCard3.Text));
                if (chkPlayer2BCard4.Checked)
                    discards.Add((MusCard)Enum.Parse(typeof(MusCard), txtPlayer2BCard4.Text));
                var cards = c.ChangeCards(txtGameName.Text, txtTeamName2.Text, txtPlayer2B.Text, discards.ToArray());
                int i = 0;
                if (chkPlayer2BCard1.Checked)
                {
                    txtPlayer2BCard1.Text = cards[i].ToString();
                    i++;
                }
                if (chkPlayer2BCard2.Checked)
                {
                    txtPlayer2BCard2.Text = cards[i].ToString();
                    i++;
                }
                if (chkPlayer2BCard3.Checked)
                {
                    txtPlayer2BCard3.Text = cards[i].ToString();
                    i++;
                }
                if (chkPlayer2BCard4.Checked)
                {
                    txtPlayer2BCard4.Text = cards[i].ToString();
                    i++;
                }
                discards = new List<MusCard>();
                if (chkPlayer1BCard1.Checked)
                    discards.Add((MusCard)Enum.Parse(typeof(MusCard), txtPlayer1BCard1.Text));
                if (chkPlayer1BCard2.Checked)
                    discards.Add((MusCard)Enum.Parse(typeof(MusCard), txtPlayer1BCard2.Text));
                if (chkPlayer1BCard3.Checked)
                    discards.Add((MusCard)Enum.Parse(typeof(MusCard), txtPlayer1BCard3.Text));
                if (chkPlayer1BCard4.Checked)
                    discards.Add((MusCard)Enum.Parse(typeof(MusCard), txtPlayer1BCard4.Text));
                cards = c.ChangeCards(txtGameName.Text, txtTeamName1.Text, txtPlayer1B.Text, discards.ToArray());
                i = 0;
                if (chkPlayer1BCard1.Checked)
                {
                    txtPlayer1BCard1.Text = cards[i].ToString();
                    i++;
                }
                if (chkPlayer1BCard2.Checked)
                {
                    txtPlayer1BCard2.Text = cards[i].ToString();
                    i++;
                }
                if (chkPlayer1BCard3.Checked)
                {
                    txtPlayer1BCard3.Text = cards[i].ToString();
                    i++;
                }
                if (chkPlayer1BCard4.Checked)
                {
                    txtPlayer1BCard4.Text = cards[i].ToString();
                    i++;
                }
            }
        }

        private void txtGameName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblGameName_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEndGame_Click(object sender, EventArgs e)
        {
                using (MyServiceClient c = new MyServiceClient(serverIP))
                    c.FinishGame(txtGameName.Text);
        }

        private void btnChangeround_Click(object sender, EventArgs e)
        {
            int round = (int)nudNewRound.Value;
            using (MyServiceClient c = new MyServiceClient(serverIP))
                c.NextRound(txtGameName.Text, txtTeamName1.Text, txtSelectedPlayer.Text, round);
        }
    }
}
