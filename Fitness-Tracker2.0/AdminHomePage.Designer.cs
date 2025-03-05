namespace Fitness_Tracker2._0
{
    partial class frmAdminHomePage
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
            btnAddEmployee = new Button();
            txtbFirstName = new TextBox();
            txtbLastName = new TextBox();
            txtbUsername = new TextBox();
            txtbPassword = new TextBox();
            txtbEmail = new TextBox();
            cmbRole = new ComboBox();
            lstbEmployees = new ListBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.BackColor = Color.Red;
            btnAddEmployee.FlatStyle = FlatStyle.Flat;
            btnAddEmployee.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold);
            btnAddEmployee.ForeColor = Color.WhiteSmoke;
            btnAddEmployee.Location = new Point(12, 465);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(128, 50);
            btnAddEmployee.TabIndex = 0;
            btnAddEmployee.Text = "Create";
            btnAddEmployee.UseVisualStyleBackColor = false;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // txtbFirstName
            // 
            txtbFirstName.BorderStyle = BorderStyle.None;
            txtbFirstName.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbFirstName.ForeColor = Color.Red;
            txtbFirstName.Location = new Point(150, 70);
            txtbFirstName.Name = "txtbFirstName";
            txtbFirstName.Size = new Size(200, 21);
            txtbFirstName.TabIndex = 1;
            // 
            // txtbLastName
            // 
            txtbLastName.BorderStyle = BorderStyle.None;
            txtbLastName.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbLastName.ForeColor = Color.Red;
            txtbLastName.Location = new Point(148, 122);
            txtbLastName.Name = "txtbLastName";
            txtbLastName.Size = new Size(200, 21);
            txtbLastName.TabIndex = 2;
            // 
            // txtbUsername
            // 
            txtbUsername.BorderStyle = BorderStyle.None;
            txtbUsername.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbUsername.ForeColor = Color.Red;
            txtbUsername.Location = new Point(150, 176);
            txtbUsername.Name = "txtbUsername";
            txtbUsername.Size = new Size(200, 21);
            txtbUsername.TabIndex = 3;
            // 
            // txtbPassword
            // 
            txtbPassword.BorderStyle = BorderStyle.None;
            txtbPassword.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbPassword.ForeColor = Color.Red;
            txtbPassword.Location = new Point(150, 237);
            txtbPassword.Name = "txtbPassword";
            txtbPassword.Size = new Size(200, 21);
            txtbPassword.TabIndex = 4;
            // 
            // txtbEmail
            // 
            txtbEmail.BorderStyle = BorderStyle.None;
            txtbEmail.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbEmail.ForeColor = Color.Red;
            txtbEmail.Location = new Point(148, 296);
            txtbEmail.Name = "txtbEmail";
            txtbEmail.Size = new Size(200, 21);
            txtbEmail.TabIndex = 5;
            // 
            // cmbRole
            // 
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            cmbRole.ForeColor = Color.Red;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "TRAINER\t", "NUTRIONIST\t" });
            cmbRole.Location = new Point(148, 359);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(200, 30);
            cmbRole.TabIndex = 6;
            // 
            // lstbEmployees
            // 
            lstbEmployees.BorderStyle = BorderStyle.None;
            lstbEmployees.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lstbEmployees.ForeColor = Color.Red;
            lstbEmployees.FormattingEnabled = true;
            lstbEmployees.ItemHeight = 22;
            lstbEmployees.Location = new Point(572, 12);
            lstbEmployees.Name = "lstbEmployees";
            lstbEmployees.Size = new Size(401, 506);
            lstbEmployees.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Location = new Point(150, 103);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 1);
            panel1.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.Location = new Point(148, 157);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 1);
            panel2.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.Location = new Point(150, 209);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 1);
            panel3.TabIndex = 9;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Red;
            panel4.Location = new Point(150, 270);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 1);
            panel4.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Red;
            panel5.Location = new Point(148, 329);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 1);
            panel5.TabIndex = 9;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Red;
            panel6.Location = new Point(148, 393);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 1);
            panel6.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(34, 69);
            label1.Name = "label1";
            label1.Size = new Size(110, 22);
            label1.TabIndex = 10;
            label1.Text = "First name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(34, 121);
            label2.Name = "label2";
            label2.Size = new Size(108, 22);
            label2.TabIndex = 11;
            label2.Text = "Last name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(34, 176);
            label3.Name = "label3";
            label3.Size = new Size(106, 22);
            label3.TabIndex = 12;
            label3.Text = "Username:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(41, 237);
            label4.Name = "label4";
            label4.Size = new Size(103, 22);
            label4.TabIndex = 13;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(77, 304);
            label5.Name = "label5";
            label5.Size = new Size(65, 22);
            label5.TabIndex = 14;
            label5.Text = "Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(85, 362);
            label6.Name = "label6";
            label6.Size = new Size(57, 22);
            label6.TabIndex = 15;
            label6.Text = "Role:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold);
            btnDelete.ForeColor = Color.WhiteSmoke;
            btnDelete.Location = new Point(146, 465);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(132, 50);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // frmAdminHomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(996, 628);
            Controls.Add(btnDelete);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lstbEmployees);
            Controls.Add(cmbRole);
            Controls.Add(txtbEmail);
            Controls.Add(txtbPassword);
            Controls.Add(txtbUsername);
            Controls.Add(txtbLastName);
            Controls.Add(txtbFirstName);
            Controls.Add(btnAddEmployee);
            Name = "frmAdminHomePage";
            Text = "Home ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddEmployee;
        private TextBox txtbFirstName;
        private TextBox txtbLastName;
        private TextBox txtbUsername;
        private TextBox txtbPassword;
        private TextBox txtbEmail;
        private ComboBox cmbRole;
        private ListBox lstbEmployees;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnDelete;
    }
}