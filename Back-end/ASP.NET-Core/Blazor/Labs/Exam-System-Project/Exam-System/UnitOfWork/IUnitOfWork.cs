using Exam_System.Data.Repositories;
using Exam_System.Data.Repositories.General;

namespace Exam_System.UnitOfWork
{
    public interface IUnitOfWork
    {
        ISubjectRepository Subjects { get; }
        IExamRepository Exams { get; }
        IQuestionRepository Questions { get; }
        IChoiceRepository Choices { get; }
        IExamAttemptRepository ExamAttempts { get; }
        IExamAnswerRepository ExamAnswers { get; }

        Task<int> SaveChangesAsync();
    }
}
