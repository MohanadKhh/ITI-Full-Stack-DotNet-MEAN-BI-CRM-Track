using Exam_System.Data;
using Exam_System.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Exam_System.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _transaction;

        private ISubjectRepository? _subjectRepository;
        private IExamRepository? _examRepository;
        private IQuestionRepository? _questionRepository;
        private IChoiceRepository? _choiceRepository;
        private IExamAttemptRepository? _examAttemptRepository;
        private IExamAnswerRepository? _examAnswerRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ISubjectRepository Subjects
        {
            get { return _subjectRepository ??= new SubjectRepository(_context); }
        }

        public IExamRepository Exams
        {
            get { return _examRepository ??= new ExamRepository(_context); }
        }

        public IQuestionRepository Questions
        {
            get { return _questionRepository ??= new QuestionRepository(_context); }
        }

        public IChoiceRepository Choices
        {
            get { return _choiceRepository ??= new ChoiceRepository(_context); }
        }

        public IExamAttemptRepository ExamAttempts
        {
            get { return _examAttemptRepository ??= new ExamAttemptRepository(_context); }
        }

        public IExamAnswerRepository ExamAnswers
        {
            get { return _examAnswerRepository ??= new ExamAnswerRepository(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
