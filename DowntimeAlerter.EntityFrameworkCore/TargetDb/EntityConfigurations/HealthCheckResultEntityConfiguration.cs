using DowntimeAlerter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DowntimeAlerter.EntityFrameworkCore.TargetDb.EntityConfigurations
{
    class HealthCheckResultEntityConfiguration : IEntityTypeConfiguration<HealthCheckResult>
    {
        public void Configure(EntityTypeBuilder<HealthCheckResult> builder)
        {
            builder.ToTable("HealthCheckResult");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("Id")
                .IsUnicode(false)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.TargetId)
                .HasColumnName("TargetId")
                .IsUnicode(true)
                .IsRequired();

            builder.Property(b => b.ExecutionTime)
                .HasColumnName("ExecutionTime")
                .IsRequired()
                .HasColumnType("datetime2(7)");

            builder.Property(b => b.Result)
               .HasColumnName("Result")
               .IsRequired()
               .HasColumnType("int");

            builder.Property(b => b.StatusCode)
                .HasColumnName("StatusCode")
                .IsRequired()
                .HasColumnType("int");

           
        }
    }
}
