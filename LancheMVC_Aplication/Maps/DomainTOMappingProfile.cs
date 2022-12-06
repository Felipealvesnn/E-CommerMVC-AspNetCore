using AutoMapper;
using LancheMVC_Aplication.DTOs;
using LancheMVC_Domain;

namespace LancheMVC_Aplication.Maps
{
    public class DomainTOMappingProfile : Profile
    {
        public DomainTOMappingProfile()
        {
            CreateMap<Lanche, LancheDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();

        }
    }
}
