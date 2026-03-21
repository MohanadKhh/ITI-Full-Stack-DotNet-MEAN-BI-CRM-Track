using Exam_System.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_System.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> entity)
        {
            entity.Property(x => x.Text).IsRequired().HasMaxLength(2000);
            entity.Property(x => x.Points).HasDefaultValue(1);

            entity.HasOne(x => x.Exam)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.ExamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
