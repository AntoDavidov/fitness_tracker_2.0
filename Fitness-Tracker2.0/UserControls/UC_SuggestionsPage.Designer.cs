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
            textBox1 = new TextBox();
            label1 = new Label();
            lstbWorkout = new ListBox();
            btnEditWorkout = new Button();
            tabPage2 = new TabPage();
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
            // textBox1
            // 
            textBox1.Location = new Point(108, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(183, 27);
            textBox1.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 18);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
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
            lstbWorkout.Size = new Size(291, 334);
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
            // cmbLevel
            // 
            cmbLevel.FormattingEnabled = true;
            cmbLevel.Items.AddRange(new object[] { "Beginner", "Advanced", "Intermediate" });
            cmbLevel.Location = new Point(72, 364);
            cmbLevel.Name = "cmbLevel";
            cmbLevel.Size = new Size(293, 28);
            cmbLevel.TabIndex = 3;
            // 
            // btnCreateWorkout
            // 
            btnCreateWorkout.Location = new Point(514, 63);
            btnCreateWorkout.Name = "btnCreateWorkout";
            btnCreateWorkout.Size = new Size(283, 67);
            btnCreateWorkout.TabIndex = 2;
            btnCreateWorkout.Text = "button1";
            btnCreateWorkout.UseVisualStyleBackColor = true;
            btnCreateWorkout.Click += btnCreateWorkout_Click;
            // 
            // rchtxtbDescription
            // 
            rchtxtbDescription.Location = new Point(72, 63);
            rchtxtbDescription.Name = "rchtxtbDescription";
            rchtxtbDescription.Size = new Size(292, 268);
            rchtxtbDescription.TabIndex = 1;
            rchtxtbDescription.Text = "";
            // 
            // txtName
            // 
            txtName.Location = new Point(145, 18);
            txtName.Name = "txtName";
            txtName.Size = new Size(192, 27);
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
    }
}
