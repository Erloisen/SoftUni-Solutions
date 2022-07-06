using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        private const string UrlType = "VARCHAR(MAX)";
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder
                .HasKey(r => r.ResourceId);

            builder
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder
                .Property(url => url.Url)
                .IsRequired()
                .HasColumnType(UrlType);
        }
    }
}
