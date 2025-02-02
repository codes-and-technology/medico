using DeleteEntitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.SqlServer.Configurations;

public class DoctorTimetablesDateEntityConfiguration
{   public void Configure(EntityTypeBuilder<DoctorTimetablesDateEntity> builder) 
    {
        builder.ToTable("DoctorsTimetablesDate");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        
        builder.Property(p => p.IdDoctor).IsRequired();
    }
}