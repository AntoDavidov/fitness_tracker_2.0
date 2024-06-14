namespace Fitness_Tracker2._0
{
    partial class frmTrainerWorkoutCreationPage
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
            lstbCurrentWorkoutExercises = new ListBox();
            lstbExercises = new ListBox();
            cmbFilter = new ComboBox();
            lblWorkoutName = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnRemoveExercise = new Button();
            btnSearch = new Button();
            textBox1 = new TextBox();
            panel1 = new Panel();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lstbCurrentWorkoutExercises
            // 
            lstbCurrentWorkoutExercises.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lstbCurrentWorkoutExercises.ForeColor = Color.Red;
            lstbCurrentWorkoutExercises.FormattingEnabled = true;
            lstbCurrentWorkoutExercises.ItemHeight = 22;
            lstbCurrentWorkoutExercises.Location = new Point(599, 167);
            lstbCurrentWorkoutExercises.Name = "lstbCurrentWorkoutExercises";
            lstbCurrentWorkoutExercises.Size = new Size(440, 334);
            lstbCurrentWorkoutExercises.TabIndex = 0;
            // 
            // lstbExercises
            // 
            lstbExercises.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lstbExercises.ForeColor = Color.Red;
            lstbExercises.FormattingEnabled = true;
            lstbExercises.ItemHeight = 22;
            lstbExercises.Location = new Point(47, 167);
            lstbExercises.Name = "lstbExercises";
            lstbExercises.Size = new Size(440, 334);
            lstbExercises.TabIndex = 2;
            lstbExercises.SelectedIndexChanged += lstbExercises_SelectedIndexChanged;
            // 
            // cmbFilter
            // 
            cmbFilter.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            cmbFilter.ForeColor = Color.Red;
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "Strength", "Cardio" });
            cmbFilter.Location = new Point(190, 100);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(181, 30);
            cmbFilter.TabIndex = 3;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // lblWorkoutName
            // 
            lblWorkoutName.AutoSize = true;
            lblWorkoutName.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lblWorkoutName.ForeColor = Color.Red;
            lblWorkoutName.Location = new Point(599, 48);
            lblWorkoutName.Name = "lblWorkoutName";
            lblWorkoutName.Size = new Size(0, 22);
            lblWorkoutName.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(47, 103);
            label1.Name = "label1";
            label1.Size = new Size(137, 22);
            label1.TabIndex = 5;
            label1.Text = "Exercise type:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._190238;
            pictureBox1.Location = new Point(12, 532);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(72, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnRemoveExercise
            // 
            btnRemoveExercise.BackColor = Color.White;
            btnRemoveExercise.FlatStyle = FlatStyle.Flat;
            btnRemoveExercise.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnRemoveExercise.ForeColor = Color.Red;
            btnRemoveExercise.Location = new Point(906, 44);
            btnRemoveExercise.Name = "btnRemoveExercise";
            btnRemoveExercise.Size = new Size(191, 43);
            btnRemoveExercise.TabIndex = 7;
            btnRemoveExercise.Text = "Remove exercise";
            btnRemoveExercise.UseVisualStyleBackColor = false;
            btnRemoveExercise.Click += btnRemoveExercise_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSearch.ForeColor = Color.Red;
            btnSearch.Location = new Point(38, 31);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(146, 31);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            textBox1.ForeColor = Color.Red;
            textBox1.Location = new Point(190, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(211, 21);
            textBox1.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.ForeColor = Color.Red;
            panel1.Location = new Point(190, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(211, 1);
            panel1.TabIndex = 10;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnClear.ForeColor = Color.Red;
            btnClear.Location = new Point(394, 100);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(93, 58);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // frmTrainerWorkoutCreationPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1125, 594);
            Controls.Add(btnClear);
            Controls.Add(panel1);
            Controls.Add(textBox1);
            Controls.Add(btnSearch);
            Controls.Add(btnRemoveExercise);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(lblWorkoutName);
            Controls.Add(cmbFilter);
            Controls.Add(lstbExercises);
            Controls.Add(lstbCurrentWorkoutExercises);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmTrainerWorkoutCreationPage";
            Text = "Workout Creation";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstbCurrentWorkoutExercises;
        private ListBox lstbExercises;
        private ComboBox cmbFilter;
        private Label lblWorkoutName;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnRemoveExercise;
        private Button btnSearch;
        private TextBox textBox1;
        private Panel panel1;
        private Button btnClear;
    }
}