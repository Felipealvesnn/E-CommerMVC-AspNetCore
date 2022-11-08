using LancheMVC_Aplication.DTOs;
using LancheMVC_Aplication.Interfaces;
using LancheMVC_Data.Repository;
using LancheMVC_Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;

namespace LancheMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class AdminLanchesController : Controller
    {
        private readonly ILancheServices _lanches;
        private readonly ICategoryServices _Categorias;
        private readonly ICategoria _Category;

        public AdminLanchesController(ILancheServices lanches, ICategoryServices categorias, ICategoria category)
        {
            _lanches = lanches;
            _Categorias = categorias;
            _Category = category;
        }

        //public IActionResult Index()
        //{
        //    var todeslanches = _lanches.RetornaTodos();
        //    var ordenados = todeslanches.OrderBy(d => d.Id);
        //    return View(ordenados);
        //}
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {
            var resultado = _lanches.RetornaTodos();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Nome.Contains(filter));
            }

            var model = await PagingList.CreateAsync(resultado, 3, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }



        public IActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(_Category.ReTornaTodos(), "CategoriaId", "CategoryName");
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(LancheDTO lanche)
        {
            if (ModelState.IsValid)
            {
                _lanches.Add(lanche);
                return RedirectToAction(nameof(Index));
            }
            return View(lanche);
        }

        public IActionResult _Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanche = _lanches.PegarPorId(id);
            if (lanche == null)
            {
                return NotFound();
            }
            ViewBag.CategoriaId = new SelectList(_Category.ReTornaTodos(), "CategoriaId", "CategoryName", lanche.CategoriaId);

            return PartialView(lanche);
        }

        // POST: Admin/AdminLanches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LancheDTO lanche)
        {
            if (ModelState.IsValid)
            {
                _lanches.Update(lanche);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoriaId = new SelectList(_Category.ReTornaTodos(), "CategoriaId", "CategoryName", lanche.CategoriaId);
            return View(lanche);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
             _lanches.Delete(id);
           // return RedirectToAction(nameof(Index));

           return RedirectToAction("Index", " AdminLanches");
        }



    }
}