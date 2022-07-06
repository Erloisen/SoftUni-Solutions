using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;

namespace P01_StudentSystem.Data.Configurations
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        private const string ContentTypeString = "VARCHAR(MAX)";
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder
                .HasKey(h => h.HomeworkId);

            builder
                .Property(c => c.Content)
                .IsRequired()
                .HasColumnType(ContentTypeString);

            builder
                .Property(st => st.SubmissionTime)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);
        }
    }
}
