using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entitys;

namespace DataBase.SqlServer.Configurations;

public class DoctorsTimetablesTimesConfiguration : IEntityTypeConfiguration<DoctorsTimetablesTimesEntity>
{
    public void Configure(EntityTypeBuilder<DoctorsTimetablesTimesEntity> builder)
    {
        builder.ToTable("DoctorsTimetablesTimes");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasMaxLength(50).IsRequired();
        builder.Property(e => e.IdDoctorsTimetablesDate).HasColumnName("IdDoctorsTimetablesDate").HasMaxLength(50).IsRequired();
        builder.Property(e => e.Time).IsRequired();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.DeleteDate).IsRequired(false);

        builder.HasOne(e => e.DoctorsTimetablesDate)
               .WithMany(d => d.TimeList)
               .HasForeignKey(e => e.IdDoctorsTimetablesDate)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
