using LancheMVC_Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LancheMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatorioVendaService relatorioVendasService;

        public AdminRelatorioVendasController(RelatorioVendaService _relatorioVendasService)
        {
            relatorioVendasService = _relatorioVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate,
           DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await relatorioVendasService.ProcuraDAtaASYNC(minDate, maxDate);
            return View(result);
        }
    }
}
