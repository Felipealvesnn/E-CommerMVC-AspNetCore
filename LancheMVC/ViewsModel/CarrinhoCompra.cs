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

            ////atribui o id do carrinho na Sessão
            //session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhocompraID = carrinhoId
            };

        }
    }
}
