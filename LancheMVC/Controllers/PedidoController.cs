using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LancheMVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            this.pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            return View();
        }
    }
}
