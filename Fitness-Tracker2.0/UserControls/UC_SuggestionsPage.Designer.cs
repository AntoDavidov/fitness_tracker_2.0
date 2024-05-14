namespace Fitness_Tracker2._0.UserControls
{
    partial class UC_SuggestionsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel5 = new Panel();
            panel4 = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            lstbWorkout = new ListBox();
            btnEditWorkout = new Button();
            tabPage2 = new TabPage();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cmbLevel = new ComboBox();
            btnCreateWorkout = new Button();
            rchtxtbDescription = new RichTextBox();
            txtName = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1016, 537);
            tabControl1.TabIndex = 39;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel5);
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(lstbWorkout);
            tabPage1.Controls.Add(btnEditWorkout);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1008, 504);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Red;
            panel5.ForeColor = Color.Red;
            panel5.Location = new Point(94, 415);
            panel5.Name = "panel5";
            panel5.Size = new Size(290, 1);
            panel5.TabIndex = 44;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Red;
            panel4.ForeColor = Color.Red;
            panel4.Location = new Point(138, 46);
            panel4.Name = "panel4";
            panel4.Size = new Size(190, 1);
            panel4.TabIndex = 43;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            textBox1.ForeColor = Color.Red;
            textBox1.Location = new Point(138, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(190, 21);
            textBox1.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(26, 18);
            label1.Name = "label1";
            label1.Size = new Size(106, 22);
            label1.TabIndex = 41;
            label1.Text = "Search by:";
            // 
            // lstbWorkout
            // 
            lstbWorkout.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lstbWorkout.ForeColor = Color.Red;
            lstbWorkout.FormattingEnabled = true;
            lstbWorkout.ItemHeight = 22;
            lstbWorkout.Location = new Point(94, 75);
            lstbWorkout.Name = "lstbWorkout";
            lstbWorkout.Size = new Size(290, 334);
            lstbWorkout.TabIndex = 40;
            lstbWorkout.SelectedIndexChanged += lstbWorkout_SelectedIndexChanged;
            // 
            // btnEditWorkout
            // 
            btnEditWorkout.BackColor = Color.Red;
            btnEditWorkout.FlatStyle = FlatStyle.Flat;
            btnEditWorkout.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnEditWorkout.ForeColor = Color.White;
            btnEditWorkout.Location = new Point(432, 35);
            btnEditWorkout.Name = "btnEditWorkout";
            btnEditWorkout.Size = new Size(291, 50);
            btnEditWorkout.TabIndex = 39;
            btnEditWorkout.Text = "Edit workout";
            btnEditWorkout.UseVisualStyleBackColor = false;
            btnEditWorkout.Click += btnEditWorkout_Click_1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel3);
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(cmbLevel);
            tabPage2.Controls.Add(btnCreateWorkout);
            tabPage2.Controls.Add(rchtxtbDescription);
            tabPage2.Controls.Add(txtName);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1008, 504);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.ForeColor = Color.Red;
            panel3.Location = new Point(129, 332);
            panel3.Name = "panel3";
            panel3.Size = new Size(170, 1);
            panel3.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.ForeColor = Color.Red;
            panel2.Location = new Point(129, 266);
            panel2.Name = "panel2";
            panel2.Size = new Size(218, 1);
            panel2.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.ForeColor = Color.Red;
            panel1.Location = new Point(129, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(170, 1);
            panel1.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(59, 299);
            label4.Name = "label4";
            label4.Size = new Size(64, 22);
            label4.TabIndex = 6;
            label4.Text = "Level:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(6, 81);
            label3.Name = "label3";
            label3.Size = new Size(117, 22);
            label3.TabIndex = 5;
            label3.Text = "Description:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(56, 23);
            label2.Name = "label2";
            label2.Size = new Size(67, 22);
            label2.TabIndex = 4;
            label2.Text = "Name:";
            // 
            // cmbLevel
            // 
            cmbLevel.FlatStyle = FlatStyle.Flat;
            cmbLevel.FormattingEnabled = true;
            cmbLevel.Items.AddRange(new object[] { "Beginner", "Advanced", "Intermediate" });
            cmbLevel.Location = new Point(129, 298);
            cmbLevel.Name = "cmbLevel";
            cmbLevel.Size = new Size(170, 28);
            cmbLevel.TabIndex = 3;
            // 
            // btnCreateWorkout
            // 
            btnCreateWorkout.BackColor = Color.Red;
            btnCreateWorkout.FlatStyle = FlatStyle.Flat;
            btnCreateWorkout.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnCreateWorkout.ForeColor = Color.White;
            btnCreateWorkout.Location = new Point(455, 23);
            btnCreateWorkout.Name = "btnCreateWorkout";
            btnCreateWorkout.Size = new Size(283, 67);
            btnCreateWorkout.TabIndex = 2;
            btnCreateWorkout.Text = "Creat a workout";
            btnCreateWorkout.UseVisualStyleBackColor = false;
            btnCreateWorkout.Click += btnCreateWorkout_Click;
            // 
            // rchtxtbDescription
            // 
            rchtxtbDescription.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            rchtxtbDescription.ForeColor = Color.Red;
            rchtxtbDescription.Location = new Point(129, 80);
            rchtxtbDescription.Name = "rchtxtbDescription";
            rchtxtbDescription.Size = new Size(218, 180);
            rchtxtbDescription.TabIndex = 1;
            rchtxtbDescription.Text = "";
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtName.Location = new Point(129, 23);
            txtName.Name = "txtName";
            txtName.Size = new Size(170, 21);
            txtName.TabIndex = 0;
            // 
            // UC_SuggestionsPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tabControl1);
            Name = "UC_SuggestionsPage";
            Size = new Size(1022, 543);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox textBox1;
        private Label label1;
        private ListBox lstbWorkout;
        private Button btnEditWorkout;
        private TabPage tabPage2;
        private TextBox txtName;
        private Button btnCreateWorkout;
        private RichTextBox rchtxtbDescription;
        private ComboBox cmbLevel;
        private Panel panel2;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
    }
}
