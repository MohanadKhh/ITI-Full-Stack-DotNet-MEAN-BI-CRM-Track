using EF_DB_ITI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EF_DB_ITI.Configuration
{
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.ID);

            builder.HasOne(i => i.Department)
                .WithMany(d => d.Instuctors)
                .HasForeignKey(i => i.DeptId);
        }
    }
}
