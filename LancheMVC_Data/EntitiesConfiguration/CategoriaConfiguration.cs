using LancheMVC_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LancheMVC_Data.EntitiesConfiguration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.CategoriaId);
            builder.Property(c => c.CategoryName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Descricao).HasMaxLength(100);


        }
    }
}
