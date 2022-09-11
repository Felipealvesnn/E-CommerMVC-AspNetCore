﻿using LancheMVC;
using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LancheMVC_Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext,
           CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void Adicionar(Pedido pedido)
        {
            _appDbContext.Pedidos.Add(pedido);
             _appDbContext.SaveChanges();
        }

        public void Atualizar(Pedido pedido)
        {
            _appDbContext.Update(pedido);
            _appDbContext.SaveChanges();
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            foreach (var item in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = item.Quantidade,
                    LancheId = item.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = item.Lanche.Preco
                };
                _appDbContext.PedidoDetalhes.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }

        public Pedido PegaPorId(int? id)
        {
            var pedido = _appDbContext.Pedidos.Find(id);
            return pedido;
        }

        public void Remover(Pedido pedido)
        {
          
            _appDbContext.Pedidos.Remove(pedido);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Pedido> ReTornaTodos()
        {
            return _appDbContext.Pedidos.ToList();
        }
        public Boolean PedidoExiste(int? id)
        {

            return _appDbContext.Pedidos.Any(e => e.PedidoId == id);
        }

        
    }
}