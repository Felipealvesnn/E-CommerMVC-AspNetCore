//using LancheMVC_Domain;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LancheMVC_Data.EntitiesConfiguration
//{
//    public class CarrinhoConfigurations: IEntityTypeConfiguration<CarrinhoCompraItem>
//    {
//        public void Configure(EntityTypeBuilder<CarrinhoCompraItem> builder)
//        {
//            builder.HasKey(x => x.CarrinhoCompraItemId);
//            builder.Property(x => x.Quantidade).HasMaxLength(100).IsRequired();
//            builder.Property(c => c.CarrinhoCompraId).HasMaxLength(500).IsRequired();
//            builder.HasOne(e => e.Lanche).WithMany(e => e.Categoria).HasForeignKey(e => e.CategoriaId);
//        }
//    }
//}
