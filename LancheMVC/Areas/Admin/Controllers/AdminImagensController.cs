using LancheMVC_Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LancheMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {


        private readonly ConfigurationImagens _myConfigs;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminImagensController(IOptions<ConfigurationImagens> myConfigs, IWebHostEnvironment webHostEnvironment)
        {
            _myConfigs = myConfigs.Value;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
