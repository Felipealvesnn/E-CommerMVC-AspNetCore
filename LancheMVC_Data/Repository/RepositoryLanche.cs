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
       

        public Lanche PegaLanchePorId(int? id)
        {
              return _Ctx.Lanches.AsNoTracking().Include(c => c.Categoria).SingleOrDefault(p => p.Id == id);
            // return _Ctx.Lanches.Find(id);

        }
     
        public IEnumerable<Lanche> RetornaLanchePreferido()
        {
            return  _Ctx.Lanches.AsNoTracking().Where(l => l.IsLanchePreferido).Include(l => l.Categoria);
        }
        public IEnumerable<Lanche> RetornaLanchePorNome(string t)
        {
            return _Ctx.Lanches.Where(p => p.Nome.ToLower().Contains(t.ToLower()));
        }

        public  IEnumerable<Lanche> RetornaLancheComCategoria()
        {
            return  _Ctx.Lanches.AsNoTracking().Include(l => l.Categoria).ToList();
        }
    }
}
