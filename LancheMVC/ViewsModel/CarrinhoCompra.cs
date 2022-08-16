using AutoMapper;
using LancheMVC_Aplication.DTOs;
using LancheMVC_Data.Contexto;
using LancheMVC_Domain;
using Microsoft.EntityFrameworkCore;

namespace LancheMVC
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _Context;
        private readonly IMapper _mapper;
        private AppDbContext context;

        public CarrinhoCompra(AppDbContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }

        public CarrinhoCompra(AppDbContext context)
        {
            this.context = context;
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

        public void AdicionarAoCarrinho(Task<LancheDTO> lanches)
        {

              var lanche = _mapper.Map<Lanche>(lanches);
            var carrinhoCompraItem = _Context.CarrinhoCompraItem.SingleOrDefault(
                     s => s.Lanche.Id == lanche.Id &&
                     s.CarrinhoCompraId == CarrinhocompraID);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhocompraID,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _Context.CarrinhoCompraItem.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _Context.SaveChanges();
        }

        public int RemoverDoCarrinho(Task<LancheDTO> lanches)
        {
            var lanche = _mapper.Map<Lanche>(lanches);
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
