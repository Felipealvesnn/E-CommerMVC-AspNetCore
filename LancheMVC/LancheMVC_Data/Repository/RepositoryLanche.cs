using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LancheMVC_Data.Repository
{
    public class RepositoryLanche : Repository<Lanche>, ILanches
    {
        public RepositoryLanche(AppDbContext ctx) : base(ctx)
        {
        }

        public async Task<Lanche> PegaLanchePorId(int? id)
        {
            return await _Ctx.Lanches.Include(c => c.Categoria).SingleOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<Lanche> RetornaLanchePreferido()
        {
            return  _Ctx.Lanches.Where(l => l.IsLanchePreferido).Include(l => l.Categoria);
        }

        


    }
}
