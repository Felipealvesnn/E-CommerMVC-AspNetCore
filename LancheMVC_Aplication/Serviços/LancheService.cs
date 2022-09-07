using AutoMapper;
using LancheMVC;
using LancheMVC_Aplication.DTOs;
using LancheMVC_Aplication.Interfaces;
using LancheMVC_Domain.Interfaces;


namespace LancheMVC_Aplication.Serviços
{
    public class LancheService : ILancheServices
    {
        private readonly ILanches _lanche;
        private readonly IMapper _mapper;

        public LancheService(ILanches lanche, IMapper mapper)
        {
            _lanche = lanche;
            _mapper = mapper;
        }

        public LancheDTO PegarPorId(int? id)
        {
            var LancheID =  _lanche.PegaLanchePorId(id);
            return LancheID.TOLancheDTO();



        }

        public IEnumerable<LancheDTO> RetornaLanchePreferido()
        {
            var lanchepreferido = _lanche.RetornaLanchePreferido();
            return lanchepreferido.TOLancheDTOEnumerable();
        }
        public IEnumerable<LancheDTO> RetornaLanchePorNome(string t)
        {
            var lanchepreferido = _lanche.RetornaLanchePorNome(t);

            return lanchepreferido.TOLancheDTOEnumerable();
        }

        public IEnumerable<LancheDTO> RetornaTodos()
        {
            var categoriesEntity =  _lanche.RetornaLancheComCategoria();
            return categoriesEntity.TOLancheDTOEnumerable();
        }
      
    }
}
