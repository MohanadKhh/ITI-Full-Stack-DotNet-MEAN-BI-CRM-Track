using Microsoft.EntityFrameworkCore;

namespace ITIApp.DAL
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(IDbContextFactory<AppDbContext> factory) : base(factory) { }

        public async Task<IEnumerable<Course>> GetAllWithRelationsAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Courses
                .Include(c => c.StCourses)
                .Include(c => c.CourseSessions)
                .Include(c => c.Instructor)
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Course?> GetByIdWithRelationsAsync(int id)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Courses
                .Include(c => c.StCourses)
                .Include(c => c.CourseSessions)
                .Include(c => c.Instructor)
                .Include(c => c.Department)
                .FirstAsync(c => c.Id == id);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await using var context = await _factory.CreateDbContextAsync();

            var course = await context.Courses
                .Include(c => c.StCourses)
                .Include(c => c.CourseSessions)
                .Include(c => c.Instructor)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
                return;

            course.IsDeleted = true;
            foreach (var stCourse in course.StCourses!)
            {
                stCourse.IsDeleted = true;
            }

            foreach (var crsSession in course.CourseSessions!)
            {
                crsSession.IsDeleted = true;
            }

            await context.SaveChangesAsync();
        }
    }
}