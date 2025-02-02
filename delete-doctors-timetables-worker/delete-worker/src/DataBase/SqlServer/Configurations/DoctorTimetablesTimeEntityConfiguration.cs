using DeleteEntitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.SqlServer.Configurations;

public class DoctorTimetablesTimeEntityConfiguration : IEntityTypeConfiguration<DoctorTimetablesTimeEntity>
{
    public void Configure(EntityTypeBuilder<DoctorTimetablesTimeEntity> builder) 
    {
        builder.ToTable("DoctorsTimetablesTimes");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        
        builder.Property(p => p.IdDoctorsTimetablesDate).IsRequired();
        builder.Property(p => p.Time).IsRequired();

        builder.HasOne(o => o.DoctorTimetablesDate)
            .WithMany(m => m.DoctorTimetablesTimes)
            .HasForeignKey(t => t.IdDoctorsTimetablesDate) 
            .OnDelete(DeleteBehavior.Cascade);
    }
}