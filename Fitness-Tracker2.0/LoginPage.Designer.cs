namespace Fitness_Tracker2._0
{
    partial class frmLoginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            btnLogin = new Button();
            txtbUsername = new TextBox();
            txtbPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Fitness_Tracker__6_;
            pictureBox1.Location = new Point(98, 13);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(374, 209);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Fitness_Tracker__3_;
            pictureBox2.Location = new Point(69, 287);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 45);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Fitness_Tracker__4_;
            pictureBox3.Location = new Point(52, 372);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(66, 53);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Location = new Point(126, 331);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 1);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.ForeColor = SystemColors.WindowText;
            panel2.Location = new Point(126, 424);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(295, 1);
            panel2.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Red;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold);
            btnLogin.ForeColor = Color.WhiteSmoke;
            btnLogin.Location = new Point(265, 476);
            btnLogin.Margin = new Padding(4, 3, 4, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(275, 42);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOG IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtbUsername
            // 
            txtbUsername.BackColor = Color.White;
            txtbUsername.BorderStyle = BorderStyle.None;
            txtbUsername.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbUsername.ForeColor = Color.Red;
            txtbUsername.Location = new Point(126, 295);
            txtbUsername.Margin = new Padding(4, 3, 4, 3);
            txtbUsername.Multiline = true;
            txtbUsername.Name = "txtbUsername";
            txtbUsername.Size = new Size(294, 26);
            txtbUsername.TabIndex = 7;
            // 
            // txtbPassword
            // 
            txtbPassword.BackColor = Color.White;
            txtbPassword.BorderStyle = BorderStyle.None;
            txtbPassword.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbPassword.ForeColor = Color.Red;
            txtbPassword.Location = new Point(126, 392);
            txtbPassword.Margin = new Padding(4, 3, 4, 3);
            txtbPassword.Multiline = true;
            txtbPassword.Name = "txtbPassword";
            txtbPassword.Size = new Size(294, 26);
            txtbPassword.TabIndex = 8;
            // 
            // frmLoginPage
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(559, 601);
            Controls.Add(txtbPassword);
            Controls.Add(txtbUsername);
            Controls.Add(btnLogin);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmLoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Page";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel panel1;
        private Panel panel2;
        private Button btnLogin;
        private TextBox txtbUsername;
        private TextBox txtbPassword;
    }
}
