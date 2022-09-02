using AutoMapper;
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
            return _mapper.Map<LancheDTO>(LancheID);
            

        }

        public IEnumerable<LancheDTO> RetornaLanchePreferido()
        {
            var lanchepreferido = _lanche.RetornaLanchePreferido();
            return _mapper.Map<IEnumerable<LancheDTO>>(lanchepreferido);
        }
        public IEnumerable<LancheDTO> RetornaLanchePorNome(string t)
        {
            var lanchepreferido = _lanche.RetornaLanchePorNome(t);
            return _mapper.Map<IEnumerable<LancheDTO>>(lanchepreferido);
        }

        public IEnumerable<LancheDTO> RetornaTodos()
        {
            var categoriesEntity =  _lanche.ReTornaTodos();
            return  _mapper.Map<IEnumerable<LancheDTO>>(categoriesEntity);
        }
        public IEnumerable<LancheDTO> RetornaTodosLanchesComCategoria()
        {
            var categoriesEntity =  _lanche.RetornaLancheComCategoria();
            return _mapper.Map<IEnumerable<LancheDTO>>(categoriesEntity);
        }
    }
}
