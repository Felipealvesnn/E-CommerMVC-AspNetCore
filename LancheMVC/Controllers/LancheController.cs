
using LancheMVC_Aplication.DTOs;
using LancheMVC_Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static LancheMVC_Aplication.DTOs.AllDTo;

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
            AllDTo geraldto = new AllDTo();
            geraldto.LancheDTO = new LancheDTO();
            geraldto.resultLanche = new ResultLanche();
            //geraldto.categoriadto = new CategoriaDTo();

            var todos = await _lanches.RetornaTodos();
            geraldto.resultLanche.lLanches = todos.ToList();

            ViewData["data"] = DateTime.Now;
            var totalLanches = todos.Count();
            ViewBag.totalLanches = totalLanches;

            return View(todos);
        }
    }
}
