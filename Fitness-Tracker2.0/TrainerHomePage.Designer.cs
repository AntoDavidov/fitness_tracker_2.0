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
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
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
            btnCreate.Location = new Point(23, 359);
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
            btnDelete.Location = new Point(23, 412);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(164, 47);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete Exercise";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(440, 71);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(111, 27);
            numericUpDown1.TabIndex = 13;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(431, 128);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(111, 27);
            numericUpDown2.TabIndex = 14;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(431, 184);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(111, 27);
            numericUpDown3.TabIndex = 15;
            // 
            // frmTrainerHomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1078, 529);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
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
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
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
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
    }
}