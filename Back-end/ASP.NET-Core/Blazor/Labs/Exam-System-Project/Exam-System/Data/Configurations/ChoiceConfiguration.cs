using Exam_System.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_System.Data.Configurations
{
    public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> entity)
        {
            entity.Property(x => x.Text).IsRequired().HasMaxLength(1000);

            entity.HasOne(x => x.Question)
                .WithMany(x => x.Choices)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(x => new { x.QuestionId, x.IsCorrect })
                .HasFilter("[IsCorrect] = 1")
                .IsUnique();
        }
    }
}
