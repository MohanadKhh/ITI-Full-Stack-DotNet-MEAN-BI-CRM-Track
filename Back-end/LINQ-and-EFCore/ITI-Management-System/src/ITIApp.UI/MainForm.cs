using Microsoft.Extensions.DependencyInjection;

namespace SchoolApp.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _provider;

        public MainForm(IServiceProvider provider)
        {
            _provider = provider;
            InitializeComponent();
        }

        private void btnInstructors_Click(object sender, EventArgs e)
            => _provider.GetRequiredService<InstructorForm>().ShowDialog(); // ✅ DI handles everything

        private void btnCourses_Click(object sender, EventArgs e)
            => _provider.GetRequiredService<CourseForm>().ShowDialog();     // ✅ DI handles everything

        private void btnExit_Click(object sender, EventArgs e)
            => Application.Exit();
    }
}
