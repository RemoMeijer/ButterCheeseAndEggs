using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GameClient
{
    public partial class EnterUsername : Form
    {
        private Client client;
        public EnterUsername(Client client)
        {
            this.client = client;
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        public void run()
        {
            Application.Run(this);
        }

        #region events
        private void GoButton_Click(object sender, EventArgs e)
        {
            if(UsernameTextBox.Text != "")
            {
                this.Hide();
                this.client.start(UsernameTextBox.Text);
                //Thread clientStartThread = new Thread(() => this.client.start(UsernameTextBox.Text));
                //clientStartThread.Start();
                
            }
        }

        private void DocKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GoButton_Click(null, null);
        }
        #endregion
    }
}
