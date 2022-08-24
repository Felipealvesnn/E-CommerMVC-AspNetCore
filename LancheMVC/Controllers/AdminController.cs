using Microsoft.AspNetCore.Mvc;

namespace LancheMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
