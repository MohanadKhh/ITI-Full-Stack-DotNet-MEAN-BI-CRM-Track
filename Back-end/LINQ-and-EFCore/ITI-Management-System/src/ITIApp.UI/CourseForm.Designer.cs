namespace SchoolApp.UI.Forms
{
    partial class CourseForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlForm = new Panel();
            btnBack = new Button();
            lblFormTitle = new Label();
            lblName = new Label();
            lblDuration = new Label();
            lblDepartment = new Label();
            lblInstructor = new Label();
            txtName = new TextBox();
            nudDuration = new NumericUpDown();
            cbDepartment = new ComboBox();
            cbInstructor = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            pnlGrid = new Panel();
            lblSearchIcon = new Label();
            txtSearch = new TextBox();
            dgv = new DataGridView();
            lblStatus = new Label();
            pnlHeader.SuspendLayout();
            pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(5, 122, 85);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1395, 64);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(20, 0, 0, 0);
            lblTitle.Size = new Size(1395, 64);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📚   Course Management";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlForm
            // 
            pnlForm.BackColor = Color.White;
            pnlForm.Controls.Add(btnBack);
            pnlForm.Controls.Add(lblFormTitle);
            pnlForm.Controls.Add(lblName);
            pnlForm.Controls.Add(lblDuration);
            pnlForm.Controls.Add(lblDepartment);
            pnlForm.Controls.Add(lblInstructor);
            pnlForm.Controls.Add(txtName);
            pnlForm.Controls.Add(nudDuration);
            pnlForm.Controls.Add(cbDepartment);
            pnlForm.Controls.Add(cbInstructor);
            pnlForm.Controls.Add(btnAdd);
            pnlForm.Controls.Add(btnUpdate);
            pnlForm.Controls.Add(btnDelete);
            pnlForm.Controls.Add(btnClear);
            pnlForm.Location = new Point(16, 80);
            pnlForm.Name = "pnlForm";
            pnlForm.Size = new Size(280, 625);
            pnlForm.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(100, 116, 139);
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(16, 572);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(240, 36);
            btnBack.TabIndex = 0;
            btnBack.Text = "⬅  Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(5, 122, 85);
            lblFormTitle.Location = new Point(16, 16);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(138, 25);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Course Details";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(71, 85, 105);
            lblName.Location = new Point(16, 66);
            lblName.Name = "lblName";
            lblName.Size = new Size(103, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Course Name";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDuration.ForeColor = Color.FromArgb(71, 85, 105);
            lblDuration.Location = new Point(16, 135);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(109, 20);
            lblDuration.TabIndex = 2;
            lblDuration.Text = "Duration (hrs)";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDepartment.ForeColor = Color.FromArgb(71, 85, 105);
            lblDepartment.Location = new Point(16, 205);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(94, 20);
            lblDepartment.TabIndex = 3;
            lblDepartment.Text = "Department";
            // 
            // lblInstructor
            // 
            lblInstructor.AutoSize = true;
            lblInstructor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInstructor.ForeColor = Color.FromArgb(71, 85, 105);
            lblInstructor.Location = new Point(16, 275);
            lblInstructor.Name = "lblInstructor";
            lblInstructor.Size = new Size(79, 20);
            lblInstructor.TabIndex = 4;
            lblInstructor.Text = "Instructor";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(248, 250, 252);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(16, 90);
            txtName.Name = "txtName";
            txtName.Size = new Size(240, 30);
            txtName.TabIndex = 5;
            // 
            // nudDuration
            // 
            nudDuration.BackColor = Color.FromArgb(248, 250, 252);
            nudDuration.BorderStyle = BorderStyle.FixedSingle;
            nudDuration.Font = new Font("Segoe UI", 10F);
            nudDuration.Location = new Point(16, 159);
            nudDuration.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDuration.Name = "nudDuration";
            nudDuration.Size = new Size(240, 30);
            nudDuration.TabIndex = 6;
            nudDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // cbDepartment
            // 
            cbDepartment.BackColor = Color.FromArgb(248, 250, 252);
            cbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDepartment.FlatStyle = FlatStyle.Flat;
            cbDepartment.Font = new Font("Segoe UI", 10F);
            cbDepartment.Location = new Point(16, 229);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Size = new Size(240, 31);
            cbDepartment.TabIndex = 7;
            // 
            // cbInstructor
            // 
            cbInstructor.BackColor = Color.FromArgb(248, 250, 252);
            cbInstructor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbInstructor.FlatStyle = FlatStyle.Flat;
            cbInstructor.Font = new Font("Segoe UI", 10F);
            cbInstructor.Location = new Point(16, 299);
            cbInstructor.Name = "cbInstructor";
            cbInstructor.Size = new Size(240, 31);
            cbInstructor.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(5, 122, 85);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(16, 425);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(240, 38);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "➕  Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_ClickAsync;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(30, 58, 138);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(16, 473);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(240, 38);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "✏️  Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_ClickAsync;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(185, 28, 28);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(16, 521);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 38);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "🗑️  Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_ClickAsync;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(100, 116, 139);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(141, 521);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(115, 38);
            btnClear.TabIndex = 12;
            btnClear.Text = "✖  Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.White;
            pnlGrid.Controls.Add(lblSearchIcon);
            pnlGrid.Controls.Add(txtSearch);
            pnlGrid.Controls.Add(dgv);
            pnlGrid.Location = new Point(312, 80);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(1070, 625);
            pnlGrid.TabIndex = 2;
            // 
            // lblSearchIcon
            // 
            lblSearchIcon.AutoSize = true;
            lblSearchIcon.Font = new Font("Segoe UI", 11F);
            lblSearchIcon.Location = new Point(16, 19);
            lblSearchIcon.Name = "lblSearchIcon";
            lblSearchIcon.Size = new Size(33, 25);
            lblSearchIcon.TabIndex = 0;
            lblSearchIcon.Text = "🔍";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(248, 250, 252);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(55, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by course name...";
            txtSearch.Size = new Size(392, 30);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChangedAsync;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeight = 40;
            dgv.Font = new Font("Segoe UI", 9.5F);
            dgv.Location = new Point(16, 60);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 51;
            dgv.RowTemplate.Height = 36;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1035, 550);
            dgv.TabIndex = 2;
            dgv.SelectionChanged += dgv_SelectionChangedAsync;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.FromArgb(5, 122, 85);
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(167, 243, 208);
            lblStatus.Location = new Point(0, 718);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1395, 28);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "  Ready.";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CourseForm
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1395, 746);
            Controls.Add(pnlHeader);
            Controls.Add(pnlForm);
            Controls.Add(pnlGrid);
            Controls.Add(lblStatus);
            MinimumSize = new Size(960, 640);
            Name = "CourseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Course Management";
            pnlHeader.ResumeLayout(false);
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        private static void StylePanel(Panel p, Color accent)
        {
            p.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(226, 232, 240)), 0, 0, p.Width - 1, p.Height - 1);
                e.Graphics.FillRectangle(new SolidBrush(accent), 0, 0, p.Width, 4);
            };
        }

        // ── Control Declarations ──────────────────────────────────
        private Panel          pnlHeader;
        private Label          lblTitle;

        private Panel          pnlForm;
        private Label          lblFormTitle;
        private Label          lblName;
        private Label          lblDuration;
        private Label          lblDepartment;
        private Label          lblInstructor;
        private TextBox        txtName;
        private NumericUpDown  nudDuration;
        private ComboBox       cbDepartment;
        private ComboBox       cbInstructor;
        private Button         btnAdd;
        private Button         btnUpdate;
        private Button         btnDelete;
        private Button         btnClear;

        private Panel          pnlGrid;
        private Label          lblSearchIcon;
        private TextBox        txtSearch;
        private DataGridView   dgv;

        private Label          lblStatus;
        private Button btnBack;
    }
}
