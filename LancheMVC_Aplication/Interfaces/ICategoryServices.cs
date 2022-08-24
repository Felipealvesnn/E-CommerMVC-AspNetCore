using LancheMVC_Aplication.DTOs;


namespace LancheMVC_Aplication.Interfaces
{
    public interface ICategoryServices
    {
        IEnumerable<CategoriaDTO> RetornaTodos();
        Task<CategoriaDTO> PegarPorId(int? id);
     
    }
}
