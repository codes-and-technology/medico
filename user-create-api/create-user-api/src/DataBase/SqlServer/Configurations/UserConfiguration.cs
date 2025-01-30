using CreateEntitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.SqlServer.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.CRM);
        builder.Property(p => p.CPF).IsRequired();
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.CreateDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
        builder.Property(p => p.Name).IsRequired();
        
        builder
            .HasOne(u => u.Auth)
            .WithOne(a => a.User)
            .HasForeignKey<AuthEntity>(a => a.IdUser);
    }
}
