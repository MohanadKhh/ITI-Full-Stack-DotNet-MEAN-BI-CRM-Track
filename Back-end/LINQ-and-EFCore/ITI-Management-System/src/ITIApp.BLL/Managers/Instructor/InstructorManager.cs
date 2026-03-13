using ITIApp.DAL;

namespace ITIApp.BLL
{
    public class InstructorManager : IInstructorManager
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorManager(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
            var instructors = await _instructorRepository.GetAllWithRelationsAsync();
            return instructors;
        }

        public async Task<Instructor> GetInstructorAsync(int id)
        {
            var instructor = await _instructorRepository.GetByIdWithRelationsAsync(id);

            if (instructor == null)
                return null;

            return instructor;
        }

        public async Task AddInstructorAsync(Instructor instructor)
        {
            await _instructorRepository.AddAsync(instructor);
        }

        public async Task EditInstructorAsync(int id, Instructor instructor)
        {
            await _instructorRepository.UpdateAsync(id, instructor);
        }

        public async Task DeleteInstructorAsync(int id)
        {
            var instructor = await _instructorRepository.GetByIdWithRelationsAsync(id);
            if (instructor == null)
                return;

            await _instructorRepository.DeleteAsync(id);
        }
    }
}
