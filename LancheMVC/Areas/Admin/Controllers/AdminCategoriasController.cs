using LancheMVC_Aplication.DTOs;
using LancheMVC_Aplication.Interfaces;
using LancheMVC_Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LancheMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
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
            var ordenados = todeslanches.OrderBy(d => d.CategoriaId);
            return View(ordenados);
        }

        public IActionResult Create()
        {

            return PartialView("_Create");
        }
        [HttpPost]
        public IActionResult Create(CategoriaDTO categoria)
        {
            if (ModelState.IsValid)
            {
                _Categorias.Add(categoria);
                return RedirectToAction(nameof(Index));
            }
          //  ~/ Areas / Views / AdminCategorias / _Create.cshtml
            return View("_Create", categoria);
        }

        public IActionResult _Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _Categorias.PegarPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return PartialView(categoria);
        }

        // POST: Admin/AdminLanches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoriaDTO categoria)
        {
            if (ModelState.IsValid)
            {
                _Categorias.Update(categoria);
                return RedirectToAction(nameof(Index));
            }

       
            return View(categoria);
        }
    }
}
