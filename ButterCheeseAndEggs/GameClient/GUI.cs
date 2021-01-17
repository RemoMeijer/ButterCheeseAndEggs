using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameClient
{
    public partial class GUI : Form
    {

        private Client client;

        #region startup
        public GUI(Client client)
        {
            this.client = client;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        public void run()
        {
     
            Application.Run(this);
        }

        #endregion

        #region events
        private void SendButton_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void DocKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendButton_Click(null, null);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.client.Send(Client.disconnectCode, "");
            this.client.disconnect();
            Application.Exit();
        }
        #endregion

        #region chatmessages
        public void sendMessage()
        {
            if (ChatTextBox.Text != "")
            {
                ChatListBox.Items.Add(ChatTextBox.Text);
                this.client.Send(Client.chatmessageCode, ChatTextBox.Text);
                ChatTextBox.Text = "";
            }
        }

        public void addChatMessage(string message)
        {
            try
            {
                ChatListBox.Invoke((MethodInvoker)(() =>
                {
                    ChatListBox.Items.Add(message);
                }));
            }
            catch
            {
                ChatListBox.Items.Add(message);
            }
        }
        #endregion

        #region setters

        public void setOpponent(string team, string opponentUsername)
        {
            waitingLabel.Text = "Opponent: " + opponentUsername + "  |  Team: " + team;
        }

        public void setOpponent(string message)
        {
            waitingLabel.Text = message;
        }

        public void setTurnLabel(string text)
        {
            turnLabel.Text = text;
        }

        public void setUsername(string username)
        {
            usernameLabel.Text = "Username: " + username;
        }

        public void setStats(string type, int amount)
        {
            switch (type)
            {
                case "winner":
                    this.winsLabel.Text = "Wins: " + amount;
                    break;
                case "loser":
                    this.lossesLabel.Text = "Losses: " + amount;
                    break;
                case "tie":
                    this.tiesLabel.Text = "Ties: " + amount;
                    break;
            }
        }
        #endregion

        #region coordinateHandling
        public void setCoordinate(string coords, string team)
        {
            if(this.client.inGame == true)
            {
                if (this.client.coordinates[coords] == false)
                {
                    this.client.coordinates[coords] = true;

                    inputSet(coords,team);

                    if (this.client.checkCoordinates())                   
                        this.client.clearAllCoordinates();
                    
                }
            }
        }

        public void setOwnCoordinate(string coords, string team)
        {
            if (this.client.turn == true)
                setCoordinate(coords, team);
        }

        public void inputSet(string input, string team)
        {
            switch (input)
            {
                case "11":
                    labelx1y1.Text = team;
                    sendCoordinate(input, team);
                    break;
                case "12":
                    labelx1y2.Text = team;
                    sendCoordinate(input, team);
                    break;
                case "13":
                    labelx1y3.Text = team;
                    sendCoordinate(input, team);
                    break;
                case "21":
                    labelx2y1.Text = team;
                    sendCoordinate(input, team);
                    break;
                case "22":
                    labelx2y2.Text = team;
                    sendCoordinate(input, team);
                    break;
                case "23":
                    labelx2y3.Text = team;
                    sendCoordinate(input, team);
                    break;
                case "31":
                    labelx3y1.Text = team;
                    sendCoordinate(input, team);
                    break;
                case "32":
                    labelx3y2.Text = team;
                    sendCoordinate(input, team);
                    break;
                case "33":
                    labelx3y3.Text = team;
                    sendCoordinate(input, team);
                    break;

            }
        }

        public void sendCoordinate(string input, string team)
        {
            if(this.client.turn == true && this.client.inGame == true)
                this.client.Send(Client.coordinateCode, input + team);
        }

        private void x1y1_Click(object sender, EventArgs e)
        {
            setOwnCoordinate("11",this.client.teamString);
        }

        private void x1y2_Click(object sender, EventArgs e)
        {
            setOwnCoordinate("12", this.client.teamString);
        }

        private void x1y3_Click(object sender, EventArgs e)
        {
            setOwnCoordinate("13", this.client.teamString);
        }

        private void x2y1_Click(object sender, EventArgs e)
        {
            setOwnCoordinate("21", this.client.teamString);
        }

        private void x2y2_Click(object sender, EventArgs e)
        {
            setOwnCoordinate("22", this.client.teamString);
        }

        private void x2y3_Click(object sender, EventArgs e)
        {
            setOwnCoordinate("23", this.client.teamString);
        }

        private void x3y1_Click(object sender, EventArgs e)
        {
            setOwnCoordinate("31", this.client.teamString);
        }

        private void x3y2_Click(object sender, EventArgs e)
        {
            setOwnCoordinate("32", this.client.teamString);
        }

        private void x3y3_Click(object sender, EventArgs e)
        {
            setOwnCoordinate("33", this.client.teamString);
        }
        #endregion

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void waitingLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
