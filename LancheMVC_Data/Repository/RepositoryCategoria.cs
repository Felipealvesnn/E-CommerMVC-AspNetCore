using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Data.Repository
{
    public class RepositoryCategoria : ICategoria
    {

        public readonly AppDbContext _Ctx;

        public RepositoryCategoria(AppDbContext ctx)
        {
            _Ctx = ctx;
        }

        public void Adicionar(Categoria categoria)
        {
            _Ctx.Add(categoria);
            _Ctx.SaveChanges();
        }

        public void Atualizar(Categoria categoria)
        {
            _Ctx.Update(categoria);
            _Ctx.SaveChanges();
        }

        public Categoria PegaPorId(int? id)
        {
            return _Ctx.Categorias.AsNoTracking().SingleOrDefault(p => p.CategoriaId == id);
        }

        public void Remover(Categoria categoria)
        {
            _Ctx.Remove(categoria);
            _Ctx.SaveChanges();
        }

        public IEnumerable<Categoria> ReTornaTodos()
        {
            return _Ctx.Categorias.ToList();
        }
    }
}
