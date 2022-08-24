using LancheMVC.Models;
using LancheMVC_Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LancheMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILancheServices _lanches;

        public HomeController(ILancheServices lanches, ILogger<HomeController> logger)
        {
            _lanches = lanches;
            _logger = logger;
        }

      

        public IActionResult Index()
        {
           var homeVm = new HomeVM { lanchePreferido = _lanches.RetornaLanchePreferido() };

            return View(homeVm);
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}