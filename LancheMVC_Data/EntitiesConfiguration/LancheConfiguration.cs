using LancheMVC_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Data.EntitiesConfiguration
{
    public class LancheConfiguration : IEntityTypeConfiguration<Lanche>
    {
        public void Configure(EntityTypeBuilder<Lanche> builder)
        {
            builder.HasKey(x => x.LancheId);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(c => c.DescricaoDetalhada).HasMaxLength(200).IsRequired();
            builder.Property(c => c.DescricaoCurta).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Preco).HasPrecision(10, 2);
            builder.HasOne(e => e.Categoria).WithMany(e => e.Lanches).HasForeignKey(e => e.CategoriaId);
        }
    }
}
