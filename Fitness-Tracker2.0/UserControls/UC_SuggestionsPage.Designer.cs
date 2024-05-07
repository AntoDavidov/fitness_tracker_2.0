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
            panel3 = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            lstbExercises = new ListBox();
            btnAddWorkout = new Button();
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.Location = new Point(469, 245);
            panel3.Name = "panel3";
            panel3.Size = new Size(170, 1);
            panel3.TabIndex = 35;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Location = new Point(469, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(170, 1);
            panel1.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(346, 119);
            label2.Name = "label2";
            label2.Size = new Size(117, 22);
            label2.TabIndex = 28;
            label2.Text = "Description:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(396, 66);
            label1.Name = "label1";
            label1.Size = new Size(67, 22);
            label1.TabIndex = 27;
            label1.Text = "Name:";
            // 
            // lstbExercises
            // 
            lstbExercises.BorderStyle = BorderStyle.None;
            lstbExercises.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            lstbExercises.ForeColor = Color.Red;
            lstbExercises.FormattingEnabled = true;
            lstbExercises.ItemHeight = 22;
            lstbExercises.Location = new Point(17, 18);
            lstbExercises.Name = "lstbExercises";
            lstbExercises.Size = new Size(301, 396);
            lstbExercises.TabIndex = 26;
            // 
            // btnAddWorkout
            // 
            btnAddWorkout.BackColor = Color.Red;
            btnAddWorkout.FlatStyle = FlatStyle.Flat;
            btnAddWorkout.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnAddWorkout.ForeColor = Color.White;
            btnAddWorkout.Location = new Point(426, 350);
            btnAddWorkout.Name = "btnAddWorkout";
            btnAddWorkout.Size = new Size(162, 50);
            btnAddWorkout.TabIndex = 24;
            btnAddWorkout.Text = "Add Workout";
            btnAddWorkout.UseVisualStyleBackColor = false;
            btnAddWorkout.Click += btnAddWorkout_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            richTextBox1.ForeColor = Color.Red;
            richTextBox1.Location = new Point(469, 119);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(170, 120);
            richTextBox1.TabIndex = 19;
            richTextBox1.Text = "";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            textBox1.ForeColor = Color.Red;
            textBox1.Location = new Point(469, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(170, 21);
            textBox1.TabIndex = 18;
            // 
            // UC_SuggestionsPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lstbExercises);
            Controls.Add(btnAddWorkout);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Name = "UC_SuggestionsPage";
            Size = new Size(1022, 543);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel3;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private ListBox lstbExercises;
        private Button btnAddWorkout;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
    }
}
