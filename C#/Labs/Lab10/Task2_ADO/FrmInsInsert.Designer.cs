namespace Task2_ADO
{
    partial class FrmInsInsert
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
            lblResult = new Label();
            comboBoxDept = new ComboBox();
            btnInsert = new Button();
            lblDept = new Label();
            lblDegree = new Label();
            lblSalary = new Label();
            lblName = new Label();
            txtBoxSalary = new TextBox();
            txtBoxName = new TextBox();
            txtBoxDegree = new TextBox();
            lbl_Id = new Label();
            txtBoxId = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(370, 405);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 20);
            lblResult.TabIndex = 22;
            // 
            // comboBoxDept
            // 
            comboBoxDept.FormattingEnabled = true;
            comboBoxDept.Location = new Point(580, 259);
            comboBoxDept.Name = "comboBoxDept";
            comboBoxDept.Size = new Size(176, 28);
            comboBoxDept.TabIndex = 21;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.Teal;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(333, 346);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(123, 42);
            btnInsert.TabIndex = 20;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(451, 262);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(100, 20);
            lblDept.TabIndex = 19;
            lblDept.Text = "Departement:";
            // 
            // lblDegree
            // 
            lblDegree.AutoSize = true;
            lblDegree.Location = new Point(47, 262);
            lblDegree.Name = "lblDegree";
            lblDegree.Size = new Size(61, 20);
            lblDegree.TabIndex = 18;
            lblDegree.Text = "Degree:";
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Location = new Point(451, 175);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(52, 20);
            lblSalary.TabIndex = 17;
            lblSalary.Text = "Salary:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(47, 175);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 16;
            lblName.Text = "Name:";
            // 
            // txtBoxSalary
            // 
            txtBoxSalary.Location = new Point(580, 172);
            txtBoxSalary.Name = "txtBoxSalary";
            txtBoxSalary.Size = new Size(176, 27);
            txtBoxSalary.TabIndex = 15;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(160, 172);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(175, 27);
            txtBoxName.TabIndex = 14;
            // 
            // txtBoxDegree
            // 
            txtBoxDegree.Location = new Point(160, 259);
            txtBoxDegree.Name = "txtBoxDegree";
            txtBoxDegree.Size = new Size(175, 27);
            txtBoxDegree.TabIndex = 13;
            // 
            // lbl_Id
            // 
            lbl_Id.AutoSize = true;
            lbl_Id.Location = new Point(257, 109);
            lbl_Id.Name = "lbl_Id";
            lbl_Id.Size = new Size(27, 20);
            lbl_Id.TabIndex = 24;
            lbl_Id.Text = "ID:";
            // 
            // txtBoxId
            // 
            txtBoxId.Location = new Point(370, 106);
            txtBoxId.Name = "txtBoxId";
            txtBoxId.Size = new Size(175, 27);
            txtBoxId.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(268, 26);
            label1.Name = "label1";
            label1.Size = new Size(261, 32);
            label1.TabIndex = 25;
            label1.Text = "Add a new Instructor";
            // 
            // FrmInsInsert
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(lbl_Id);
            Controls.Add(txtBoxId);
            Controls.Add(lblResult);
            Controls.Add(comboBoxDept);
            Controls.Add(btnInsert);
            Controls.Add(lblDept);
            Controls.Add(lblDegree);
            Controls.Add(lblSalary);
            Controls.Add(lblName);
            Controls.Add(txtBoxSalary);
            Controls.Add(txtBoxName);
            Controls.Add(txtBoxDegree);
            Name = "FrmInsInsert";
            Text = "FrmInsInsert";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblResult;
        private ComboBox comboBoxDept;
        private Button btnInsert;
        private Label lblDept;
        private Label lblDegree;
        private Label lblSalary;
        private Label lblName;
        private TextBox txtBoxSalary;
        private TextBox txtBoxName;
        private TextBox txtBoxDegree;
        private Label lbl_Id;
        private TextBox txtBoxId;
        private Label label1;
    }
}