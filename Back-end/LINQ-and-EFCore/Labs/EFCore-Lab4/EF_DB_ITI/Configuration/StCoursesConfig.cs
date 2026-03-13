using EF_DB_ITI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_DB_ITI.Configuration
{
    public class StCoursesConfig : IEntityTypeConfiguration<StCourses>
    {
        public void Configure(EntityTypeBuilder<StCourses> builder)
        {
            builder.HasKey(sc => new { sc.StId, sc.CrsId });

            builder.HasOne(sc => sc.Student)
                .WithMany(s => s.StCourses)
                .HasForeignKey(sc => sc.StId);

            builder.HasOne(sc => sc.Course)
                .WithMany(c => c.StCourses)
                .HasForeignKey(sc => sc.CrsId);
        }
    }
}
