using EF_DB_ITI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DB_ITI.Configuration
{
    public class InsCoursesConfig : IEntityTypeConfiguration<InsCourses>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InsCourses> builder)
        {
            builder.HasKey(ic => new { ic.CrsId, ic.InsId });

            builder.HasOne(ic => ic.Course)
                .WithMany(c => c.InsCourses)
                .HasForeignKey(ic => ic.CrsId);

            builder.HasOne(ic => ic.Instuctor)
                .WithMany(I => I.InsCourses)
                .HasForeignKey(ic => ic.InsId);
        }
    }
}
