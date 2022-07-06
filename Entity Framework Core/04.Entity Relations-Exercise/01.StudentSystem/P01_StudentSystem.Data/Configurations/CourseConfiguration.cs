using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasKey(c => c.CourseId);

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode();

            builder
                .Property(d => d.Description)
                .IsUnicode();

            builder
                .HasMany(s => s.StudentsEnrolled)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            builder
                .HasMany(r => r.Resources)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            builder
                .HasMany(hs => hs.HomeworkSubmissions)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
