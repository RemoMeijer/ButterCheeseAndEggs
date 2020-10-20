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

        private void SendButton_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void DocKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendButton_Click(null, null);
        }



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
            ChatListBox.Invoke((MethodInvoker)(() =>
            {
                ChatListBox.Items.Add(message);
            }));
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.client.Send(Client.disconnectCode, "");
            this.client.disconnect();
            Application.Exit();
        }

        private void ChatTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void setOpponent(string team, string opponentUsername)
        {
            waitingLabel.Text = "Opponent: " + opponentUsername + "  |  Team: " + team;
        }

        #region coordinateHandling
        public void sendCoordinate(int x, int y)
        {
            if(this.client.inGame == true && this.client.turn == true)
            {
                string coords = x + "" + y;
                if (this.client.coordinates[coords] = false)
                {
                    this.client.coordinates[coords] = true;
                    inputSet(coords);
                }
            }
        }

        public void inputSet(string input)
        {
            switch (input)
            {
                case "11":
                    labelx1y1.Text = client.teamString;
                    break;
                case "12":
                    labelx1y2.Text = client.teamString;
                    break;
                case "13":
                    labelx1y3.Text = client.teamString;
                    break;
                case "21":
                    labelx2y1.Text = client.teamString;
                    break;
                case "22":
                    labelx2y2.Text = client.teamString;
                    break;
                case "23":
                    labelx2y3.Text = client.teamString;
                    break;
                case "31":
                    labelx3y1.Text = client.teamString;
                    break;
                case "32":
                    labelx3y2.Text = client.teamString;
                    break;
                case "33":
                    labelx3y3.Text = client.teamString;
                    break;

            }
        }

        private void x1y1_Click(object sender, EventArgs e)
        {
            sendCoordinate(1, 1);
        }

        private void x1y2_Click(object sender, EventArgs e)
        {
            sendCoordinate(1, 2);
        }

        private void x1y3_Click(object sender, EventArgs e)
        {
            sendCoordinate(1, 3);
        }

        private void x2y1_Click(object sender, EventArgs e)
        {
            sendCoordinate(2, 1);
        }

        private void x2y2_Click(object sender, EventArgs e)
        {
            sendCoordinate(2, 2);
        }

        private void x2y3_Click(object sender, EventArgs e)
        {
            sendCoordinate(2, 3);
        }

        private void x3y1_Click(object sender, EventArgs e)
        {
            sendCoordinate(3, 1);
        }

        private void x3y2_Click(object sender, EventArgs e)
        {
            sendCoordinate(3, 2);
        }

        private void x3y3_Click(object sender, EventArgs e)
        {
            sendCoordinate(3, 3);
        }
        #endregion
    }
}
