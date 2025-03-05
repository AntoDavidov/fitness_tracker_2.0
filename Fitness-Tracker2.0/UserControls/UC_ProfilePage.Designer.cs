namespace Fitness_Tracker2._0.UserControls
{
    partial class ucProfilePage
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
            btnSearch = new Button();
            panel7 = new Panel();
            txtbSearch = new TextBox();
            lstbExercises = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSearch.ForeColor = Color.Red;
            btnSearch.Location = new Point(327, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(143, 31);
            btnSearch.TabIndex = 24;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Red;
            panel7.Location = new Point(51, 52);
            panel7.Name = "panel7";
            panel7.Size = new Size(250, 1);
            panel7.TabIndex = 22;
            // 
            // txtbSearch
            // 
            txtbSearch.BorderStyle = BorderStyle.None;
            txtbSearch.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            txtbSearch.Location = new Point(51, 25);
            txtbSearch.Name = "txtbSearch";
            txtbSearch.Size = new Size(250, 21);
            txtbSearch.TabIndex = 23;
            // 
            // lstbExercises
            // 
            lstbExercises.BorderStyle = BorderStyle.None;
            lstbExercises.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lstbExercises.ForeColor = Color.Red;
            lstbExercises.FormattingEnabled = true;
            lstbExercises.ItemHeight = 22;
            lstbExercises.Location = new Point(72, 70);
            lstbExercises.Name = "lstbExercises";
            lstbExercises.Size = new Size(398, 330);
            lstbExercises.TabIndex = 21;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(574, 100);
            button1.Name = "button1";
            button1.Size = new Size(161, 41);
            button1.TabIndex = 25;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = false;
            // 
            // ucProfilePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button1);
            Controls.Add(btnSearch);
            Controls.Add(panel7);
            Controls.Add(txtbSearch);
            Controls.Add(lstbExercises);
            Name = "ucProfilePage";
            Size = new Size(992, 549);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private Panel panel7;
        private TextBox txtbSearch;
        private ListBox lstbExercises;
        private Button button1;
    }
}
