using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;

namespace LancheMVC_Data.Repository
{
    public class Repository<t> : IRepository<t> where t : Entity
    {
        public readonly AppDbContext _Ctx;

        public Repository(AppDbContext ctx)
        {
            _Ctx = ctx;
        }
        public IEnumerable<t> ReTornaTodos()
        {
            return _Ctx.Set<t>().ToList();
        }
        public t PegaPorId(int? id)
        {
            return _Ctx.Set<t>().Find(id);


        }


    }
}
