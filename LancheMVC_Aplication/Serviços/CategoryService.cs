using AutoMapper;
using LancheMVC_Aplication.DTOs;
using LancheMVC_Aplication.Interfaces;
using LancheMVC_Domain;
using LancheMVC_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public  CategoriaDTO PegarPorId(int? id)
        {
            var categories =  _Category.PegaPorId(id);
            return _mapper.Map<CategoriaDTO>(categories);
        }

        public  IEnumerable<CategoriaDTO> RetornaTodos()
        {
            var categories =  _Category.ReTornaTodos();
            return  _mapper.Map<IEnumerable<CategoriaDTO>>(categories);
        }
    }
}
