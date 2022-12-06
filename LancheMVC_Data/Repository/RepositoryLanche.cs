using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LancheMVC_Data.Repository
{
    public class RepositoryLanche : ILanches
    {
        public readonly AppDbContext _Ctx;

        public RepositoryLanche(AppDbContext ctx)
        {
            _Ctx = ctx;
        }

        public Lanche PegaLanchePorId(int? testes)
        {
            var testesss = _Ctx.Lanches.AsNoTracking().Include(c => c.Categoria).SingleOrDefault(p => p.LancheId == testes);
            _Ctx.Entry(testesss).State = EntityState.Detached;
            return testesss;

            //return _Ctx.Lanches.Find(id);
        }

        public IQueryable<Lanche> RetornaLanchePreferido()
        {
            return _Ctx.Lanches.Where(l => l.IsLanchePreferido).Include(l => l.Categoria);
        }

        public IQueryable<Lanche> RetornaLanchePorNome(string t)
        {
            return _Ctx.Lanches.Where(p => p.Nome.ToLower().Contains(t.ToLower()));
        }

        public IQueryable<Lanche> RetornaLancheComCategoria()
        {
            return _Ctx.Lanches.Include(l => l.Categoria).AsNoTracking().AsQueryable();
        }

        public void Adicionar(Lanche lanche)
        {
            _Ctx.Add(lanche);
            _Ctx.SaveChanges();
        }

        public void Atualizar(Lanche lanche)
        {
            _Ctx.Update(lanche);
            _Ctx.SaveChanges();
        }

        public void Remover(Lanche lanche)
        {
            _Ctx.Remove(lanche);
            _Ctx.SaveChanges();
        }
    }
}