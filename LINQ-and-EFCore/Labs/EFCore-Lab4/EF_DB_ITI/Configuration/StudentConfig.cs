using EF_DB_ITI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DB_ITI.Configuration
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FName).HasMaxLength(20);
            builder.Property(s=>s.LName).HasMaxLength(20);

            builder.HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DeptId);

            builder.HasOne(s => s.Supervisor)
                .WithMany(su => su.Students)
                .HasForeignKey(s => s.SuperID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
