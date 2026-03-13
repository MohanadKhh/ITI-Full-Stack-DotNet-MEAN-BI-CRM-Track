namespace SchoolApp.UI.Forms
{
    partial class InstructorForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlForm = new Panel();
            btnBack = new Button();
            lblFormTitle = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblPhone = new Label();
            lblDepartment = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            cbDepartment = new ComboBox();
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
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 58, 138);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1392, 64);
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
            lblTitle.Size = new Size(1392, 64);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👨‍🏫   Instructor Management";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlForm
            // 
            pnlForm.BackColor = Color.White;
            pnlForm.Controls.Add(btnBack);
            pnlForm.Controls.Add(lblFormTitle);
            pnlForm.Controls.Add(lblFirstName);
            pnlForm.Controls.Add(lblLastName);
            pnlForm.Controls.Add(lblPhone);
            pnlForm.Controls.Add(lblDepartment);
            pnlForm.Controls.Add(txtFirstName);
            pnlForm.Controls.Add(txtLastName);
            pnlForm.Controls.Add(txtPhone);
            pnlForm.Controls.Add(cbDepartment);
            pnlForm.Controls.Add(btnAdd);
            pnlForm.Controls.Add(btnUpdate);
            pnlForm.Controls.Add(btnDelete);
            pnlForm.Controls.Add(btnClear);
            pnlForm.Location = new Point(16, 80);
            pnlForm.Name = "pnlForm";
            pnlForm.Size = new Size(280, 624);
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
            btnBack.Location = new Point(16, 571);
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
            lblFormTitle.ForeColor = Color.FromArgb(30, 58, 138);
            lblFormTitle.Location = new Point(16, 16);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(165, 25);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Instructor Details";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(71, 85, 105);
            lblFirstName.Location = new Point(16, 66);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(86, 20);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(71, 85, 105);
            lblLastName.Location = new Point(16, 136);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(84, 20);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(71, 85, 105);
            lblPhone.Location = new Point(16, 206);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(53, 20);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Phone";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDepartment.ForeColor = Color.FromArgb(71, 85, 105);
            lblDepartment.Location = new Point(16, 276);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(94, 20);
            lblDepartment.TabIndex = 4;
            lblDepartment.Text = "Department";
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.FromArgb(248, 250, 252);
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(16, 90);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(240, 30);
            txtFirstName.TabIndex = 5;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.FromArgb(248, 250, 252);
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(16, 160);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(240, 30);
            txtLastName.TabIndex = 6;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(248, 250, 252);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(16, 230);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(240, 30);
            txtPhone.TabIndex = 7;
            // 
            // cbDepartment
            // 
            cbDepartment.BackColor = Color.FromArgb(248, 250, 252);
            cbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDepartment.FlatStyle = FlatStyle.Flat;
            cbDepartment.Font = new Font("Segoe UI", 10F);
            cbDepartment.Location = new Point(16, 300);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Size = new Size(240, 31);
            cbDepartment.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(30, 58, 138);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(16, 421);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(240, 38);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "➕  Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_ClickAsync;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(5, 122, 85);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(16, 471);
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
            pnlGrid.Size = new Size(1068, 624);
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
            txtSearch.PlaceholderText = "Search by name...";
            txtSearch.Size = new Size(380, 30);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            dgv.Size = new Size(1037, 549);
            dgv.TabIndex = 2;
            dgv.SelectionChanged += dgv_SelectionChangedAsync;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.FromArgb(30, 58, 138);
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(147, 197, 253);
            lblStatus.Location = new Point(0, 719);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1392, 28);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "  Ready.";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // InstructorForm
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1392, 747);
            Controls.Add(pnlHeader);
            Controls.Add(pnlForm);
            Controls.Add(pnlGrid);
            Controls.Add(lblStatus);
            MinimumSize = new Size(960, 620);
            Name = "InstructorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Instructor Management";
            pnlHeader.ResumeLayout(false);
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
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
        private Panel        pnlHeader;
        private Label        lblTitle;

        private Panel        pnlForm;
        private Label        lblFormTitle;
        private Label        lblFirstName;
        private Label        lblLastName;
        private Label        lblPhone;
        private Label        lblDepartment;
        private TextBox      txtFirstName;
        private TextBox      txtLastName;
        private TextBox      txtPhone;
        private ComboBox     cbDepartment;
        private Button       btnAdd;
        private Button       btnUpdate;
        private Button       btnDelete;
        private Button       btnClear;

        private Panel        pnlGrid;
        private Label        lblSearchIcon;
        private TextBox      txtSearch;
        private DataGridView dgv;

        private Label        lblStatus;
        private Button btnBack;
    }
}
