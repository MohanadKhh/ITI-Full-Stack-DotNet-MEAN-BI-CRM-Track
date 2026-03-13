using Microsoft.EntityFrameworkCore;

namespace ITIApp.DAL
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(IDbContextFactory<AppDbContext> factory) : base(factory) { }
        public async Task<IEnumerable<Instructor>> GetAllWithRelationsAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Instructors
                .Include(i => i.Courses)
                .Include(i => i.CourseSessions)
                .Include(i => i.Department)
                .Include(i => i.ManagedDepartment)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Instructor?> GetByIdWithRelationsAsync(int id)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Instructors
                .Include(i => i.Courses)
                .Include(i => i.CourseSessions)
                .Include(i => i.Department)
                .Include(i => i.ManagedDepartment)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
