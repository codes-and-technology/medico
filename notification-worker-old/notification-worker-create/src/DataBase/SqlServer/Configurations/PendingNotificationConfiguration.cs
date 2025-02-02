using CreateEntitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.SqlServer.Configurations;

public class PendingNotificationConfiguration : IEntityTypeConfiguration<PendingNotificationEntity>
{
    public void Configure(EntityTypeBuilder<PendingNotificationEntity> builder)
    {
        builder.ToTable("PendingNotification");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Success);
        builder.Property(p => p.ErrorMessage);
        builder.Property(p => p.SendDate);
        builder.Property(p => p.CreateDate).IsRequired();
        builder.Property(p => p.Message).IsRequired();
        builder.Property(p => p.DoctorEmail).IsRequired();
        builder.Property(p => p.DoctorName).IsRequired();
        builder.Property(p => p.PatientName).IsRequired();
        builder.Property(p => p.AppointmentDate).IsRequired();
        builder.Property(p => p.AppointmentTime).IsRequired();
    }
}