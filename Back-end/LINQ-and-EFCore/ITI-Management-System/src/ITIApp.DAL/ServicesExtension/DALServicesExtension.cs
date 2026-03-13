using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ITIApp.DAL
{
    public static class DALServicesExtension
    {
        public static void AddDALServices(this IServiceCollection services)
        {
            // DAL — DbContextFactory instead of DbContext (fixes concurrency issue)
            services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlServer(
                    "Server=.\\SQLEXPRESS;DataBase=SchoolApp;Trusted_Connection=true;TrustServerCertificate=true"
                ));

            // DAL — Repositories
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IGenericRepository<Department>, GenericRepository<Department>>();
        }
    }
}
