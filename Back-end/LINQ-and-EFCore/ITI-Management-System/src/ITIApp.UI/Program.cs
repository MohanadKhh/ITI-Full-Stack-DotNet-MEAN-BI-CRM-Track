using ITIApp.BLL;
using ITIApp.DAL;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.UI.Forms;

namespace ITIApp.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // ── 1. Register Services ──────────────────────────────
            var services = new ServiceCollection();

            // DAL — Repo and connection string
            services.AddDALServices();

            // BLL — Managers
            services.AddScoped<ICourseManager, CourseManager>();
            services.AddScoped<IInstructorManager, InstructorManager>();

            // UI — Forms
            services.AddTransient<MainForm>();
            services.AddTransient<CourseForm>();
            services.AddTransient<InstructorForm>();

            // ── 2. Build Provider ─────────────────────────────────
            var provider = services.BuildServiceProvider();
            Application.Run(provider.GetRequiredService<MainForm>());
        }
    }
}