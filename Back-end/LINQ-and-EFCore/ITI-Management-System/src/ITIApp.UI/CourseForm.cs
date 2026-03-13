using ITIApp.BLL;
using ITIApp.DAL;

namespace SchoolApp.UI.Forms
{
    public partial class CourseForm : Form
    {
        private readonly ICourseManager _courseManager;
        private readonly IInstructorManager _instructorManager;
        private Course? _selected;
        private bool _isLoading = false;

        public CourseForm(ICourseManager courseManager, IInstructorManager instructorManager)
        {
            _courseManager = courseManager;
            _instructorManager = instructorManager;
            InitializeComponent();
            LoadDropdownsAsync();
            LoadGridAsync();
        }

        // ── Data ──────────────────────────────────────────────────
        private async Task LoadGridAsync(string filter = "")
        {
            dgv.SelectionChanged -= dgv_SelectionChangedAsync;

            var data = await _courseManager.GetAllCoursesAsync();
            dgv.DataSource = data.Select(c => new
            {
                c.Id,
                c.Name,
                Duration = $"{c.Duration} hrs",
                Department = c.Department?.Name ?? "-",
                Instructor = c.Instructor?.FullName ?? "-"
            }).ToList();

            dgv.Columns["Id"].Visible = false;

            SetStatus($"{dgv.RowCount} course(s) found.");

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

            var instructors = await _instructorManager.GetAllInstructorsAsync();
            var instrList = instructors.ToList();
            instrList.Insert(0, new Instructor { Id = 0, FirstName = "-- Select", LastName = "Instructor --" });

            cbInstructor.DataSource = instrList;
            cbInstructor.DisplayMember = "FullName";
            cbInstructor.ValueMember = "Id";
            cbInstructor.SelectedIndex = 0;
        }

        private void PopulateFields(Course c)
        {
            txtName.Text = c.Name ?? "";
            nudDuration.Value = c.Duration;
            cbDepartment.SelectedValue = c.DepartmentId;
            cbInstructor.SelectedValue = c.InstructorId;
        }

        private void ClearFields()
        {
            dgv.SelectionChanged -= dgv_SelectionChangedAsync;

            _selected = null;
            txtName.Text = "";
            nudDuration.Value = 1;
            cbDepartment.SelectedIndex = 0;
            cbInstructor.SelectedIndex = 0;
            dgv.ClearSelection();
            SetStatus("Ready.");

            dgv.SelectionChanged += dgv_SelectionChangedAsync;
        }

        private void SetStatus(string msg) => lblStatus.Text = "  " + msg;

        // ── Events ────────────────────────────────────────────────
        // In CourseForm.cs — add this field
        private async void dgv_SelectionChangedAsync(object sender, EventArgs e)
        {
            // ✅ block if already loading or no row selected
            if (_isLoading) return;
            if (dgv.CurrentRow?.DataBoundItem == null) return;

            int id = (int)dgv.CurrentRow.Cells["Id"].Value;

            try
            {
                _isLoading = true;
                _selected = await _courseManager.GetCourseAsync(id);
                if (_selected != null) PopulateFields(_selected);
            }
            catch (Exception ex) { ShowError(ex.Message); }
            finally
            {
                _isLoading = false; // ✅ always release — even on error
            }
        }

        private async void txtSearch_TextChangedAsync(object sender, EventArgs e)
            => await LoadGridAsync(txtSearch.Text);

        private async void btnAdd_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                await _courseManager.AddCourseAsync(BuildFromFields());
                await LoadGridAsync();
                ClearFields();
                SetStatus("✅  Course added successfully.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private async void btnUpdate_ClickAsync(object sender, EventArgs e)
        {
            if (_selected is null) { ShowError("Select a course first."); return; }
            try
            {
                //var updated = BuildFromFields();
                //updated.Id  = _selected.Id;
                await _courseManager.EditCourseAsync(_selected.Id, BuildFromFields());
                await LoadGridAsync();
                ClearFields();
                SetStatus("✅  Course updated successfully.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private async void btnDelete_ClickAsync(object sender, EventArgs e)
        {
            if (_selected is null) { ShowError("Select a course first."); return; }
            if (Confirm($"Delete course '{_selected.Name}'?") != DialogResult.Yes) return;
            try
            {
                await _courseManager.DeleteCourseAsync(_selected.Id);
                await LoadGridAsync();
                ClearFields();
                SetStatus("🗑️  Course deleted.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        // ── Helpers ───────────────────────────────────────────────
        private Course BuildFromFields()
        {
            if (cbDepartment.SelectedIndex == 0)
                throw new ArgumentException("Please select a department.");

            if (cbInstructor.SelectedIndex == 0)
                throw new ArgumentException("Please select an instructor.");

            return new Course
            {
                Name = txtName.Text.Trim(),
                Duration = (int)nudDuration.Value,
                DepartmentId = (int)cbDepartment.SelectedValue!,
                InstructorId = (int)cbInstructor.SelectedValue!
            };
        }

        private void ShowError(string msg)
            => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private DialogResult Confirm(string msg)
            => MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        private void btnBack_Click(object sender, EventArgs e) => this.Close();
    }
}
