using LancheMVC_Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LancheMVC.Componets
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryMenu(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IViewComponentResult Invoke()
        {
            var categoria = _categoryServices.RetornaTodos();

            return View(categoria);
        }
    }
}