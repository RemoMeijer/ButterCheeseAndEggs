namespace GameClient
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.SendButton = new System.Windows.Forms.Button();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.ChatListBox = new System.Windows.Forms.ListBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.winsLabel = new System.Windows.Forms.Label();
            this.lossesLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.x1y3 = new System.Windows.Forms.Button();
            this.x1y2 = new System.Windows.Forms.Button();
            this.x1y1 = new System.Windows.Forms.Button();
            this.x2y1 = new System.Windows.Forms.Button();
            this.x2y2 = new System.Windows.Forms.Button();
            this.x2y3 = new System.Windows.Forms.Button();
            this.x3y1 = new System.Windows.Forms.Button();
            this.x3y2 = new System.Windows.Forms.Button();
            this.x3y3 = new System.Windows.Forms.Button();
            this.waitingLabel = new System.Windows.Forms.Label();
            this.globalChatLabel = new System.Windows.Forms.Label();
            this.labelx1y1 = new System.Windows.Forms.Label();
            this.labelx1y2 = new System.Windows.Forms.Label();
            this.labelx1y3 = new System.Windows.Forms.Label();
            this.labelx2y1 = new System.Windows.Forms.Label();
            this.labelx2y2 = new System.Windows.Forms.Label();
            this.labelx2y3 = new System.Windows.Forms.Label();
            this.labelx3y1 = new System.Windows.Forms.Label();
            this.labelx3y2 = new System.Windows.Forms.Label();
            this.labelx3y3 = new System.Windows.Forms.Label();
            this.turnLabel = new System.Windows.Forms.Label();
            this.tiesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.SendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SendButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SendButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SendButton.Location = new System.Drawing.Point(1252, 570);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(78, 37);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = ">";
            this.SendButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ChatTextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChatTextBox.Location = new System.Drawing.Point(1003, 569);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(243, 39);
            this.ChatTextBox.TabIndex = 2;
            this.ChatTextBox.TextChanged += new System.EventHandler(this.ChatTextBox_TextChanged);
            this.ChatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DocKeyDown);
            // 
            // ChatListBox
            // 
            this.ChatListBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChatListBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChatListBox.FormattingEnabled = true;
            this.ChatListBox.ItemHeight = 32;
            this.ChatListBox.Location = new System.Drawing.Point(1004, 81);
            this.ChatListBox.Name = "ChatListBox";
            this.ChatListBox.Size = new System.Drawing.Size(325, 484);
            this.ChatListBox.TabIndex = 3;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExitButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ExitButton.Location = new System.Drawing.Point(5, 617);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(90, 35);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // winsLabel
            // 
            this.winsLabel.AutoSize = true;
            this.winsLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.winsLabel.Location = new System.Drawing.Point(13, 75);
            this.winsLabel.Name = "winsLabel";
            this.winsLabel.Size = new System.Drawing.Size(103, 37);
            this.winsLabel.TabIndex = 5;
            this.winsLabel.Text = "Wins: 0";
            // 
            // lossesLabel
            // 
            this.lossesLabel.AutoSize = true;
            this.lossesLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lossesLabel.Location = new System.Drawing.Point(13, 109);
            this.lossesLabel.Name = "lossesLabel";
            this.lossesLabel.Size = new System.Drawing.Size(121, 37);
            this.lossesLabel.TabIndex = 6;
            this.lossesLabel.Text = "Losses: 0";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.Location = new System.Drawing.Point(12, 39);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(142, 37);
            this.usernameLabel.TabIndex = 7;
            this.usernameLabel.Text = "Username:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(413, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // x1y3
            // 
            this.x1y3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x1y3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x1y3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x1y3.Location = new System.Drawing.Point(753, 86);
            this.x1y3.Name = "x1y3";
            this.x1y3.Size = new System.Drawing.Size(158, 151);
            this.x1y3.TabIndex = 9;
            this.x1y3.UseVisualStyleBackColor = false;
            this.x1y3.Click += new System.EventHandler(this.x1y3_Click);
            // 
            // x1y2
            // 
            this.x1y2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x1y2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x1y2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x1y2.Location = new System.Drawing.Point(583, 87);
            this.x1y2.Name = "x1y2";
            this.x1y2.Size = new System.Drawing.Size(158, 151);
            this.x1y2.TabIndex = 9;
            this.x1y2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.x1y2.UseVisualStyleBackColor = false;
            this.x1y2.Click += new System.EventHandler(this.x1y2_Click);
            // 
            // x1y1
            // 
            this.x1y1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x1y1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x1y1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.x1y1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x1y1.Location = new System.Drawing.Point(417, 86);
            this.x1y1.Name = "x1y1";
            this.x1y1.Size = new System.Drawing.Size(158, 151);
            this.x1y1.TabIndex = 9;
            this.x1y1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.x1y1.UseVisualStyleBackColor = false;
            this.x1y1.Click += new System.EventHandler(this.x1y1_Click);
            // 
            // x2y1
            // 
            this.x2y1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x2y1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2y1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x2y1.Location = new System.Drawing.Point(416, 256);
            this.x2y1.Name = "x2y1";
            this.x2y1.Size = new System.Drawing.Size(158, 151);
            this.x2y1.TabIndex = 9;
            this.x2y1.UseVisualStyleBackColor = false;
            this.x2y1.Click += new System.EventHandler(this.x2y1_Click);
            // 
            // x2y2
            // 
            this.x2y2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x2y2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2y2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x2y2.Location = new System.Drawing.Point(583, 256);
            this.x2y2.Name = "x2y2";
            this.x2y2.Size = new System.Drawing.Size(158, 151);
            this.x2y2.TabIndex = 9;
            this.x2y2.UseVisualStyleBackColor = false;
            this.x2y2.Click += new System.EventHandler(this.x2y2_Click);
            // 
            // x2y3
            // 
            this.x2y3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x2y3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2y3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x2y3.Location = new System.Drawing.Point(755, 256);
            this.x2y3.Name = "x2y3";
            this.x2y3.Size = new System.Drawing.Size(158, 151);
            this.x2y3.TabIndex = 9;
            this.x2y3.UseVisualStyleBackColor = false;
            this.x2y3.Click += new System.EventHandler(this.x2y3_Click);
            // 
            // x3y1
            // 
            this.x3y1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x3y1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x3y1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x3y1.Location = new System.Drawing.Point(418, 423);
            this.x3y1.Name = "x3y1";
            this.x3y1.Size = new System.Drawing.Size(158, 151);
            this.x3y1.TabIndex = 9;
            this.x3y1.UseVisualStyleBackColor = false;
            this.x3y1.Click += new System.EventHandler(this.x3y1_Click);
            // 
            // x3y2
            // 
            this.x3y2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x3y2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x3y2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x3y2.Location = new System.Drawing.Point(583, 423);
            this.x3y2.Name = "x3y2";
            this.x3y2.Size = new System.Drawing.Size(158, 151);
            this.x3y2.TabIndex = 9;
            this.x3y2.UseVisualStyleBackColor = false;
            this.x3y2.Click += new System.EventHandler(this.x3y2_Click);
            // 
            // x3y3
            // 
            this.x3y3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x3y3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x3y3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.x3y3.Location = new System.Drawing.Point(754, 422);
            this.x3y3.Name = "x3y3";
            this.x3y3.Size = new System.Drawing.Size(158, 151);
            this.x3y3.TabIndex = 9;
            this.x3y3.UseVisualStyleBackColor = false;
            this.x3y3.Click += new System.EventHandler(this.x3y3_Click);
            // 
            // waitingLabel
            // 
            this.waitingLabel.AutoSize = true;
            this.waitingLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.waitingLabel.Location = new System.Drawing.Point(524, 21);
            this.waitingLabel.Name = "waitingLabel";
            this.waitingLabel.Size = new System.Drawing.Size(291, 37);
            this.waitingLabel.TabIndex = 10;
            this.waitingLabel.Text = "Waiting for opponent...";
            // 
            // globalChatLabel
            // 
            this.globalChatLabel.AutoSize = true;
            this.globalChatLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.globalChatLabel.Location = new System.Drawing.Point(997, 39);
            this.globalChatLabel.Name = "globalChatLabel";
            this.globalChatLabel.Size = new System.Drawing.Size(153, 37);
            this.globalChatLabel.TabIndex = 11;
            this.globalChatLabel.Text = "Global chat";
            // 
            // labelx1y1
            // 
            this.labelx1y1.AutoSize = true;
            this.labelx1y1.Font = new System.Drawing.Font("Segoe UI", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelx1y1.Location = new System.Drawing.Point(440, 87);
            this.labelx1y1.Name = "labelx1y1";
            this.labelx1y1.Size = new System.Drawing.Size(0, 133);
            this.labelx1y1.TabIndex = 12;
            // 
            // labelx1y2
            // 
            this.labelx1y2.AutoSize = true;
            this.labelx1y2.Font = new System.Drawing.Font("Segoe UI", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelx1y2.Location = new System.Drawing.Point(608, 87);
            this.labelx1y2.Name = "labelx1y2";
            this.labelx1y2.Size = new System.Drawing.Size(0, 133);
            this.labelx1y2.TabIndex = 12;
            // 
            // labelx1y3
            // 
            this.labelx1y3.AutoSize = true;
            this.labelx1y3.Font = new System.Drawing.Font("Segoe UI", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelx1y3.Location = new System.Drawing.Point(771, 87);
            this.labelx1y3.Name = "labelx1y3";
            this.labelx1y3.Size = new System.Drawing.Size(0, 133);
            this.labelx1y3.TabIndex = 12;
            // 
            // labelx2y1
            // 
            this.labelx2y1.AutoSize = true;
            this.labelx2y1.Font = new System.Drawing.Font("Segoe UI", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelx2y1.Location = new System.Drawing.Point(437, 256);
            this.labelx2y1.Name = "labelx2y1";
            this.labelx2y1.Size = new System.Drawing.Size(0, 133);
            this.labelx2y1.TabIndex = 12;
            // 
            // labelx2y2
            // 
            this.labelx2y2.AutoSize = true;
            this.labelx2y2.Font = new System.Drawing.Font("Segoe UI", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelx2y2.Location = new System.Drawing.Point(609, 256);
            this.labelx2y2.Name = "labelx2y2";
            this.labelx2y2.Size = new System.Drawing.Size(0, 133);
            this.labelx2y2.TabIndex = 12;
            // 
            // labelx2y3
            // 
            this.labelx2y3.AutoSize = true;
            this.labelx2y3.Font = new System.Drawing.Font("Segoe UI", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelx2y3.Location = new System.Drawing.Point(771, 256);
            this.labelx2y3.Name = "labelx2y3";
            this.labelx2y3.Size = new System.Drawing.Size(0, 133);
            this.labelx2y3.TabIndex = 12;
            // 
            // labelx3y1
            // 
            this.labelx3y1.AutoSize = true;
            this.labelx3y1.Font = new System.Drawing.Font("Segoe UI", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelx3y1.Location = new System.Drawing.Point(437, 423);
            this.labelx3y1.Name = "labelx3y1";
            this.labelx3y1.Size = new System.Drawing.Size(0, 133);
            this.labelx3y1.TabIndex = 12;
            // 
            // labelx3y2
            // 
            this.labelx3y2.AutoSize = true;
            this.labelx3y2.Font = new System.Drawing.Font("Segoe UI", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelx3y2.Location = new System.Drawing.Point(609, 423);
            this.labelx3y2.Name = "labelx3y2";
            this.labelx3y2.Size = new System.Drawing.Size(0, 133);
            this.labelx3y2.TabIndex = 12;
            // 
            // labelx3y3
            // 
            this.labelx3y3.AutoSize = true;
            this.labelx3y3.Font = new System.Drawing.Font("Segoe UI", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelx3y3.Location = new System.Drawing.Point(771, 423);
            this.labelx3y3.Name = "labelx3y3";
            this.labelx3y3.Size = new System.Drawing.Size(0, 133);
            this.labelx3y3.TabIndex = 12;
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.turnLabel.Location = new System.Drawing.Point(603, 602);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(0, 37);
            this.turnLabel.TabIndex = 13;
            this.turnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tiesLabel
            // 
            this.tiesLabel.AutoSize = true;
            this.tiesLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tiesLabel.Location = new System.Drawing.Point(12, 141);
            this.tiesLabel.Name = "tiesLabel";
            this.tiesLabel.Size = new System.Drawing.Size(91, 37);
            this.tiesLabel.TabIndex = 14;
            this.tiesLabel.Text = "Ties: 0";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1339, 655);
            this.Controls.Add(this.tiesLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.labelx3y3);
            this.Controls.Add(this.labelx3y2);
            this.Controls.Add(this.labelx3y1);
            this.Controls.Add(this.labelx2y3);
            this.Controls.Add(this.labelx2y2);
            this.Controls.Add(this.labelx2y1);
            this.Controls.Add(this.labelx1y3);
            this.Controls.Add(this.labelx1y2);
            this.Controls.Add(this.labelx1y1);
            this.Controls.Add(this.globalChatLabel);
            this.Controls.Add(this.waitingLabel);
            this.Controls.Add(this.x3y3);
            this.Controls.Add(this.x3y2);
            this.Controls.Add(this.x3y1);
            this.Controls.Add(this.x2y3);
            this.Controls.Add(this.x2y2);
            this.Controls.Add(this.x2y1);
            this.Controls.Add(this.x1y1);
            this.Controls.Add(this.x1y2);
            this.Controls.Add(this.x1y3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.lossesLabel);
            this.Controls.Add(this.winsLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ChatListBox);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.SendButton);
            this.Name = "GUI";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox ChatTextBox;
        private System.Windows.Forms.ListBox ChatListBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label winsLabel;
        private System.Windows.Forms.Label lossesLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button x1y3;
        private System.Windows.Forms.Button x1y2;
        private System.Windows.Forms.Button x1y1;
        private System.Windows.Forms.Button x2y1;
        private System.Windows.Forms.Button x2y2;
        private System.Windows.Forms.Button x2y;
        private System.Windows.Forms.Button x2y3;
        private System.Windows.Forms.Button x3y1;
        private System.Windows.Forms.Button x3y2;
        private System.Windows.Forms.Button x3y3;
        private System.Windows.Forms.Label waitingLabel;
        private System.Windows.Forms.Label globalChatLabel;
        private System.Windows.Forms.Label labelx1y1;
        private System.Windows.Forms.Label labelx1y2;
        private System.Windows.Forms.Label labelx1y3;
        private System.Windows.Forms.Label labelx2y1;
        private System.Windows.Forms.Label labelx2y2;
        private System.Windows.Forms.Label labelx2y3;
        private System.Windows.Forms.Label labelx3y1;
        private System.Windows.Forms.Label labelx3y2;
        private System.Windows.Forms.Label labelx3y3;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label tiesLabel;
    }
}