using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using Microsoft.EntityFrameworkCore;

namespace LancheMVC_Data
{
    public class RelatorioVendaService
    {
        private readonly AppDbContext context;

        public RelatorioVendaService(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Pedido>> ProcuraDAtaASYNC(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                         .Include(l => l.PedidoItens)
                         .ThenInclude(l => l.Lanche)
                         .OrderByDescending(x => x.PedidoEnviado)
                         .ToListAsync();
        }

    }
}
