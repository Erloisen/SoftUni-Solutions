using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;

namespace P01_StudentSystem.Data
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string PhoneNumberType = "VARCHAR(10)";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(s => s.StudentId);

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder
                .Property(p => p.PhoneNumber)
                .IsRequired()
                .HasColumnType(PhoneNumberType);

            builder
                .Property(r => r.RegisteredOn)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder
                .HasMany(c => c.CourseEnrollments)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            builder
                .HasMany(h => h.HomeworkSubmissions)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);
        }
    }
}
