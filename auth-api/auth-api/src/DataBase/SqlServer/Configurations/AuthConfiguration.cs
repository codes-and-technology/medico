using CreateEntitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.SqlServer.Configurations;

public class AuthConfiguration : IEntityTypeConfiguration<AuthEntity>
{
    public void Configure(EntityTypeBuilder<AuthEntity> builder)
    {
        builder.ToTable("Auth");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Password).IsRequired();
        builder.Property(p => p.CreateDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
        builder.Property(p => p.LastLoginDate).HasColumnType("DATETIME");
        builder.Property(p => p.IdUser).IsRequired();
        
        
    }
}
