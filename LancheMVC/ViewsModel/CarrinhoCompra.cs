using LancheMVC_Data.Contexto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LancheMVC_Domain
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _Context;

        public CarrinhoCompra(AppDbContext context)
        {
            _Context = context;
        }

        public string CarrinhocompraID { get; set; }
        public List< CarrinhoCompraItem> CarrinhoCompraItems{ get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider Services) {
            //define uma sessão
            ISession session =
                Services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto 
            var context = Services.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhocompraID = carrinhoId
            };

        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _Context.CarrinhoCompraItens.SingleOrDefault(
                     s => s.Lanche.LancheId == lanche.LancheId &&
                     s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _Context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _Context.SaveChanges();
        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _Context.CarrinhoCompraItem.SingleOrDefault(
                   s => s.Lanche.Id == lanche.Id &&
                   s.CarrinhoCompraId == CarrinhocompraID);

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
                    _Context.CarrinhoCompraItem.Remove(carrinhoCompraItem);
                }
            }
            _Context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ??
                   (CarrinhoCompraItems =
                       _Context.CarrinhoCompraItem.Where(c => c.CarrinhoCompraId == CarrinhocompraID)
                           .Include(s => s.Lanche)
                           .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _Context.CarrinhoCompraItem
                                 .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhocompraID);

            _Context.CarrinhoCompraItem.RemoveRange(carrinhoItens);
            _Context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _Context.CarrinhoCompraItem.Where(c => c.CarrinhoCompraId == CarrinhocompraID)
                .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}
