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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lstbCurrentWorkoutExercises
            // 
            lstbCurrentWorkoutExercises.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lstbCurrentWorkoutExercises.ForeColor = Color.Red;
            lstbCurrentWorkoutExercises.FormattingEnabled = true;
            lstbCurrentWorkoutExercises.ItemHeight = 22;
            lstbCurrentWorkoutExercises.Location = new Point(83, 101);
            lstbCurrentWorkoutExercises.Name = "lstbCurrentWorkoutExercises";
            lstbCurrentWorkoutExercises.Size = new Size(338, 400);
            lstbCurrentWorkoutExercises.TabIndex = 0;
            // 
            // lstbExercises
            // 
            lstbExercises.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lstbExercises.ForeColor = Color.Red;
            lstbExercises.FormattingEnabled = true;
            lstbExercises.ItemHeight = 22;
            lstbExercises.Location = new Point(652, 101);
            lstbExercises.Name = "lstbExercises";
            lstbExercises.Size = new Size(338, 400);
            lstbExercises.TabIndex = 2;
            lstbExercises.SelectedIndexChanged += lstbExercises_SelectedIndexChanged;
            // 
            // cmbFilter
            // 
            cmbFilter.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            cmbFilter.ForeColor = Color.Red;
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "Strength", "Cardio" });
            cmbFilter.Location = new Point(190, 44);
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
            lblWorkoutName.Location = new Point(726, 52);
            lblWorkoutName.Name = "lblWorkoutName";
            lblWorkoutName.Size = new Size(0, 22);
            lblWorkoutName.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(47, 47);
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
            // frmTrainerWorkoutCreationPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1125, 594);
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
    }
}