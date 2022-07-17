
using LancheMVC_Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var todos = await _lanches.RetornaTodos();
            return View(todos);
        }
    }
}
