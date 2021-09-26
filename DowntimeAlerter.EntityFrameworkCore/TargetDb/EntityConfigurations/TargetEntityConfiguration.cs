using DowntimeAlerter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DowntimeAlerter.EntityFrameworkCore.TargetDb.EntityConfigurations
{
    class TargetEntityConfiguration : IEntityTypeConfiguration<Target>
    {
        public void Configure(EntityTypeBuilder<Target> builder)
        {
            builder.ToTable("Target");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("Id")
                .IsUnicode(false)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasColumnType("nvarchar(MAX)");

            builder.Property(b => b.Url)
               .HasColumnName("Url")
               .IsRequired()
               .HasColumnType("nvarchar(MAX)");

            builder.Property(b => b.MonitoringIntervalInMinutes)
               .HasColumnName("MonitoringIntervalInMinutes")
               .IsRequired()
               .HasColumnType("int");

            builder.Property(b => b.CreatedBy)
                .HasColumnName("CreatedBy")
                .IsRequired()
                .HasColumnType("nvarchar(MAX)");

            builder.Property(b => b.CreationDate)
                .HasColumnName("CreationDate")
                .IsRequired()
                .HasColumnType("datetime2(7)");

            builder.Property(b => b.LastUpdateDate)
                .HasColumnName("LastUpdateDate")
                .HasColumnType("datetime2(7)");
        }
    }
}
