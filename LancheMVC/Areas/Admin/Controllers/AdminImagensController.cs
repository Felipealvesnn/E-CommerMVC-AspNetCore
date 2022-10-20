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

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }

            if (files.Count > 10)
            {
                ViewData["Erro"] = "Error: Quantidade de arquivos excedeu o limite";
                return View(ViewData);
            }

            long size = files.Sum(f => f.Length); // total em bytes dos aquirvos
            var filePathsName = new List<string>();
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath,
                   _myConfigs.NomePastaImagensProdutos);

            foreach (var formFile in files)
            {
                if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".gif") ||
                         formFile.FileName.Contains(".png"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                    filePathsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            //monta a ViewData que será exibida na view como resultado do envio 
            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " +
             $"com tamanho total de : {size} bytes";

            ViewBag.Arquivos = filePathsName;

            //retorna a viewdata
            return View(ViewData);
        }
    }
}
