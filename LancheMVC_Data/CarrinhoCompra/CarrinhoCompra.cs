﻿using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LancheMVC
{
    public class CarrinhoCompra
    {

        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }
        private bool CarrinhoCompraItemExiste(int lancheId) => _context.CarrinhoCompraItem.Any(
                     s => s.Lanche.LancheId == lancheId &&
                     s.CarrinhoCompraId == CarrinhoCompraId);

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            CarrinhoCompraItem carrinhoCompraItem = null;

            if (!CarrinhoCompraItemExiste(lanche.LancheId))
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    LancheId = lanche.LancheId,
                   
                    Quantidade = 1
                };

                try
                {

                    _context.CarrinhoCompraItem.Add(carrinhoCompraItem);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else

            {
                carrinhoCompraItem = _context.CarrinhoCompraItem.FirstOrDefault(
                     s => s.Lanche.LancheId == lanche.LancheId &&
                     s.CarrinhoCompraId == CarrinhoCompraId);
                carrinhoCompraItem.Quantidade++;
                _context.Entry(carrinhoCompraItem).State = EntityState.Modified;
            }
            _context.SaveChanges();



            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItem.SingleOrDefault(
                   s => s.Lanche.LancheId == lanche.LancheId &&
                   s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItem.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ??
                   (CarrinhoCompraItems =
                       _context.CarrinhoCompraItem.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                           .Include(s => s.Lanche)
                           .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItem
                                 .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);
           
            _context.CarrinhoCompraItem.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItem.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}