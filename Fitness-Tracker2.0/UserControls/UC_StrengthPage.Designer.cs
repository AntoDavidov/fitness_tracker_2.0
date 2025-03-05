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
            txtbSearch = new TextBox();
            panel7 = new Panel();
            btnSearch = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label7 = new Label();
            label8 = new Label();
            panel8 = new Panel();
            panel9 = new Panel();
            nudHours = new NumericUpDown();
            nudSeconds = new NumericUpDown();
            nudMinutes = new NumericUpDown();
            label9 = new Label();
            panel10 = new Panel();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)nmudReps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmudSets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmudWeight).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudHours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSeconds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinutes).BeginInit();
            SuspendLayout();
            // 
            // txtbName
            // 
            txtbName.BorderStyle = BorderStyle.None;
            txtbName.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbName.ForeColor = Color.Red;
            txtbName.Location = new Point(158, 21);
            txtbName.Name = "txtbName";
            txtbName.Size = new Size(170, 21);
            txtbName.TabIndex = 0;
            // 
            // rchtxtbDescription
            // 
            rchtxtbDescription.BorderStyle = BorderStyle.None;
            rchtxtbDescription.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            rchtxtbDescription.ForeColor = Color.Red;
            rchtxtbDescription.Location = new Point(158, 81);
            rchtxtbDescription.Name = "rchtxtbDescription";
            rchtxtbDescription.Size = new Size(362, 41);
            rchtxtbDescription.TabIndex = 1;
            rchtxtbDescription.Text = "";
            rchtxtbDescription.TextChanged += rchtxtbDescription_TextChanged;
            // 
            // cmbMuscle
            // 
            cmbMuscle.FlatStyle = FlatStyle.Flat;
            cmbMuscle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            cmbMuscle.ForeColor = Color.Red;
            cmbMuscle.FormattingEnabled = true;
            cmbMuscle.Items.AddRange(new object[] { "Chest", "Back", "Bicep", "Tricep", "Legs", "Core" });
            cmbMuscle.Location = new Point(111, 41);
            cmbMuscle.Name = "cmbMuscle";
            cmbMuscle.Size = new Size(170, 30);
            cmbMuscle.TabIndex = 2;
            // 
            // nmudReps
            // 
            nmudReps.BorderStyle = BorderStyle.None;
            nmudReps.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nmudReps.ForeColor = Color.Red;
            nmudReps.Location = new Point(106, 102);
            nmudReps.Name = "nmudReps";
            nmudReps.Size = new Size(182, 24);
            nmudReps.TabIndex = 3;
            // 
            // nmudSets
            // 
            nmudSets.BorderStyle = BorderStyle.None;
            nmudSets.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nmudSets.ForeColor = Color.Red;
            nmudSets.Location = new Point(106, 155);
            nmudSets.Name = "nmudSets";
            nmudSets.Size = new Size(182, 24);
            nmudSets.TabIndex = 4;
            // 
            // nmudWeight
            // 
            nmudWeight.BorderStyle = BorderStyle.None;
            nmudWeight.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nmudWeight.ForeColor = Color.Red;
            nmudWeight.Location = new Point(106, 208);
            nmudWeight.Name = "nmudWeight";
            nmudWeight.Size = new Size(182, 24);
            nmudWeight.TabIndex = 5;
            // 
            // btnAddExercise
            // 
            btnAddExercise.BackColor = Color.White;
            btnAddExercise.FlatStyle = FlatStyle.Flat;
            btnAddExercise.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAddExercise.ForeColor = Color.Red;
            btnAddExercise.Location = new Point(385, 179);
            btnAddExercise.Name = "btnAddExercise";
            btnAddExercise.Size = new Size(162, 40);
            btnAddExercise.TabIndex = 6;
            btnAddExercise.Text = "Add Exercise";
            btnAddExercise.UseVisualStyleBackColor = false;
            btnAddExercise.Click += btnAddExercise_Click;
            // 
            // btnDeleteExercise
            // 
            btnDeleteExercise.BackColor = Color.White;
            btnDeleteExercise.FlatStyle = FlatStyle.Flat;
            btnDeleteExercise.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDeleteExercise.ForeColor = Color.Red;
            btnDeleteExercise.Location = new Point(385, 242);
            btnDeleteExercise.Name = "btnDeleteExercise";
            btnDeleteExercise.Size = new Size(162, 40);
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
            lstbExercises.Location = new Point(568, 70);
            lstbExercises.Name = "lstbExercises";
            lstbExercises.Size = new Size(398, 220);
            lstbExercises.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(85, 21);
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
            label2.Location = new Point(23, 70);
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
            label3.Location = new Point(27, 49);
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
            label4.Location = new Point(44, 154);
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
            label5.Location = new Point(38, 104);
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
            label6.Location = new Point(22, 208);
            label6.Name = "label6";
            label6.Size = new Size(78, 22);
            label6.TabIndex = 14;
            label6.Text = "Weight:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Location = new Point(158, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(170, 1);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.Location = new Point(111, 77);
            panel2.Name = "panel2";
            panel2.Size = new Size(170, 1);
            panel2.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.Location = new Point(158, 128);
            panel3.Name = "panel3";
            panel3.Size = new Size(362, 1);
            panel3.TabIndex = 16;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Red;
            panel4.Location = new Point(106, 132);
            panel4.Name = "panel4";
            panel4.Size = new Size(182, 1);
            panel4.TabIndex = 16;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Red;
            panel5.Location = new Point(106, 185);
            panel5.Name = "panel5";
            panel5.Size = new Size(182, 1);
            panel5.TabIndex = 17;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Red;
            panel6.Location = new Point(106, 238);
            panel6.Name = "panel6";
            panel6.Size = new Size(182, 1);
            panel6.TabIndex = 17;
            // 
            // txtbSearch
            // 
            txtbSearch.BorderStyle = BorderStyle.None;
            txtbSearch.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbSearch.Location = new Point(568, 23);
            txtbSearch.Name = "txtbSearch";
            txtbSearch.Size = new Size(250, 21);
            txtbSearch.TabIndex = 19;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Red;
            panel7.Location = new Point(568, 50);
            panel7.Name = "panel7";
            panel7.Size = new Size(250, 1);
            panel7.TabIndex = 16;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSearch.ForeColor = Color.Red;
            btnSearch.Location = new Point(824, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(133, 31);
            btnSearch.TabIndex = 20;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(36, 135);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(343, 312);
            tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(cmbMuscle);
            tabPage1.Controls.Add(panel6);
            tabPage1.Controls.Add(nmudReps);
            tabPage1.Controls.Add(panel5);
            tabPage1.Controls.Add(nmudSets);
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(nmudWeight);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label5);
            tabPage1.ForeColor = Color.Red;
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(335, 279);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Strength";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.BorderStyle = BorderStyle.Fixed3D;
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(panel8);
            tabPage2.Controls.Add(panel9);
            tabPage2.Controls.Add(nudHours);
            tabPage2.Controls.Add(nudSeconds);
            tabPage2.Controls.Add(nudMinutes);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(panel10);
            tabPage2.ForeColor = Color.Red;
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(335, 279);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Cardio";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(35, 159);
            label7.Name = "label7";
            label7.Size = new Size(93, 22);
            label7.TabIndex = 55;
            label7.Text = "Seconds:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(35, 112);
            label8.Name = "label8";
            label8.Size = new Size(85, 22);
            label8.TabIndex = 54;
            label8.Text = "Minutes:";
            // 
            // panel8
            // 
            panel8.BackColor = Color.Red;
            panel8.Location = new Point(133, 187);
            panel8.Name = "panel8";
            panel8.Size = new Size(176, 1);
            panel8.TabIndex = 50;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Red;
            panel9.Location = new Point(133, 140);
            panel9.Name = "panel9";
            panel9.Size = new Size(176, 1);
            panel9.TabIndex = 51;
            // 
            // nudHours
            // 
            nudHours.BorderStyle = BorderStyle.None;
            nudHours.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nudHours.ForeColor = Color.Red;
            nudHours.Location = new Point(133, 61);
            nudHours.Name = "nudHours";
            nudHours.Size = new Size(176, 24);
            nudHours.TabIndex = 43;
            // 
            // nudSeconds
            // 
            nudSeconds.BorderStyle = BorderStyle.None;
            nudSeconds.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nudSeconds.ForeColor = Color.Red;
            nudSeconds.Location = new Point(133, 157);
            nudSeconds.Name = "nudSeconds";
            nudSeconds.Size = new Size(176, 24);
            nudSeconds.TabIndex = 53;
            // 
            // nudMinutes
            // 
            nudMinutes.BorderStyle = BorderStyle.None;
            nudMinutes.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nudMinutes.ForeColor = Color.Red;
            nudMinutes.Location = new Point(133, 110);
            nudMinutes.Name = "nudMinutes";
            nudMinutes.Size = new Size(176, 24);
            nudMinutes.TabIndex = 52;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(35, 61);
            label9.Name = "label9";
            label9.Size = new Size(69, 22);
            label9.TabIndex = 46;
            label9.Text = "Hours:";
            // 
            // panel10
            // 
            panel10.BackColor = Color.Red;
            panel10.Location = new Point(133, 91);
            panel10.Name = "panel10";
            panel10.Size = new Size(176, 1);
            panel10.TabIndex = 49;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnClear.ForeColor = Color.Red;
            btnClear.Location = new Point(854, 296);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(103, 31);
            btnClear.TabIndex = 22;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // UC_StrengthPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnClear);
            Controls.Add(txtbName);
            Controls.Add(lstbExercises);
            Controls.Add(rchtxtbDescription);
            Controls.Add(tabControl1);
            Controls.Add(btnSearch);
            Controls.Add(panel7);
            Controls.Add(txtbSearch);
            Controls.Add(btnDeleteExercise);
            Controls.Add(btnAddExercise);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(label2);
            Name = "UC_StrengthPage";
            Size = new Size(999, 589);
            ((System.ComponentModel.ISupportInitialize)nmudReps).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmudSets).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmudWeight).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudHours).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSeconds).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinutes).EndInit();
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
        private TextBox txtbSearch;
        private Panel panel7;
        private Button btnSearch;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label7;
        private Label label8;
        private Panel panel8;
        private Panel panel9;
        private NumericUpDown nudHours;
        private NumericUpDown nudSeconds;
        private NumericUpDown nudMinutes;
        private Label label9;
        private Panel panel10;
        private Button btnClear;
    }
}
