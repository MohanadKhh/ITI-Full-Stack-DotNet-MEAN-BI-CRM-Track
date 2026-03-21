using Exam_System.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_System.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> entity)
        {
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Description).HasMaxLength(1000);
        }
    }
}
