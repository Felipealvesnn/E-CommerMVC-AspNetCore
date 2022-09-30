using LancheMVC_Domain;

namespace LancheMVC.ViewsModel
{
    public class PedidosVM
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
