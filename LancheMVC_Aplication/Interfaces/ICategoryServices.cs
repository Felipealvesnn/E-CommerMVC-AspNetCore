using LancheMVC_Aplication.DTOs;


namespace LancheMVC_Aplication.Interfaces
{
    public interface ICategoryServices
    {
        IEnumerable<CategoriaDTO> RetornaTodos();
        CategoriaDTO PegarPorId(int? id);
        void Add(CategoriaDTO categoryDTO);
        void Update(CategoriaDTO categoryDTO);
        void Remove(int? id);

    }
}
