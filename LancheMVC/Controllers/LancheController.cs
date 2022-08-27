using LancheMVC_Aplication.DTOs;
using LancheMVC_Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LancheMVC.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheServices _lanches;
       

        public LancheController(ILancheServices lanches)
        {
            _lanches = lanches;
        }

        public IActionResult List(string Category)
        {

            IEnumerable<LancheDTO> lanches;
            IEnumerable<LancheDTO> LancheOrdenado;
            string categoriaAtual = string.Empty;
            LancheListViewModel LanchesVM;


            if (string.IsNullOrEmpty(Category))
            {
                lanches = _lanches.RetornaTodosLanchesComCategoria();

                categoriaAtual = "Todos os lanches";
                LanchesVM = new LancheListViewModel { lanches = lanches, CategoriaAtual = categoriaAtual };
            }
            else
            {

                lanches = _lanches.RetornaTodosLanchesComCategoria();
                LancheOrdenado = lanches.Where(l => l.Categoria.CategoryName.Equals(Category));

                var tr = 50.0.porcentagemArrombada(23);


                categoriaAtual = Category;
                LanchesVM = new LancheListViewModel { lanches = LancheOrdenado, CategoriaAtual = categoriaAtual };

            }



            //ViewData["data"] = DateTime.Now;
            //var totalLanches = LanchesVM.lanches.Count();
            //ViewBag.totalLanches = totalLanches;

            return View(LanchesVM);
        }
        public IActionResult Details(int Id)
        {
            var lanche = _lanches.PegarPorId(Id) ;
            return View(lanche);
        }

    }
}
