using LancheMVC.ViewsModel;
using LancheMVC_Aplication.Serviços;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LancheMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class AdminGraficoController : Controller
    {

        private readonly GraficoVendasServices _graficoVendasServices;

        public AdminGraficoController(GraficoVendasServices graficoVendasServices)
        {
            _graficoVendasServices = graficoVendasServices ?? throw new ArgumentNullException(nameof(graficoVendasServices));
        }

        public JsonResult VendasLanches(int dias)
        {
            var lanchesVendasTotais = _graficoVendasServices.GetVendasLanches(dias);
            return Json(lanchesVendasTotais);
        }
        [HttpGet]
        public IActionResult Index(int dias)
        {
            return View();
        }
        [HttpGet]
        public IActionResult VendasMensal(int dias)
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasSemanal(int dias)
        {
            return View();
        }
    }
}
