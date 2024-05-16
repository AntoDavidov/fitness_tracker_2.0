namespace Fitness_Tracker2._0.UserControls
{
    partial class UC_StrengthPage
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
            txtbName = new TextBox();
            rchtxtbDescription = new RichTextBox();
            cmbMuscle = new ComboBox();
            nmudReps = new NumericUpDown();
            nmudSets = new NumericUpDown();
            nmudWeight = new NumericUpDown();
            btnAddExercise = new Button();
            btnDeleteExercise = new Button();
            lstbExercises = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            label7 = new Label();
            txtbSearch = new TextBox();
            panel7 = new Panel();
            ((System.ComponentModel.ISupportInitialize)nmudReps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmudSets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmudWeight).BeginInit();
            SuspendLayout();
            // 
            // txtbName
            // 
            txtbName.BorderStyle = BorderStyle.None;
            txtbName.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbName.ForeColor = Color.Red;
            txtbName.Location = new Point(144, 38);
            txtbName.Name = "txtbName";
            txtbName.Size = new Size(170, 21);
            txtbName.TabIndex = 0;
            // 
            // rchtxtbDescription
            // 
            rchtxtbDescription.BorderStyle = BorderStyle.None;
            rchtxtbDescription.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            rchtxtbDescription.ForeColor = Color.Red;
            rchtxtbDescription.Location = new Point(144, 91);
            rchtxtbDescription.Name = "rchtxtbDescription";
            rchtxtbDescription.Size = new Size(170, 120);
            rchtxtbDescription.TabIndex = 1;
            rchtxtbDescription.Text = "";
            // 
            // cmbMuscle
            // 
            cmbMuscle.FlatStyle = FlatStyle.Flat;
            cmbMuscle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            cmbMuscle.ForeColor = Color.Red;
            cmbMuscle.FormattingEnabled = true;
            cmbMuscle.Items.AddRange(new object[] { "Chest", "Back", "Bicep", "Tricep", "Legs", "Core" });
            cmbMuscle.Location = new Point(144, 245);
            cmbMuscle.Name = "cmbMuscle";
            cmbMuscle.Size = new Size(170, 30);
            cmbMuscle.TabIndex = 2;
            // 
            // nmudReps
            // 
            nmudReps.BorderStyle = BorderStyle.None;
            nmudReps.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nmudReps.ForeColor = Color.Red;
            nmudReps.Location = new Point(95, 318);
            nmudReps.Name = "nmudReps";
            nmudReps.Size = new Size(150, 24);
            nmudReps.TabIndex = 3;
            // 
            // nmudSets
            // 
            nmudSets.BorderStyle = BorderStyle.None;
            nmudSets.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nmudSets.ForeColor = Color.Red;
            nmudSets.Location = new Point(320, 321);
            nmudSets.Name = "nmudSets";
            nmudSets.Size = new Size(150, 24);
            nmudSets.TabIndex = 4;
            // 
            // nmudWeight
            // 
            nmudWeight.BorderStyle = BorderStyle.None;
            nmudWeight.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nmudWeight.ForeColor = Color.Red;
            nmudWeight.Location = new Point(217, 372);
            nmudWeight.Name = "nmudWeight";
            nmudWeight.Size = new Size(150, 24);
            nmudWeight.TabIndex = 5;
            // 
            // btnAddExercise
            // 
            btnAddExercise.BackColor = Color.Red;
            btnAddExercise.FlatStyle = FlatStyle.Flat;
            btnAddExercise.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnAddExercise.ForeColor = Color.White;
            btnAddExercise.Location = new Point(358, 38);
            btnAddExercise.Name = "btnAddExercise";
            btnAddExercise.Size = new Size(162, 50);
            btnAddExercise.TabIndex = 6;
            btnAddExercise.Text = "Add Exercise";
            btnAddExercise.UseVisualStyleBackColor = false;
            btnAddExercise.Click += btnAddExercise_Click;
            // 
            // btnDeleteExercise
            // 
            btnDeleteExercise.BackColor = Color.Red;
            btnDeleteExercise.FlatStyle = FlatStyle.Flat;
            btnDeleteExercise.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnDeleteExercise.ForeColor = Color.White;
            btnDeleteExercise.Location = new Point(358, 110);
            btnDeleteExercise.Name = "btnDeleteExercise";
            btnDeleteExercise.Size = new Size(162, 50);
            btnDeleteExercise.TabIndex = 7;
            btnDeleteExercise.Text = "Delete Exercise";
            btnDeleteExercise.UseVisualStyleBackColor = false;
            btnDeleteExercise.Click += btnDeleteExercise_Click;
            // 
            // lstbExercises
            // 
            lstbExercises.BorderStyle = BorderStyle.None;
            lstbExercises.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lstbExercises.ForeColor = Color.Red;
            lstbExercises.FormattingEnabled = true;
            lstbExercises.ItemHeight = 22;
            lstbExercises.Location = new Point(539, 117);
            lstbExercises.Name = "lstbExercises";
            lstbExercises.Size = new Size(398, 396);
            lstbExercises.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(71, 38);
            label1.Name = "label1";
            label1.Size = new Size(67, 22);
            label1.TabIndex = 9;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(21, 91);
            label2.Name = "label2";
            label2.Size = new Size(117, 22);
            label2.TabIndex = 10;
            label2.Text = "Description:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(60, 253);
            label3.Name = "label3";
            label3.Size = new Size(78, 22);
            label3.TabIndex = 11;
            label3.Text = "Muscle:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(258, 320);
            label4.Name = "label4";
            label4.Size = new Size(56, 22);
            label4.TabIndex = 12;
            label4.Text = "Sets:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(15, 317);
            label5.Name = "label5";
            label5.Size = new Size(62, 22);
            label5.TabIndex = 13;
            label5.Text = "Reps:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(125, 371);
            label6.Name = "label6";
            label6.Size = new Size(78, 22);
            label6.TabIndex = 14;
            label6.Text = "Weight:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Location = new Point(144, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(170, 1);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.Location = new Point(144, 281);
            panel2.Name = "panel2";
            panel2.Size = new Size(170, 1);
            panel2.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.Location = new Point(144, 217);
            panel3.Name = "panel3";
            panel3.Size = new Size(170, 1);
            panel3.TabIndex = 16;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Red;
            panel4.Location = new Point(95, 351);
            panel4.Name = "panel4";
            panel4.Size = new Size(150, 1);
            panel4.TabIndex = 16;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Red;
            panel5.Location = new Point(320, 351);
            panel5.Name = "panel5";
            panel5.Size = new Size(150, 1);
            panel5.TabIndex = 17;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Red;
            panel6.Location = new Point(217, 405);
            panel6.Name = "panel6";
            panel6.Size = new Size(150, 1);
            panel6.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(564, 46);
            label7.Name = "label7";
            label7.Size = new Size(79, 22);
            label7.TabIndex = 18;
            label7.Text = "Search:";
            // 
            // txtbSearch
            // 
            txtbSearch.BorderStyle = BorderStyle.None;
            txtbSearch.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbSearch.Location = new Point(649, 47);
            txtbSearch.Name = "txtbSearch";
            txtbSearch.Size = new Size(250, 21);
            txtbSearch.TabIndex = 19;
            txtbSearch.TextChanged += textBox1_TextChanged;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Red;
            panel7.Location = new Point(649, 74);
            panel7.Name = "panel7";
            panel7.Size = new Size(250, 1);
            panel7.TabIndex = 16;
            // 
            // UC_StrengthPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel7);
            Controls.Add(txtbSearch);
            Controls.Add(label7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lstbExercises);
            Controls.Add(btnDeleteExercise);
            Controls.Add(btnAddExercise);
            Controls.Add(nmudWeight);
            Controls.Add(nmudSets);
            Controls.Add(nmudReps);
            Controls.Add(cmbMuscle);
            Controls.Add(rchtxtbDescription);
            Controls.Add(txtbName);
            Name = "UC_StrengthPage";
            Size = new Size(999, 589);
            Load += UC_StrengthPage_Load;
            ((System.ComponentModel.ISupportInitialize)nmudReps).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmudSets).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmudWeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbName;
        private RichTextBox rchtxtbDescription;
        private ComboBox cmbMuscle;
        private NumericUpDown nmudReps;
        private NumericUpDown nmudSets;
        private NumericUpDown nmudWeight;
        private Button btnAddExercise;
        private Button btnDeleteExercise;
        private ListBox lstbExercises;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label7;
        private TextBox txtbSearch;
        private Panel panel7;
    }
}
