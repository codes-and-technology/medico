using Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.SqlServer.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentEntity>
{
    public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
    {
        builder.ToTable("Appointments");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).IsRequired().HasMaxLength(50);
        builder.Property(a => a.IdPatient).IsRequired().HasMaxLength(50);
        builder.Property(a => a.IdDoctor).IsRequired().HasMaxLength(50);
        builder.Property(a => a.IdDoctorsTimetablesDate).IsRequired().HasMaxLength(50);
        builder.Property(a => a.IdDoctorsTimetablesTime).IsRequired().HasMaxLength(50);
        builder.Property(a => a.CreateDate).IsRequired();
        builder.Property(p => p.DeleteDate).HasColumnType("DATETIME");
    }
}
