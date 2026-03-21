using Exam_System.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_System.Data.Configurations
{
    public class ExamAnswerConfiguration : IEntityTypeConfiguration<ExamAnswer>
    {
        public void Configure(EntityTypeBuilder<ExamAnswer> entity)
        {
            entity.HasOne(x => x.ExamAttempt)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.ExamAttemptId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(x => x.Question)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.SelectedChoice)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.SelectedChoiceId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasIndex(x => new { x.ExamAttemptId, x.QuestionId }).IsUnique();
        }
    }
}
