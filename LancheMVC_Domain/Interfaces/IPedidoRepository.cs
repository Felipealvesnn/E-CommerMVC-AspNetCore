namespace LancheMVC_Domain.Interfaces
{
    public interface IPedidoRepository
    {
        IQueryable<Pedido> ReTornaTodos();
        void Adicionar(Pedido pedido);
        Pedido PegaPorId(int? id);
        void Atualizar(Pedido pedido);
        void CriarPedido(Pedido pedido);
        void Remover(Pedido pedido);
        Boolean PedidoExiste(int? id);
    }
}
