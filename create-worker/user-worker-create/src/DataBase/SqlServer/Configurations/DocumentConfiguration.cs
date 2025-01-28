using CreateEntitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.SqlServer.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<DocumentEntity>
{
    public void Configure(EntityTypeBuilder<DocumentEntity> builder)
    {
        builder.ToTable("Documento");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.TypeDocumentId).IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("DataCriacao").HasColumnType("DATETIME").IsRequired();

        builder.HasOne(d => d.ApplicationUser)
             .WithMany() 
             .HasForeignKey(d => d.UserId) 
             .OnDelete(DeleteBehavior.Cascade);
    }
}