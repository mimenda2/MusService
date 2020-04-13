namespace PruebasServicioMus
{
    partial class Form
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblGameName = new System.Windows.Forms.Label();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.btngetConnectedUsers = new System.Windows.Forms.Button();
            this.txtConnectedUsers = new System.Windows.Forms.TextBox();
            this.txtTeamUserA1 = new System.Windows.Forms.TextBox();
            this.txtTeamName1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTeamUserA2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTeamUserB2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTeamName2 = new System.Windows.Forms.TextBox();
            this.txtTeamUserB1 = new System.Windows.Forms.TextBox();
            this.btnCreateTeam1 = new System.Windows.Forms.Button();
            this.btnCreateTeam2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPointToWin = new System.Windows.Forms.TextBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.txtPlayer2B = new System.Windows.Forms.TextBox();
            this.txtPlayer2A = new System.Windows.Forms.TextBox();
            this.txtPlayer1B = new System.Windows.Forms.TextBox();
            this.txtPlayer1A = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSelectedPlayer = new System.Windows.Forms.TextBox();
            this.txtPlayer1BCard1 = new System.Windows.Forms.TextBox();
            this.txtPlayer1BCard2 = new System.Windows.Forms.TextBox();
            this.txtPlayer1BCard4 = new System.Windows.Forms.TextBox();
            this.txtPlayer1BCard3 = new System.Windows.Forms.TextBox();
            this.txtPlayer2BCard4 = new System.Windows.Forms.TextBox();
            this.txtPlayer2BCard3 = new System.Windows.Forms.TextBox();
            this.txtPlayer2BCard2 = new System.Windows.Forms.TextBox();
            this.txtPlayer2BCard1 = new System.Windows.Forms.TextBox();
            this.txtPlayer2ACard1 = new System.Windows.Forms.TextBox();
            this.txtPlayer2ACard2 = new System.Windows.Forms.TextBox();
            this.txtPlayer2ACard3 = new System.Windows.Forms.TextBox();
            this.txtPlayer2ACard4 = new System.Windows.Forms.TextBox();
            this.txtPlayer1ACard4 = new System.Windows.Forms.TextBox();
            this.txtPlayer1ACard3 = new System.Windows.Forms.TextBox();
            this.txtPlayer1ACard2 = new System.Windows.Forms.TextBox();
            this.txtPlayer1ACard1 = new System.Windows.Forms.TextBox();
            this.btnGetCards = new System.Windows.Forms.Button();
            this.txtNumCuentasA = new System.Windows.Forms.TextBox();
            this.btnChangeNumA = new System.Windows.Forms.Button();
            this.btnChangeNumB = new System.Windows.Forms.Button();
            this.txtNumCuentasB = new System.Windows.Forms.TextBox();
            this.btnNextRound = new System.Windows.Forms.Button();
            this.chkPlayer2BCard1 = new System.Windows.Forms.CheckBox();
            this.chkPlayer2BCard2 = new System.Windows.Forms.CheckBox();
            this.chkPlayer2BCard3 = new System.Windows.Forms.CheckBox();
            this.chkPlayer2BCard4 = new System.Windows.Forms.CheckBox();
            this.chkPlayer1BCard4 = new System.Windows.Forms.CheckBox();
            this.chkPlayer1BCard3 = new System.Windows.Forms.CheckBox();
            this.chkPlayer1BCard2 = new System.Windows.Forms.CheckBox();
            this.chkPlayer1BCard1 = new System.Windows.Forms.CheckBox();
            this.btnDiscardCards = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(114, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 20);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Text = "MiMenda1";
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(96, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nombre de usuario";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(15, 90);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Location = new System.Drawing.Point(12, 55);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(94, 13);
            this.lblGameName.TabIndex = 4;
            this.lblGameName.Text = "Nombre de partida";
            this.lblGameName.Click += new System.EventHandler(this.lblGameName_Click);
            // 
            // txtGameName
            // 
            this.txtGameName.Location = new System.Drawing.Point(114, 52);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(121, 20);
            this.txtGameName.TabIndex = 3;
            this.txtGameName.Text = "LAS MESAS";
            this.txtGameName.TextChanged += new System.EventHandler(this.txtGameName_TextChanged);
            // 
            // btngetConnectedUsers
            // 
            this.btngetConnectedUsers.Location = new System.Drawing.Point(288, 20);
            this.btngetConnectedUsers.Name = "btngetConnectedUsers";
            this.btngetConnectedUsers.Size = new System.Drawing.Size(129, 23);
            this.btngetConnectedUsers.TabIndex = 5;
            this.btngetConnectedUsers.Text = "Get connected users";
            this.btngetConnectedUsers.UseVisualStyleBackColor = true;
            this.btngetConnectedUsers.Click += new System.EventHandler(this.btngetConnectedUsers_Click);
            // 
            // txtConnectedUsers
            // 
            this.txtConnectedUsers.Location = new System.Drawing.Point(423, 23);
            this.txtConnectedUsers.Name = "txtConnectedUsers";
            this.txtConnectedUsers.Size = new System.Drawing.Size(331, 20);
            this.txtConnectedUsers.TabIndex = 6;
            // 
            // txtTeamUserA1
            // 
            this.txtTeamUserA1.Location = new System.Drawing.Point(360, 90);
            this.txtTeamUserA1.Name = "txtTeamUserA1";
            this.txtTeamUserA1.Size = new System.Drawing.Size(121, 20);
            this.txtTeamUserA1.TabIndex = 7;
            this.txtTeamUserA1.Text = "MiMenda1";
            // 
            // txtTeamName1
            // 
            this.txtTeamName1.Location = new System.Drawing.Point(360, 64);
            this.txtTeamName1.Name = "txtTeamName1";
            this.txtTeamName1.Size = new System.Drawing.Size(121, 20);
            this.txtTeamName1.TabIndex = 8;
            this.txtTeamName1.Text = "Equipo 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre de equipo";
            // 
            // txtTeamUserA2
            // 
            this.txtTeamUserA2.Location = new System.Drawing.Point(360, 116);
            this.txtTeamUserA2.Name = "txtTeamUserA2";
            this.txtTeamUserA2.Size = new System.Drawing.Size(121, 20);
            this.txtTeamUserA2.TabIndex = 10;
            this.txtTeamUserA2.Text = "MiMenda3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre de usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nombre de usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nombre de usuario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Nombre de usuario";
            // 
            // txtTeamUserB2
            // 
            this.txtTeamUserB2.Location = new System.Drawing.Point(604, 116);
            this.txtTeamUserB2.Name = "txtTeamUserB2";
            this.txtTeamUserB2.Size = new System.Drawing.Size(121, 20);
            this.txtTeamUserB2.TabIndex = 16;
            this.txtTeamUserB2.Text = "MiMenda4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Nombre de equipo";
            // 
            // txtTeamName2
            // 
            this.txtTeamName2.Location = new System.Drawing.Point(604, 64);
            this.txtTeamName2.Name = "txtTeamName2";
            this.txtTeamName2.Size = new System.Drawing.Size(121, 20);
            this.txtTeamName2.TabIndex = 14;
            this.txtTeamName2.Text = "Equipo 2";
            // 
            // txtTeamUserB1
            // 
            this.txtTeamUserB1.Location = new System.Drawing.Point(604, 90);
            this.txtTeamUserB1.Name = "txtTeamUserB1";
            this.txtTeamUserB1.Size = new System.Drawing.Size(121, 20);
            this.txtTeamUserB1.TabIndex = 13;
            this.txtTeamUserB1.Text = "MiMenda2";
            // 
            // btnCreateTeam1
            // 
            this.btnCreateTeam1.Location = new System.Drawing.Point(396, 142);
            this.btnCreateTeam1.Name = "btnCreateTeam1";
            this.btnCreateTeam1.Size = new System.Drawing.Size(85, 23);
            this.btnCreateTeam1.TabIndex = 19;
            this.btnCreateTeam1.Text = "Create team";
            this.btnCreateTeam1.UseVisualStyleBackColor = true;
            this.btnCreateTeam1.Click += new System.EventHandler(this.btnCreateTeam1_Click);
            // 
            // btnCreateTeam2
            // 
            this.btnCreateTeam2.Location = new System.Drawing.Point(650, 142);
            this.btnCreateTeam2.Name = "btnCreateTeam2";
            this.btnCreateTeam2.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTeam2.TabIndex = 20;
            this.btnCreateTeam2.Text = "Create team";
            this.btnCreateTeam2.UseVisualStyleBackColor = true;
            this.btnCreateTeam2.Click += new System.EventHandler(this.btnCreateTeam2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Puntos partida";
            // 
            // txtPointToWin
            // 
            this.txtPointToWin.Location = new System.Drawing.Point(116, 139);
            this.txtPointToWin.Name = "txtPointToWin";
            this.txtPointToWin.Size = new System.Drawing.Size(121, 20);
            this.txtPointToWin.TabIndex = 22;
            this.txtPointToWin.Text = "40";
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(17, 177);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(100, 23);
            this.btnStartGame.TabIndex = 21;
            this.btnStartGame.Text = "Empezar partida";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // txtPlayer2B
            // 
            this.txtPlayer2B.Location = new System.Drawing.Point(173, 357);
            this.txtPlayer2B.Name = "txtPlayer2B";
            this.txtPlayer2B.Size = new System.Drawing.Size(64, 20);
            this.txtPlayer2B.TabIndex = 24;
            // 
            // txtPlayer2A
            // 
            this.txtPlayer2A.Location = new System.Drawing.Point(383, 251);
            this.txtPlayer2A.Name = "txtPlayer2A";
            this.txtPlayer2A.Size = new System.Drawing.Size(64, 20);
            this.txtPlayer2A.TabIndex = 25;
            // 
            // txtPlayer1B
            // 
            this.txtPlayer1B.Location = new System.Drawing.Point(580, 357);
            this.txtPlayer1B.Name = "txtPlayer1B";
            this.txtPlayer1B.Size = new System.Drawing.Size(64, 20);
            this.txtPlayer1B.TabIndex = 26;
            // 
            // txtPlayer1A
            // 
            this.txtPlayer1A.Location = new System.Drawing.Point(383, 450);
            this.txtPlayer1A.Name = "txtPlayer1A";
            this.txtPlayer1A.Size = new System.Drawing.Size(64, 20);
            this.txtPlayer1A.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Jugador selecciondo";
            // 
            // txtSelectedPlayer
            // 
            this.txtSelectedPlayer.Location = new System.Drawing.Point(123, 222);
            this.txtSelectedPlayer.Name = "txtSelectedPlayer";
            this.txtSelectedPlayer.Size = new System.Drawing.Size(121, 20);
            this.txtSelectedPlayer.TabIndex = 29;
            this.txtSelectedPlayer.Text = "MiMenda1";
            // 
            // txtPlayer1BCard1
            // 
            this.txtPlayer1BCard1.Location = new System.Drawing.Point(531, 328);
            this.txtPlayer1BCard1.Name = "txtPlayer1BCard1";
            this.txtPlayer1BCard1.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer1BCard1.TabIndex = 30;
            // 
            // txtPlayer1BCard2
            // 
            this.txtPlayer1BCard2.Location = new System.Drawing.Point(531, 348);
            this.txtPlayer1BCard2.Name = "txtPlayer1BCard2";
            this.txtPlayer1BCard2.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer1BCard2.TabIndex = 31;
            // 
            // txtPlayer1BCard4
            // 
            this.txtPlayer1BCard4.Location = new System.Drawing.Point(531, 388);
            this.txtPlayer1BCard4.Name = "txtPlayer1BCard4";
            this.txtPlayer1BCard4.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer1BCard4.TabIndex = 33;
            // 
            // txtPlayer1BCard3
            // 
            this.txtPlayer1BCard3.Location = new System.Drawing.Point(531, 368);
            this.txtPlayer1BCard3.Name = "txtPlayer1BCard3";
            this.txtPlayer1BCard3.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer1BCard3.TabIndex = 32;
            // 
            // txtPlayer2BCard4
            // 
            this.txtPlayer2BCard4.Location = new System.Drawing.Point(261, 388);
            this.txtPlayer2BCard4.Name = "txtPlayer2BCard4";
            this.txtPlayer2BCard4.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer2BCard4.TabIndex = 37;
            // 
            // txtPlayer2BCard3
            // 
            this.txtPlayer2BCard3.Location = new System.Drawing.Point(261, 368);
            this.txtPlayer2BCard3.Name = "txtPlayer2BCard3";
            this.txtPlayer2BCard3.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer2BCard3.TabIndex = 36;
            // 
            // txtPlayer2BCard2
            // 
            this.txtPlayer2BCard2.Location = new System.Drawing.Point(261, 348);
            this.txtPlayer2BCard2.Name = "txtPlayer2BCard2";
            this.txtPlayer2BCard2.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer2BCard2.TabIndex = 35;
            // 
            // txtPlayer2BCard1
            // 
            this.txtPlayer2BCard1.Location = new System.Drawing.Point(261, 328);
            this.txtPlayer2BCard1.Name = "txtPlayer2BCard1";
            this.txtPlayer2BCard1.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer2BCard1.TabIndex = 34;
            // 
            // txtPlayer2ACard1
            // 
            this.txtPlayer2ACard1.Location = new System.Drawing.Point(349, 277);
            this.txtPlayer2ACard1.Name = "txtPlayer2ACard1";
            this.txtPlayer2ACard1.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer2ACard1.TabIndex = 38;
            // 
            // txtPlayer2ACard2
            // 
            this.txtPlayer2ACard2.Location = new System.Drawing.Point(383, 277);
            this.txtPlayer2ACard2.Name = "txtPlayer2ACard2";
            this.txtPlayer2ACard2.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer2ACard2.TabIndex = 38;
            // 
            // txtPlayer2ACard3
            // 
            this.txtPlayer2ACard3.Location = new System.Drawing.Point(417, 277);
            this.txtPlayer2ACard3.Name = "txtPlayer2ACard3";
            this.txtPlayer2ACard3.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer2ACard3.TabIndex = 38;
            // 
            // txtPlayer2ACard4
            // 
            this.txtPlayer2ACard4.Location = new System.Drawing.Point(451, 277);
            this.txtPlayer2ACard4.Name = "txtPlayer2ACard4";
            this.txtPlayer2ACard4.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer2ACard4.TabIndex = 38;
            // 
            // txtPlayer1ACard4
            // 
            this.txtPlayer1ACard4.Location = new System.Drawing.Point(451, 415);
            this.txtPlayer1ACard4.Name = "txtPlayer1ACard4";
            this.txtPlayer1ACard4.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer1ACard4.TabIndex = 39;
            // 
            // txtPlayer1ACard3
            // 
            this.txtPlayer1ACard3.Location = new System.Drawing.Point(417, 415);
            this.txtPlayer1ACard3.Name = "txtPlayer1ACard3";
            this.txtPlayer1ACard3.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer1ACard3.TabIndex = 40;
            // 
            // txtPlayer1ACard2
            // 
            this.txtPlayer1ACard2.Location = new System.Drawing.Point(383, 415);
            this.txtPlayer1ACard2.Name = "txtPlayer1ACard2";
            this.txtPlayer1ACard2.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer1ACard2.TabIndex = 41;
            // 
            // txtPlayer1ACard1
            // 
            this.txtPlayer1ACard1.Location = new System.Drawing.Point(349, 415);
            this.txtPlayer1ACard1.Name = "txtPlayer1ACard1";
            this.txtPlayer1ACard1.Size = new System.Drawing.Size(34, 20);
            this.txtPlayer1ACard1.TabIndex = 42;
            // 
            // btnGetCards
            // 
            this.btnGetCards.Location = new System.Drawing.Point(17, 264);
            this.btnGetCards.Name = "btnGetCards";
            this.btnGetCards.Size = new System.Drawing.Size(100, 23);
            this.btnGetCards.TabIndex = 43;
            this.btnGetCards.Text = "Obtener Cartas";
            this.btnGetCards.UseVisualStyleBackColor = true;
            this.btnGetCards.Click += new System.EventHandler(this.btnGetCards_Click);
            // 
            // txtNumCuentasA
            // 
            this.txtNumCuentasA.Location = new System.Drawing.Point(319, 177);
            this.txtNumCuentasA.Name = "txtNumCuentasA";
            this.txtNumCuentasA.Size = new System.Drawing.Size(48, 20);
            this.txtNumCuentasA.TabIndex = 44;
            // 
            // btnChangeNumA
            // 
            this.btnChangeNumA.Location = new System.Drawing.Point(383, 174);
            this.btnChangeNumA.Name = "btnChangeNumA";
            this.btnChangeNumA.Size = new System.Drawing.Size(98, 23);
            this.btnChangeNumA.TabIndex = 45;
            this.btnChangeNumA.Text = "Cambiar cuentas ";
            this.btnChangeNumA.UseVisualStyleBackColor = true;
            this.btnChangeNumA.Click += new System.EventHandler(this.btnChangeNumA_Click);
            // 
            // btnChangeNumB
            // 
            this.btnChangeNumB.Location = new System.Drawing.Point(627, 177);
            this.btnChangeNumB.Name = "btnChangeNumB";
            this.btnChangeNumB.Size = new System.Drawing.Size(98, 23);
            this.btnChangeNumB.TabIndex = 47;
            this.btnChangeNumB.Text = "Cambiar cuentas ";
            this.btnChangeNumB.UseVisualStyleBackColor = true;
            this.btnChangeNumB.Click += new System.EventHandler(this.btnChangeNumB_Click);
            // 
            // txtNumCuentasB
            // 
            this.txtNumCuentasB.Location = new System.Drawing.Point(563, 180);
            this.txtNumCuentasB.Name = "txtNumCuentasB";
            this.txtNumCuentasB.Size = new System.Drawing.Size(48, 20);
            this.txtNumCuentasB.TabIndex = 46;
            // 
            // btnNextRound
            // 
            this.btnNextRound.Location = new System.Drawing.Point(625, 225);
            this.btnNextRound.Name = "btnNextRound";
            this.btnNextRound.Size = new System.Drawing.Size(100, 23);
            this.btnNextRound.TabIndex = 48;
            this.btnNextRound.Text = "Siguiente ronda";
            this.btnNextRound.UseVisualStyleBackColor = true;
            this.btnNextRound.Click += new System.EventHandler(this.btnNextRound_Click);
            // 
            // chkPlayer2BCard1
            // 
            this.chkPlayer2BCard1.AutoSize = true;
            this.chkPlayer2BCard1.Location = new System.Drawing.Point(301, 331);
            this.chkPlayer2BCard1.Name = "chkPlayer2BCard1";
            this.chkPlayer2BCard1.Size = new System.Drawing.Size(15, 14);
            this.chkPlayer2BCard1.TabIndex = 49;
            this.chkPlayer2BCard1.UseVisualStyleBackColor = true;
            // 
            // chkPlayer2BCard2
            // 
            this.chkPlayer2BCard2.AutoSize = true;
            this.chkPlayer2BCard2.Location = new System.Drawing.Point(301, 351);
            this.chkPlayer2BCard2.Name = "chkPlayer2BCard2";
            this.chkPlayer2BCard2.Size = new System.Drawing.Size(15, 14);
            this.chkPlayer2BCard2.TabIndex = 50;
            this.chkPlayer2BCard2.UseVisualStyleBackColor = true;
            // 
            // chkPlayer2BCard3
            // 
            this.chkPlayer2BCard3.AutoSize = true;
            this.chkPlayer2BCard3.Location = new System.Drawing.Point(301, 371);
            this.chkPlayer2BCard3.Name = "chkPlayer2BCard3";
            this.chkPlayer2BCard3.Size = new System.Drawing.Size(15, 14);
            this.chkPlayer2BCard3.TabIndex = 51;
            this.chkPlayer2BCard3.UseVisualStyleBackColor = true;
            // 
            // chkPlayer2BCard4
            // 
            this.chkPlayer2BCard4.AutoSize = true;
            this.chkPlayer2BCard4.Location = new System.Drawing.Point(301, 391);
            this.chkPlayer2BCard4.Name = "chkPlayer2BCard4";
            this.chkPlayer2BCard4.Size = new System.Drawing.Size(15, 14);
            this.chkPlayer2BCard4.TabIndex = 52;
            this.chkPlayer2BCard4.UseVisualStyleBackColor = true;
            // 
            // chkPlayer1BCard4
            // 
            this.chkPlayer1BCard4.AutoSize = true;
            this.chkPlayer1BCard4.Location = new System.Drawing.Point(510, 391);
            this.chkPlayer1BCard4.Name = "chkPlayer1BCard4";
            this.chkPlayer1BCard4.Size = new System.Drawing.Size(15, 14);
            this.chkPlayer1BCard4.TabIndex = 56;
            this.chkPlayer1BCard4.UseVisualStyleBackColor = true;
            // 
            // chkPlayer1BCard3
            // 
            this.chkPlayer1BCard3.AutoSize = true;
            this.chkPlayer1BCard3.Location = new System.Drawing.Point(510, 371);
            this.chkPlayer1BCard3.Name = "chkPlayer1BCard3";
            this.chkPlayer1BCard3.Size = new System.Drawing.Size(15, 14);
            this.chkPlayer1BCard3.TabIndex = 55;
            this.chkPlayer1BCard3.UseVisualStyleBackColor = true;
            // 
            // chkPlayer1BCard2
            // 
            this.chkPlayer1BCard2.AutoSize = true;
            this.chkPlayer1BCard2.Location = new System.Drawing.Point(510, 351);
            this.chkPlayer1BCard2.Name = "chkPlayer1BCard2";
            this.chkPlayer1BCard2.Size = new System.Drawing.Size(15, 14);
            this.chkPlayer1BCard2.TabIndex = 54;
            this.chkPlayer1BCard2.UseVisualStyleBackColor = true;
            // 
            // chkPlayer1BCard1
            // 
            this.chkPlayer1BCard1.AutoSize = true;
            this.chkPlayer1BCard1.Location = new System.Drawing.Point(510, 331);
            this.chkPlayer1BCard1.Name = "chkPlayer1BCard1";
            this.chkPlayer1BCard1.Size = new System.Drawing.Size(15, 14);
            this.chkPlayer1BCard1.TabIndex = 53;
            this.chkPlayer1BCard1.UseVisualStyleBackColor = true;
            // 
            // btnDiscardCards
            // 
            this.btnDiscardCards.Location = new System.Drawing.Point(17, 331);
            this.btnDiscardCards.Name = "btnDiscardCards";
            this.btnDiscardCards.Size = new System.Drawing.Size(100, 23);
            this.btnDiscardCards.TabIndex = 57;
            this.btnDiscardCards.Text = "Descartar Cartas";
            this.btnDiscardCards.UseVisualStyleBackColor = true;
            this.btnDiscardCards.Click += new System.EventHandler(this.btnDiscardCards_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.btnDiscardCards);
            this.Controls.Add(this.chkPlayer1BCard4);
            this.Controls.Add(this.chkPlayer1BCard3);
            this.Controls.Add(this.chkPlayer1BCard2);
            this.Controls.Add(this.chkPlayer1BCard1);
            this.Controls.Add(this.chkPlayer2BCard4);
            this.Controls.Add(this.chkPlayer2BCard3);
            this.Controls.Add(this.chkPlayer2BCard2);
            this.Controls.Add(this.chkPlayer2BCard1);
            this.Controls.Add(this.btnNextRound);
            this.Controls.Add(this.btnChangeNumB);
            this.Controls.Add(this.txtNumCuentasB);
            this.Controls.Add(this.btnChangeNumA);
            this.Controls.Add(this.txtNumCuentasA);
            this.Controls.Add(this.btnGetCards);
            this.Controls.Add(this.txtPlayer1ACard4);
            this.Controls.Add(this.txtPlayer1ACard3);
            this.Controls.Add(this.txtPlayer1ACard2);
            this.Controls.Add(this.txtPlayer1ACard1);
            this.Controls.Add(this.txtPlayer2ACard4);
            this.Controls.Add(this.txtPlayer2ACard3);
            this.Controls.Add(this.txtPlayer2ACard2);
            this.Controls.Add(this.txtPlayer2ACard1);
            this.Controls.Add(this.txtPlayer2BCard4);
            this.Controls.Add(this.txtPlayer2BCard3);
            this.Controls.Add(this.txtPlayer2BCard2);
            this.Controls.Add(this.txtPlayer2BCard1);
            this.Controls.Add(this.txtPlayer1BCard4);
            this.Controls.Add(this.txtPlayer1BCard3);
            this.Controls.Add(this.txtPlayer1BCard2);
            this.Controls.Add(this.txtPlayer1BCard1);
            this.Controls.Add(this.txtSelectedPlayer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPlayer1A);
            this.Controls.Add(this.txtPlayer1B);
            this.Controls.Add(this.txtPlayer2A);
            this.Controls.Add(this.txtPlayer2B);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPointToWin);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.btnCreateTeam2);
            this.Controls.Add(this.btnCreateTeam1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTeamUserB2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTeamName2);
            this.Controls.Add(this.txtTeamUserB1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTeamUserA2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTeamName1);
            this.Controls.Add(this.txtTeamUserA1);
            this.Controls.Add(this.txtConnectedUsers);
            this.Controls.Add(this.btngetConnectedUsers);
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.txtGameName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtUserName);
            this.Name = "Form";
            this.Text = "Pruebas servicio MUS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.Button btngetConnectedUsers;
        private System.Windows.Forms.TextBox txtConnectedUsers;
        private System.Windows.Forms.TextBox txtTeamUserA1;
        private System.Windows.Forms.TextBox txtTeamName1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTeamUserA2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTeamUserB2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTeamName2;
        private System.Windows.Forms.TextBox txtTeamUserB1;
        private System.Windows.Forms.Button btnCreateTeam1;
        private System.Windows.Forms.Button btnCreateTeam2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPointToWin;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.TextBox txtPlayer2B;
        private System.Windows.Forms.TextBox txtPlayer2A;
        private System.Windows.Forms.TextBox txtPlayer1B;
        private System.Windows.Forms.TextBox txtPlayer1A;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSelectedPlayer;
        private System.Windows.Forms.TextBox txtPlayer1BCard1;
        private System.Windows.Forms.TextBox txtPlayer1BCard2;
        private System.Windows.Forms.TextBox txtPlayer1BCard4;
        private System.Windows.Forms.TextBox txtPlayer1BCard3;
        private System.Windows.Forms.TextBox txtPlayer2BCard4;
        private System.Windows.Forms.TextBox txtPlayer2BCard3;
        private System.Windows.Forms.TextBox txtPlayer2BCard2;
        private System.Windows.Forms.TextBox txtPlayer2BCard1;
        private System.Windows.Forms.TextBox txtPlayer2ACard1;
        private System.Windows.Forms.TextBox txtPlayer2ACard2;
        private System.Windows.Forms.TextBox txtPlayer2ACard3;
        private System.Windows.Forms.TextBox txtPlayer2ACard4;
        private System.Windows.Forms.TextBox txtPlayer1ACard4;
        private System.Windows.Forms.TextBox txtPlayer1ACard3;
        private System.Windows.Forms.TextBox txtPlayer1ACard2;
        private System.Windows.Forms.TextBox txtPlayer1ACard1;
        private System.Windows.Forms.Button btnGetCards;
        private System.Windows.Forms.TextBox txtNumCuentasA;
        private System.Windows.Forms.Button btnChangeNumA;
        private System.Windows.Forms.Button btnChangeNumB;
        private System.Windows.Forms.TextBox txtNumCuentasB;
        private System.Windows.Forms.Button btnNextRound;
        private System.Windows.Forms.CheckBox chkPlayer2BCard1;
        private System.Windows.Forms.CheckBox chkPlayer2BCard2;
        private System.Windows.Forms.CheckBox chkPlayer2BCard3;
        private System.Windows.Forms.CheckBox chkPlayer2BCard4;
        private System.Windows.Forms.CheckBox chkPlayer1BCard4;
        private System.Windows.Forms.CheckBox chkPlayer1BCard3;
        private System.Windows.Forms.CheckBox chkPlayer1BCard2;
        private System.Windows.Forms.CheckBox chkPlayer1BCard1;
        private System.Windows.Forms.Button btnDiscardCards;
    }
}

