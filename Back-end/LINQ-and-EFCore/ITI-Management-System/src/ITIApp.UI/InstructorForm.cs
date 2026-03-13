using ITIApp.BLL;
using ITIApp.DAL;

namespace SchoolApp.UI.Forms
{
    public partial class InstructorForm : Form
    {
        private readonly IInstructorManager _instructorManager;
        private readonly ICourseManager _courseManager;
        private Instructor? _selected;

        public InstructorForm(IInstructorManager instructorManager, ICourseManager courseManager)
        {
            _instructorManager = instructorManager;
            _courseManager = courseManager;
            InitializeComponent();
            LoadDropdownsAsync();
            LoadGridAsync();
        }

        // ── Data ──────────────────────────────────────────────────
        private async Task LoadGridAsync(string filter = "")
        {
            dgv.SelectionChanged -= dgv_SelectionChangedAsync;

            var data = await _instructorManager.GetAllInstructorsAsync();
            if (!string.IsNullOrWhiteSpace(filter))
                data = data.Where(i =>
                    (i.FirstName + " " + i.LastName)
                    .Contains(filter, StringComparison.OrdinalIgnoreCase));

            dgv.DataSource = data.Select(i => new
            {
                i.Id,
                i.FirstName,
                i.LastName,
                i.Phone,
                Department = i.Department?.Name ?? "-"
            }).ToList();

            dgv.Columns["Id"].Visible = false;
            
            SetStatus($"{dgv.RowCount} instructor(s) found.");

            dgv.SelectionChanged += dgv_SelectionChangedAsync;
        }

        private async Task LoadDropdownsAsync()
        {
            var departments = await _courseManager.GetAllDeptsAsync();

            var deptList = departments.ToList();
            deptList.Insert(0, new Department { Id = 0, Name = "-- Select Department --" });

            cbDepartment.DataSource = deptList;
            cbDepartment.DisplayMember = "Name";
            cbDepartment.ValueMember = "Id";
            cbDepartment.SelectedIndex = 0;
        }

        private void PopulateFields(Instructor i)
        {
            dgv.SelectionChanged -= dgv_SelectionChangedAsync;

            txtFirstName.Text = i.FirstName ?? "";
            txtLastName.Text = i.LastName ?? "";
            txtPhone.Text = i.Phone ?? "";
            cbDepartment.SelectedValue = i.DeptId;

            dgv.SelectionChanged -= dgv_SelectionChangedAsync;
        }

        private void ClearFields()
        {
            dgv.SelectionChanged -= dgv_SelectionChangedAsync;

            _selected = null;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            cbDepartment.SelectedIndex = -1;
            dgv.ClearSelection();
            SetStatus("Ready.");

            dgv.SelectionChanged += dgv_SelectionChangedAsync;
        }

        private void SetStatus(string msg) => lblStatus.Text = "  " + msg;

        // ── Events ────────────────────────────────────────────────
        private async void dgv_SelectionChangedAsync(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem == null) return;
            int id = (int)dgv.CurrentRow.Cells["Id"].Value;
            _selected = await _instructorManager.GetInstructorAsync(id);
            if (_selected != null) PopulateFields(_selected);
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
            => await LoadGridAsync(txtSearch.Text);

        private async void btnAdd_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                await _instructorManager.AddInstructorAsync(BuildFromFields());
                await LoadGridAsync();
                ClearFields();
                SetStatus("✅  Instructor added successfully.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private async void btnUpdate_ClickAsync(object sender, EventArgs e)
        {
            if (_selected is null) { ShowError("Select an instructor first."); return; }
            try
            {
                var updated = BuildFromFields();
                updated.Id = _selected.Id;
                await _instructorManager.EditInstructorAsync(_selected.Id, updated);
                await LoadGridAsync();
                ClearFields();
                SetStatus("✅  Instructor updated successfully.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private async void btnDelete_ClickAsync(object sender, EventArgs e)
        {
            if (_selected is null) { ShowError("Select an instructor first."); return; }
            if (Confirm($"Delete '{_selected.FirstName} {_selected.LastName}'?") != DialogResult.Yes) return;
            try
            {
                await _instructorManager.DeleteInstructorAsync(_selected.Id);
                await LoadGridAsync();
                ClearFields();
                SetStatus("🗑️  Instructor deleted.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        // ── Helpers ───────────────────────────────────────────────
        private Instructor BuildFromFields()
        {
            if (cbDepartment.SelectedIndex == 0)
                throw new ArgumentException("Please select a department.");

            return new Instructor
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                DeptId = (int)cbDepartment.SelectedValue!
            };
        }

        private void ShowError(string msg)
            => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private DialogResult Confirm(string msg)
            => MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        private void btnBack_Click(object sender, EventArgs e) => this.Close();
    }
}
