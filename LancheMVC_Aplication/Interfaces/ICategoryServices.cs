using LancheMVC_Aplication.DTOs;


namespace LancheMVC_Aplication.Interfaces
{
    public interface ICategoryServices
    {
        IEnumerable<CategoriaDTO> RetornaTodos();
        CategoriaDTO PegarPorId(int? id);
     
    }
}
