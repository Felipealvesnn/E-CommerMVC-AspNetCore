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
        Task<IEnumerable<LancheDTO>> RetornaTodos();
        Task<LancheDTO> PegarPorId(int? id);
        IEnumerable<LancheDTO> RetornaLanchePreferido();
        Task<IEnumerable<LancheDTO>> RetornaTodosLanchesComCategoria();
    }
}
