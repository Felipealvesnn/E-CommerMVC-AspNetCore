using LancheMVC.Helps;
using LancheMVC_Aplication.DTOs;
using LancheMVC_Aplication.Interfaces;
using LancheMVC_Domain;
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
                lanches = _lanches.RetornaTodos();

                categoriaAtual = "Todos os lanches";
                LanchesVM = new LancheListViewModel { lanches = lanches, CategoriaAtual = categoriaAtual };
            }
            else
            {

                lanches = _lanches.RetornaTodos();
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

        public ViewResult Search(string searchString)
        {
            IEnumerable<LancheDTO> lanches;
           
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lanches.RetornaTodos();
               

                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lanches.RetornaLanchePorNome(searchString);
               
               

                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }

    }
}
