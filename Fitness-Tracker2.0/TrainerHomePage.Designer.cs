namespace Fitness_Tracker2._0
{
    partial class frmTrainerHomePage
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
            txtbName = new TextBox();
            btnCreate = new Button();
            listBox1 = new ListBox();
            rchtxtbDescription = new RichTextBox();
            cmbMuscle = new ComboBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnDelete = new Button();
            nmudReps = new NumericUpDown();
            nmudSets = new NumericUpDown();
            nmudWeight = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
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
            txtbName.Location = new Point(135, 53);
            txtbName.Name = "txtbName";
            txtbName.Size = new Size(200, 21);
            txtbName.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Red;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(12, 470);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(164, 47);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Create Exercise";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // listBox1
            // 
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            listBox1.ForeColor = Color.Red;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 22;
            listBox1.Location = new Point(609, 30);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(436, 440);
            listBox1.TabIndex = 4;
            // 
            // rchtxtbDescription
            // 
            rchtxtbDescription.BorderStyle = BorderStyle.FixedSingle;
            rchtxtbDescription.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            rchtxtbDescription.ForeColor = Color.Red;
            rchtxtbDescription.Location = new Point(135, 101);
            rchtxtbDescription.Name = "rchtxtbDescription";
            rchtxtbDescription.Size = new Size(200, 151);
            rchtxtbDescription.TabIndex = 5;
            rchtxtbDescription.Text = "";
            // 
            // cmbMuscle
            // 
            cmbMuscle.FlatStyle = FlatStyle.Flat;
            cmbMuscle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            cmbMuscle.ForeColor = Color.Red;
            cmbMuscle.FormattingEnabled = true;
            cmbMuscle.Items.AddRange(new object[] { "Chest", "Back", "Bicep", "Tricep", "Legs", "Core" });
            cmbMuscle.Location = new Point(135, 279);
            cmbMuscle.Name = "cmbMuscle";
            cmbMuscle.Size = new Size(200, 30);
            cmbMuscle.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Location = new Point(135, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 1);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.Location = new Point(135, 258);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 1);
            panel2.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.Location = new Point(135, 313);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 1);
            panel3.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(65, 53);
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
            label2.Location = new Point(12, 103);
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
            label3.Location = new Point(51, 282);
            label3.Name = "label3";
            label3.Size = new Size(78, 22);
            label3.TabIndex = 11;
            label3.Text = "Muscle:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(208, 470);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(164, 47);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete Exercise";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // nmudReps
            // 
            nmudReps.BorderStyle = BorderStyle.None;
            nmudReps.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nmudReps.ForeColor = Color.Red;
            nmudReps.Location = new Point(80, 389);
            nmudReps.Name = "nmudReps";
            nmudReps.Size = new Size(144, 24);
            nmudReps.TabIndex = 13;
            // 
            // nmudSets
            // 
            nmudSets.BorderStyle = BorderStyle.None;
            nmudSets.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nmudSets.ForeColor = Color.Red;
            nmudSets.Location = new Point(292, 389);
            nmudSets.Name = "nmudSets";
            nmudSets.Size = new Size(144, 24);
            nmudSets.TabIndex = 14;
            // 
            // nmudWeight
            // 
            nmudWeight.BorderStyle = BorderStyle.None;
            nmudWeight.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            nmudWeight.ForeColor = Color.Red;
            nmudWeight.Location = new Point(203, 432);
            nmudWeight.Name = "nmudWeight";
            nmudWeight.Size = new Size(144, 24);
            nmudWeight.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(12, 389);
            label4.Name = "label4";
            label4.Size = new Size(62, 22);
            label4.TabIndex = 16;
            label4.Text = "Reps:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(230, 389);
            label5.Name = "label5";
            label5.Size = new Size(56, 22);
            label5.TabIndex = 17;
            label5.Text = "Sets:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(113, 431);
            label6.Name = "label6";
            label6.Size = new Size(84, 22);
            label6.TabIndex = 18;
            label6.Text = "Weight: ";
            // 
            // frmTrainerHomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1078, 529);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(nmudWeight);
            Controls.Add(nmudSets);
            Controls.Add(nmudReps);
            Controls.Add(btnDelete);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(cmbMuscle);
            Controls.Add(rchtxtbDescription);
            Controls.Add(listBox1);
            Controls.Add(btnCreate);
            Controls.Add(txtbName);
            Name = "frmTrainerHomePage";
            Text = "Home";
            ((System.ComponentModel.ISupportInitialize)nmudReps).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmudSets).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmudWeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbName;
        private TextBox txtbDescription;
        private TextBox textBox3;
        private Button btnCreate;
        private ListBox listBox1;
        private RichTextBox rchtxtbDescription;
        private ComboBox cmbMuscle;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnDelete;
        private NumericUpDown nmudReps;
        private NumericUpDown nmudSets;
        private NumericUpDown nmudWeight;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}