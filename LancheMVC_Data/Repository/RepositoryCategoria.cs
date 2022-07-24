using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Data.Repository
{
    public class RepositoryCategoria : Repository<Categoria>, ICategoria
    {
        public RepositoryCategoria(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
