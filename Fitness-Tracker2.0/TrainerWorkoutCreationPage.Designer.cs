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
            SuspendLayout();
            // 
            // lstbCurrentWorkoutExercises
            // 
            lstbCurrentWorkoutExercises.FormattingEnabled = true;
            lstbCurrentWorkoutExercises.Location = new Point(622, 110);
            lstbCurrentWorkoutExercises.Name = "lstbCurrentWorkoutExercises";
            lstbCurrentWorkoutExercises.Size = new Size(289, 384);
            lstbCurrentWorkoutExercises.TabIndex = 0;
            // 
            // lstbExercises
            // 
            lstbExercises.FormattingEnabled = true;
            lstbExercises.Location = new Point(95, 115);
            lstbExercises.Name = "lstbExercises";
            lstbExercises.Size = new Size(338, 404);
            lstbExercises.TabIndex = 2;
            lstbExercises.SelectedIndexChanged += lstbExercises_SelectedIndexChanged;
            // 
            // cmbFilter
            // 
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "Strength", "Cardio" });
            cmbFilter.Location = new Point(110, 56);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(181, 28);
            cmbFilter.TabIndex = 3;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // lblWorkoutName
            // 
            lblWorkoutName.AutoSize = true;
            lblWorkoutName.Location = new Point(637, 47);
            lblWorkoutName.Name = "lblWorkoutName";
            lblWorkoutName.Size = new Size(50, 20);
            lblWorkoutName.TabIndex = 4;
            lblWorkoutName.Text = "label1";
            // 
            // frmTrainerWorkoutCreationPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 594);
            Controls.Add(lblWorkoutName);
            Controls.Add(cmbFilter);
            Controls.Add(lstbExercises);
            Controls.Add(lstbCurrentWorkoutExercises);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmTrainerWorkoutCreationPage";
            Text = "Workout Creation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstbCurrentWorkoutExercises;
        private ListBox lstbExercises;
        private ComboBox cmbFilter;
        private Label lblWorkoutName;
    }
}