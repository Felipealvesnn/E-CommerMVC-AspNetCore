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

        public async Task<IActionResult> List(string Category)
        {
            
            IEnumerable<LancheDTO> lanches;
            IEnumerable<LancheDTO> LancheOrdenado;
            string categoriaAtual = string.Empty;
            LancheListViewModel LanchesVM ;


            if (string.IsNullOrEmpty(Category))
            {
                lanches = await _lanches.RetornaTodosLanchesComCategoria();

                categoriaAtual = "Todos os lanches";
                LanchesVM = new LancheListViewModel { lanches = lanches, CategoriaAtual = categoriaAtual };
            }
            else
            {
                
                    lanches = await _lanches.RetornaTodosLanchesComCategoria();
                    LancheOrdenado = lanches.Where(l => l.Categoria.CategoryName.Equals(Category));
                   


             
                categoriaAtual = Category;
                LanchesVM = new LancheListViewModel { lanches = LancheOrdenado, CategoriaAtual = categoriaAtual };

            }
             


            //ViewData["data"] = DateTime.Now;
            //var totalLanches = LanchesVM.lanches.Count();
            //ViewBag.totalLanches = totalLanches;

            return View(LanchesVM);
        }
    }
}
