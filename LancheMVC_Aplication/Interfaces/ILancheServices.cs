using LancheMVC_Aplication.DTOs;
using LancheMVC_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Aplication.Interfaces
{
    public interface ILancheServices
    {
        IQueryable<LancheDTO> RetornaTodos();
        LancheDTO PegarPorId(int? id);
        IQueryable<LancheDTO> RetornaLanchePreferido();
        IQueryable<LancheDTO> RetornaLanchePorNome(string t);
        void Add(LancheDTO productDTO);
        void Update(LancheDTO productDTO);
        void Delete(int? id);

    }
}
