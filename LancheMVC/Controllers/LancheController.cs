
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

        public async Task<IActionResult> List()
        {
            LancheListViewModel geraldto = new LancheListViewModel();



            geraldto.lanches = await _lanches.RetornaTodos();
            geraldto.CategoriaAtual = "categoria atual";
            

            ViewData["data"] = DateTime.Now;
            var totalLanches = geraldto.lanches.Count();
            ViewBag.totalLanches = totalLanches;

            return View(geraldto);
        }
    }
}
