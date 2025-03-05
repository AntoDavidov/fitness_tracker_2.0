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
            AllWorkouts = new TabPage();
            btnClear = new Button();
            panel6 = new Panel();
            label1 = new Label();
            cmbSearchLevel = new ComboBox();
            btnSearch = new Button();
            btnDeleteWorkout = new Button();
            panel5 = new Panel();
            panel4 = new Panel();
            txtbSeachName = new TextBox();
            lstbWorkout = new ListBox();
            btnEditWorkout = new Button();
            CreationOfWorkouts = new TabPage();
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
            AllWorkouts.SuspendLayout();
            CreationOfWorkouts.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(AllWorkouts);
            tabControl1.Controls.Add(CreationOfWorkouts);
            tabControl1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1016, 537);
            tabControl1.TabIndex = 39;
            // 
            // AllWorkouts
            // 
            AllWorkouts.BackColor = Color.White;
            AllWorkouts.Controls.Add(btnClear);
            AllWorkouts.Controls.Add(panel6);
            AllWorkouts.Controls.Add(label1);
            AllWorkouts.Controls.Add(cmbSearchLevel);
            AllWorkouts.Controls.Add(btnSearch);
            AllWorkouts.Controls.Add(btnDeleteWorkout);
            AllWorkouts.Controls.Add(panel5);
            AllWorkouts.Controls.Add(panel4);
            AllWorkouts.Controls.Add(txtbSeachName);
            AllWorkouts.Controls.Add(lstbWorkout);
            AllWorkouts.Controls.Add(btnEditWorkout);
            AllWorkouts.ForeColor = Color.Red;
            AllWorkouts.Location = new Point(4, 31);
            AllWorkouts.Name = "AllWorkouts";
            AllWorkouts.Padding = new Padding(3);
            AllWorkouts.Size = new Size(1008, 502);
            AllWorkouts.TabIndex = 0;
            AllWorkouts.Text = "All Workouts";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnClear.ForeColor = Color.Red;
            btnClear.Location = new Point(410, 37);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(73, 34);
            btnClear.TabIndex = 50;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Red;
            panel6.ForeColor = Color.Red;
            panel6.Location = new Point(159, 138);
            panel6.Name = "panel6";
            panel6.Size = new Size(324, 1);
            panel6.TabIndex = 49;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(89, 107);
            label1.Name = "label1";
            label1.Size = new Size(64, 22);
            label1.TabIndex = 48;
            label1.Text = "Level:";
            // 
            // cmbSearchLevel
            // 
            cmbSearchLevel.FlatStyle = FlatStyle.Flat;
            cmbSearchLevel.FormattingEnabled = true;
            cmbSearchLevel.Items.AddRange(new object[] { "Beginner", "Advanced", "Intermediate" });
            cmbSearchLevel.Location = new Point(159, 104);
            cmbSearchLevel.Name = "cmbSearchLevel";
            cmbSearchLevel.Size = new Size(324, 30);
            cmbSearchLevel.TabIndex = 47;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnSearch.ForeColor = Color.Red;
            btnSearch.Location = new Point(24, 25);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(129, 39);
            btnSearch.TabIndex = 46;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDeleteWorkout
            // 
            btnDeleteWorkout.BackColor = Color.White;
            btnDeleteWorkout.FlatStyle = FlatStyle.Flat;
            btnDeleteWorkout.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnDeleteWorkout.ForeColor = Color.Red;
            btnDeleteWorkout.Location = new Point(508, 113);
            btnDeleteWorkout.Name = "btnDeleteWorkout";
            btnDeleteWorkout.Size = new Size(291, 50);
            btnDeleteWorkout.TabIndex = 45;
            btnDeleteWorkout.Text = "Delete workout";
            btnDeleteWorkout.UseVisualStyleBackColor = false;
            btnDeleteWorkout.Click += btnDeleteWorkout_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Red;
            panel5.ForeColor = Color.Red;
            panel5.Location = new Point(94, 421);
            panel5.Name = "panel5";
            panel5.Size = new Size(389, 1);
            panel5.TabIndex = 44;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Red;
            panel4.ForeColor = Color.Red;
            panel4.Location = new Point(159, 70);
            panel4.Name = "panel4";
            panel4.Size = new Size(235, 1);
            panel4.TabIndex = 43;
            // 
            // txtbSeachName
            // 
            txtbSeachName.BorderStyle = BorderStyle.None;
            txtbSeachName.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbSeachName.ForeColor = Color.Red;
            txtbSeachName.Location = new Point(159, 43);
            txtbSeachName.Name = "txtbSeachName";
            txtbSeachName.Size = new Size(235, 21);
            txtbSeachName.TabIndex = 42;
            txtbSeachName.TextChanged += txtbSeachName_TextChanged;
            // 
            // lstbWorkout
            // 
            lstbWorkout.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lstbWorkout.ForeColor = Color.Red;
            lstbWorkout.FormattingEnabled = true;
            lstbWorkout.ItemHeight = 22;
            lstbWorkout.Location = new Point(94, 169);
            lstbWorkout.Name = "lstbWorkout";
            lstbWorkout.Size = new Size(389, 246);
            lstbWorkout.TabIndex = 40;
            lstbWorkout.SelectedIndexChanged += lstbWorkout_SelectedIndexChanged;
            // 
            // btnEditWorkout
            // 
            btnEditWorkout.BackColor = Color.White;
            btnEditWorkout.FlatStyle = FlatStyle.Flat;
            btnEditWorkout.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnEditWorkout.ForeColor = Color.Red;
            btnEditWorkout.Location = new Point(508, 29);
            btnEditWorkout.Name = "btnEditWorkout";
            btnEditWorkout.Size = new Size(291, 50);
            btnEditWorkout.TabIndex = 39;
            btnEditWorkout.Text = "Edit workout";
            btnEditWorkout.UseVisualStyleBackColor = false;
            btnEditWorkout.Click += btnEditWorkout_Click_1;
            // 
            // CreationOfWorkouts
            // 
            CreationOfWorkouts.BackgroundImageLayout = ImageLayout.None;
            CreationOfWorkouts.Controls.Add(panel3);
            CreationOfWorkouts.Controls.Add(panel2);
            CreationOfWorkouts.Controls.Add(panel1);
            CreationOfWorkouts.Controls.Add(label4);
            CreationOfWorkouts.Controls.Add(label3);
            CreationOfWorkouts.Controls.Add(label2);
            CreationOfWorkouts.Controls.Add(cmbLevel);
            CreationOfWorkouts.Controls.Add(btnCreateWorkout);
            CreationOfWorkouts.Controls.Add(rchtxtbDescription);
            CreationOfWorkouts.Controls.Add(txtName);
            CreationOfWorkouts.ForeColor = Color.Red;
            CreationOfWorkouts.Location = new Point(4, 31);
            CreationOfWorkouts.Name = "CreationOfWorkouts";
            CreationOfWorkouts.Padding = new Padding(3);
            CreationOfWorkouts.Size = new Size(1008, 502);
            CreationOfWorkouts.TabIndex = 1;
            CreationOfWorkouts.Text = "Creation of Workouts";
            CreationOfWorkouts.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.ForeColor = Color.Red;
            panel3.Location = new Point(129, 330);
            panel3.Name = "panel3";
            panel3.Size = new Size(324, 1);
            panel3.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.ForeColor = Color.Red;
            panel2.Location = new Point(129, 266);
            panel2.Name = "panel2";
            panel2.Size = new Size(382, 1);
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
            label4.Location = new Point(59, 297);
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
            cmbLevel.Location = new Point(129, 296);
            cmbLevel.Name = "cmbLevel";
            cmbLevel.Size = new Size(324, 30);
            cmbLevel.TabIndex = 3;
            // 
            // btnCreateWorkout
            // 
            btnCreateWorkout.BackColor = Color.White;
            btnCreateWorkout.FlatStyle = FlatStyle.Flat;
            btnCreateWorkout.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnCreateWorkout.ForeColor = Color.Red;
            btnCreateWorkout.Location = new Point(534, 50);
            btnCreateWorkout.Name = "btnCreateWorkout";
            btnCreateWorkout.Size = new Size(283, 67);
            btnCreateWorkout.TabIndex = 2;
            btnCreateWorkout.Text = "Create a workout";
            btnCreateWorkout.UseVisualStyleBackColor = false;
            btnCreateWorkout.Click += btnCreateWorkout_Click;
            // 
            // rchtxtbDescription
            // 
            rchtxtbDescription.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            rchtxtbDescription.ForeColor = Color.Red;
            rchtxtbDescription.Location = new Point(129, 80);
            rchtxtbDescription.Name = "rchtxtbDescription";
            rchtxtbDescription.Size = new Size(382, 180);
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
            AllWorkouts.ResumeLayout(false);
            AllWorkouts.PerformLayout();
            CreationOfWorkouts.ResumeLayout(false);
            CreationOfWorkouts.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage AllWorkouts;
        private TextBox txtbSeachName;
        private ListBox lstbWorkout;
        private Button btnEditWorkout;
        private TabPage CreationOfWorkouts;
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
        private Button btnDeleteWorkout;
        private Button btnSearch;
        private Panel panel6;
        private Label label1;
        private ComboBox cmbSearchLevel;
        private Button btnClear;
    }
}
