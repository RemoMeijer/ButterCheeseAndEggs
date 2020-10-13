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

        private string disconnectCode = "DCNT";
        private string chatmessageCode = "CHMS";

        public GUI(Client client)
        {
            this.client = client;
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        public void run()
        {
     
            Application.Run(this);
        }

        private void SendButton_Click(object sender, EventArgs e)
        { 
            if(ChatTextBox.Text != "")
            {
                ChatListBox.Items.Add(ChatTextBox.Text);
                this.client.Send(this.chatmessageCode,ChatTextBox.Text);
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
            this.client.Send(this.disconnectCode, "");
            this.client.disconnect();
            Application.Exit();
        }
    }
}
