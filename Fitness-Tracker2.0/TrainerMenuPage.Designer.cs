namespace Fitness_Tracker2._0
{
    partial class frmTrainerUCPage
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            btnSuggestions = new Button();
            btnStrength = new Button();
            panelContainer = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(995, 67);
            panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Fitness_Tracker__9_;
            pictureBox1.Location = new Point(0, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(79, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(85, 19);
            label1.Name = "label1";
            label1.Size = new Size(88, 29);
            label1.TabIndex = 0;
            label1.Text = "MENU";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnSuggestions);
            panel2.Controls.Add(btnStrength);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(995, 71);
            panel2.TabIndex = 5;
            // 
            // btnSuggestions
            // 
            btnSuggestions.BackColor = Color.White;
            btnSuggestions.FlatStyle = FlatStyle.Flat;
            btnSuggestions.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnSuggestions.ForeColor = Color.Red;
            btnSuggestions.Location = new Point(494, 3);
            btnSuggestions.Name = "btnSuggestions";
            btnSuggestions.Size = new Size(498, 65);
            btnSuggestions.TabIndex = 2;
            btnSuggestions.Text = "Workouts";
            btnSuggestions.UseVisualStyleBackColor = false;
            btnSuggestions.Click += btnSuggestions_Click;
            // 
            // btnStrength
            // 
            btnStrength.BackColor = Color.White;
            btnStrength.FlatStyle = FlatStyle.Flat;
            btnStrength.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnStrength.ForeColor = Color.Red;
            btnStrength.Location = new Point(3, 3);
            btnStrength.Name = "btnStrength";
            btnStrength.Size = new Size(485, 65);
            btnStrength.TabIndex = 0;
            btnStrength.Text = "Exercises";
            btnStrength.UseVisualStyleBackColor = false;
            btnStrength.Click += btnStrength_Click;
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 138);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(995, 466);
            panelContainer.TabIndex = 6;
            // 
            // frmTrainerUCPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 604);
            Controls.Add(panelContainer);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "frmTrainerUCPage";
            Text = "Menu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnSuggestions;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panelContainer;
        private Button btnStrength;
        private PictureBox pictureBox1;
    }
}