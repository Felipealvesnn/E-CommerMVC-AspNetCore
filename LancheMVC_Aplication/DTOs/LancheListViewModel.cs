namespace LancheMVC_Aplication.DTOs
{
    public class LancheListViewModel
    {
        public IEnumerable<LancheDTO> lanches { get; set; }
        public string CategoriaAtual { get; set; }

    }
}
