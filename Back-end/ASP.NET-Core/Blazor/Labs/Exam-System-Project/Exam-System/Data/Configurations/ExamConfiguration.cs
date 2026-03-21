using Exam_System.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_System.Data.Configurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> entity)
        {
            entity.Property(x => x.Title).IsRequired().HasMaxLength(150);

            entity.HasOne(x => x.Subject)
                .WithMany(x => x.Exams)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
