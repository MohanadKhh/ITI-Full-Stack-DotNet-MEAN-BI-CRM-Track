using ITIApp.DAL;

namespace ITIApp.BLL
{
    public class CourseManager : ICourseManager
    {
        private ICourseRepository _courseRepository;
        private IGenericRepository<Department> _genericRepository;
        public CourseManager(ICourseRepository courseRepository, IGenericRepository<Department> genericRepository)
        {
            _courseRepository = courseRepository;
            _genericRepository = genericRepository;
        }
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllWithRelationsAsync();
            return courses;
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdWithRelationsAsync(id);

            if (course == null)
                return null;

            return course;
        }

        public async Task<IEnumerable<Department>> GetAllDeptsAsync()
        {
            var departments = await _genericRepository.GetAllAsync();
            return departments;
        }

        public async Task AddCourseAsync(Course course)
        {
            await _courseRepository.AddAsync(course);
        }

        public async Task EditCourseAsync(int id, Course course)
        {
            course.Id = id;
            await _courseRepository.UpdateAsync(id, course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _courseRepository.DeleteCourseAsync(id);
        }
    }
}