using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LancheMVC_Data.Repository
{
    public class RepositoryLanche :  ILanches
    {
        public readonly AppDbContext _Ctx;

        public RepositoryLanche(AppDbContext ctx)
        {
            _Ctx = ctx;
        }


        public Lanche PegaLanchePorId(int? testes)
        {
              return _Ctx.Lanches.Include(c => c.Categoria).SingleOrDefault(p => p.LancheId == testes);
            //return _Ctx.Lanches.Find(id);

        }
     
        public IEnumerable<Lanche> RetornaLanchePreferido()
        {
            return  _Ctx.Lanches.Where(l => l.IsLanchePreferido).Include(l => l.Categoria);
        }
        public IEnumerable<Lanche> RetornaLanchePorNome(string t)
        {
            return _Ctx.Lanches.Where(p => p.Nome.ToLower().Contains(t.ToLower()));
        }

        public  IEnumerable<Lanche> RetornaLancheComCategoria()
        {
            return _Ctx.Lanches.Include(l => l.Categoria).ToList();
        }
    }
}
