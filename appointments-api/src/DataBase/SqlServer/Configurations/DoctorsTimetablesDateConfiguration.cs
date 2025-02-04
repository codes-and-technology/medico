using Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.SqlServer.Configurations;

public class DoctorsTimetablesDateConfiguration : IEntityTypeConfiguration<DoctorsTimetablesDateEntity>
{
    public void Configure(EntityTypeBuilder<DoctorsTimetablesDateEntity> builder)
    {
        builder.ToTable("DoctorsTimetablesDate");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("Id").HasMaxLength(50).IsRequired();
        builder.Property(e => e.IdDoctor).HasColumnName("IdDoctor").HasMaxLength(50).IsRequired();
        builder.Property(e => e.AvailableDate).IsRequired();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.DeleteDate).IsRequired(false);

        // Configuração do relacionamento com DoctorsTimetablesTimesEntity
        builder.HasMany(e => e.TimeList)
               .WithOne(t => t.DoctorsTimetablesDate)
               .HasForeignKey(t => t.IdDoctorsTimetablesDate)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
