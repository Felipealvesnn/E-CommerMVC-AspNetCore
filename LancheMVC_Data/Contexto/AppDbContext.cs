using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace LancheMVC_Data.Contexto
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Categoria> Categorias { get;  set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItem { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
         
        }

        
    }
}
