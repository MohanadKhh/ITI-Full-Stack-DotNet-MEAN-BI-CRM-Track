namespace Task2_ADO
{
    partial class FrmInsUpdate
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
            txtBoxDegree = new TextBox();
            txtBoxName = new TextBox();
            txtBoxSalary = new TextBox();
            lblName = new Label();
            lblSalary = new Label();
            lblDegree = new Label();
            lblDept = new Label();
            comboBoxInstructors = new ComboBox();
            lbl_Ins = new Label();
            btnUpdate = new Button();
            comboBoxDept = new ComboBox();
            lblResult = new Label();
            label1 = new Label();
            lblRseultDel = new Label();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // txtBoxDegree
            // 
            txtBoxDegree.Location = new Point(150, 275);
            txtBoxDegree.Name = "txtBoxDegree";
            txtBoxDegree.Size = new Size(175, 27);
            txtBoxDegree.TabIndex = 1;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(150, 188);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(175, 27);
            txtBoxName.TabIndex = 2;
            // 
            // txtBoxSalary
            // 
            txtBoxSalary.Location = new Point(570, 188);
            txtBoxSalary.Name = "txtBoxSalary";
            txtBoxSalary.Size = new Size(176, 27);
            txtBoxSalary.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(37, 191);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 4;
            lblName.Text = "Name:";
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Location = new Point(441, 191);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(52, 20);
            lblSalary.TabIndex = 5;
            lblSalary.Text = "Salary:";
            // 
            // lblDegree
            // 
            lblDegree.AutoSize = true;
            lblDegree.Location = new Point(37, 278);
            lblDegree.Name = "lblDegree";
            lblDegree.Size = new Size(61, 20);
            lblDegree.TabIndex = 6;
            lblDegree.Text = "Degree:";
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(441, 278);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(100, 20);
            lblDept.TabIndex = 7;
            lblDept.Text = "Departement:";
            // 
            // comboBoxInstructors
            // 
            comboBoxInstructors.FormattingEnabled = true;
            comboBoxInstructors.Location = new Point(342, 120);
            comboBoxInstructors.Name = "comboBoxInstructors";
            comboBoxInstructors.Size = new Size(151, 28);
            comboBoxInstructors.TabIndex = 8;
            comboBoxInstructors.SelectedIndexChanged += comboBoxInstructors_SelectedIndexChanged;
            // 
            // lbl_Ins
            // 
            lbl_Ins.AutoSize = true;
            lbl_Ins.Location = new Point(235, 123);
            lbl_Ins.Name = "lbl_Ins";
            lbl_Ins.Size = new Size(80, 20);
            lbl_Ins.TabIndex = 9;
            lbl_Ins.Text = "Instructors:";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Teal;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(150, 360);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(123, 42);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // comboBoxDept
            // 
            comboBoxDept.FormattingEnabled = true;
            comboBoxDept.Location = new Point(570, 275);
            comboBoxDept.Name = "comboBoxDept";
            comboBoxDept.Size = new Size(176, 28);
            comboBoxDept.TabIndex = 11;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(187, 419);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 20);
            lblResult.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(286, 29);
            label1.Name = "label1";
            label1.Size = new Size(218, 32);
            label1.TabIndex = 26;
            label1.Text = "Edit an Instructor";
            // 
            // lblRseultDel
            // 
            lblRseultDel.AutoSize = true;
            lblRseultDel.Location = new Point(478, 419);
            lblRseultDel.Name = "lblRseultDel";
            lblRseultDel.Size = new Size(0, 20);
            lblRseultDel.TabIndex = 28;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(441, 360);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(123, 42);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // FrmInsUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblRseultDel);
            Controls.Add(btnDelete);
            Controls.Add(label1);
            Controls.Add(lblResult);
            Controls.Add(comboBoxDept);
            Controls.Add(btnUpdate);
            Controls.Add(lbl_Ins);
            Controls.Add(comboBoxInstructors);
            Controls.Add(lblDept);
            Controls.Add(lblDegree);
            Controls.Add(lblSalary);
            Controls.Add(lblName);
            Controls.Add(txtBoxSalary);
            Controls.Add(txtBoxName);
            Controls.Add(txtBoxDegree);
            Name = "FrmInsUpdate";
            Text = "Update Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtBoxDegree;
        private TextBox txtBoxName;
        private TextBox txtBoxSalary;
        private Label lblName;
        private Label lblSalary;
        private Label lblDegree;
        private Label lblDept;
        private ComboBox comboBoxInstructors;
        private Label lbl_Ins;
        private Button btnUpdate;
        private ComboBox comboBoxDept;
        private Label lblResult;
        private Label label1;
        private Label lblRseultDel;
        private Button btnDelete;
    }
}