using LancheMVC_Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LancheMVC.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheServices _lanches;
        private readonly CarrinhoCompra _carrrinhoCompra;

        public CarrinhoCompraController(ILancheServices lanches, CarrinhoCompra carrrinhoCompra)
        {
            _lanches = lanches;
            _carrrinhoCompra = carrrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrrinhoCompra.GetCarrinhoCompraItens();
            _carrrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarinhoCompraVM {
                CarrinhoCompra = _carrrinhoCompra,
                CarrinhoCompraTotal= _carrrinhoCompra.GetCarrinhoCompraTotal(),

            };

            return View(carrinhoCompraVM);
        }
        public RedirectToActionResult AdicionarItemNoCarrinho(int lancheId) { 
        
        var LancheSelecionado= _lanches.PegarPorId(lancheId);
            if (LancheSelecionado != null) {
                _carrrinhoCompra.AdicionarAoCarrinho(LancheSelecionado);
            
            }
            return RedirectToAction("Index");


        }
        public RedirectToActionResult RemoverItemNoCarrinho(int lancheId)
        {

            var LancheSelecionado = _lanches.PegarPorId(lancheId);
            if (LancheSelecionado != null)
            {
                _carrrinhoCompra.RemoverDoCarrinho(LancheSelecionado);

            }
            return RedirectToAction("Index");


        }

    }
}
