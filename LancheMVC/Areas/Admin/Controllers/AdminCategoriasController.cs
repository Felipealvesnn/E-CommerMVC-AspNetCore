using LancheMVC_Aplication.Interfaces;
using LancheMVC_Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LancheMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoriasController : Controller
    {
        private readonly ILancheServices _lanches;
        private readonly ICategoryServices _Categorias;
        private readonly ICategoria _Category;

        public AdminCategoriasController(ILancheServices lanches, ICategoryServices categorias, ICategoria category)
        {
            _lanches = lanches;
            _Categorias = categorias;
            _Category = category;
        }

        public IActionResult Index()
        {
            var todeslanches = _Categorias.RetornaTodos();
            var ordenados = todeslanches.OrderBy(d => d.Id);
            return View(ordenados);
        }
    }
}
