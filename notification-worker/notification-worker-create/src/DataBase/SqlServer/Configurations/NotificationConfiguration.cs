using CreateEntitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.SqlServer.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<NotificationEntity>
{
    public void Configure(EntityTypeBuilder<NotificationEntity> builder)
    {
        builder.ToTable("Notification");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.CreateDate).IsRequired();
        builder.Property(p => p.Message).IsRequired();
        builder.Property(p => p.SendDate);
        builder.Property(p => p.Sucess);
        builder.Property(p => p.ErrorMessage);
    }
}