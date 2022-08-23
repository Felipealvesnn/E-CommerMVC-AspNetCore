using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Domain.Interfaces
{
    public interface ILanches: IRepository<Lanche>
    {
        IEnumerable<Lanche> RetornaLanchePreferido ();
        Task<Lanche> PegaLanchePorId(int? id);
        Task< IEnumerable<Lanche>> RetornaLancheComCategoria();

    }
}
