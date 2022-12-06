using LancheMVC_Aplication.DTOs;
using LancheMVC_Data.Contexto;

namespace LancheMVC_Aplication.Serviços
{
    public class GraficoVendasServices
    {
        private readonly AppDbContext context;

        public GraficoVendasServices(AppDbContext contexte)
        {
            this.context = contexte;
        }
        public List<LancheGraficos> GetVendasLanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var lanches = (from pd in context.PedidoDetalhes
                           join l in context.Lanches on pd.LancheId equals l.LancheId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Nome }
                           into g
                           select new
                           {
                               LancheNome = g.Key.Nome,
                               LanchesQuantidade = g.Sum(q => q.Quantidade),
                               LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           });

            var lista = new List<LancheGraficos>();

            foreach (var item in lanches)
            {
                var lanche = new LancheGraficos();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LanchesQuantidade;
                lanche.LanchesValorTotal = item.LanchesValorTotal;
                lista.Add(lanche);
            }
            return lista;
        }
    }
}
