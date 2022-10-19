using Microsoft.AspNetCore.Http;

namespace LancheMVC_Aplication.DTOs
{
    public class FileManagerModel
    {
        public FileInfo[] Files { get; set; }
        public IFormFile IformFile { get; set; }
        public List<IFormFile> IformFiles { get; set; }
        public string CaminhoDaImagemProduto { get; set; }
    }
}
