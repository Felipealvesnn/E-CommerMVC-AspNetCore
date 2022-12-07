using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Data.Services
{

    public class RelatorioLanchesService
    {
        private readonly AppDbContext _context;

        public RelatorioLanchesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lanche>> GetLanchesReport()
        {
            var lanches = await _context.Lanches.ToListAsync();
            if (lanches is null)
                return default(IEnumerable<Lanche>);

            return lanches;

        }
        public async Task<IEnumerable<Categoria>> GetCategoriasReport()
        {
            var Categoria = await _context.Categorias.ToListAsync();
            if (Categoria is null)
                return default(IEnumerable<Categoria>);

            return Categoria;

        }



    }
}
