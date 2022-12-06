using AutoMapper;
using LancheMVC_Aplication.DTOs;
using LancheMVC_Aplication.Interfaces;
using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;

namespace LancheMVC_Aplication.Serviços
{
    public class CategoryService : ICategoryServices
    {
        private readonly ICategoria _Category;
        private readonly IMapper _mapper;

        public CategoryService(ICategoria category, IMapper mapper)
        {
            _Category = category;
            _mapper = mapper;
        }

        public void Add(CategoriaDTO categoryDTO)
        {
            _Category.Adicionar(_mapper.Map<Categoria>(categoryDTO));
        }

        public CategoriaDTO PegarPorId(int? id)
        {
            var categories = _Category.PegaPorId(id);
            return _mapper.Map<CategoriaDTO>(categories);
        }

        public void Remove(int? id)
        {
            var categoryEntity = _Category.PegaPorId(id);

            _Category.Remover(categoryEntity);
        }

        public IEnumerable<CategoriaDTO> RetornaTodos()
        {
            var categories = _Category.ReTornaTodos();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categories);
        }

        public void Update(CategoriaDTO categoryDTO)
        {
            _Category.Atualizar(_mapper.Map<Categoria>(categoryDTO));
        }
    }
}
