namespace GameClient
{
    partial class EnterUsername
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
            this.label1 = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(95, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Username";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameTextBox.Location = new System.Drawing.Point(95, 94);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(204, 39);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DocKeyDown);

            // 
            // GoButton
            // 
            this.GoButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GoButton.Location = new System.Drawing.Point(151, 150);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(87, 46);
            this.GoButton.TabIndex = 2;
            this.GoButton.Text = "Go!";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // EnterUsername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(400, 237);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "EnterUsername";
            this.Text = "EnterUsername";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Button GoButton;
    }
}