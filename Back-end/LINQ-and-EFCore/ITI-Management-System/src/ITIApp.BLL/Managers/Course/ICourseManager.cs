using ITIApp.DAL;

namespace ITIApp.BLL
{
    public interface ICourseManager
    {
        Task AddCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
        Task EditCourseAsync(int id, Course course);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseAsync(int id);
        Task<IEnumerable<Department>> GetAllDeptsAsync();
    }
}