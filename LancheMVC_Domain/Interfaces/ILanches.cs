using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Domain.Interfaces
{
    public interface ILanches
    {
        IEnumerable<Lanche> RetornaLanchePreferido ();
        Lanche PegaLanchePorId(int? id);
        IEnumerable<Lanche> RetornaLancheComCategoria();
        IEnumerable<Lanche> RetornaLanchePorNome(string t);
        void  Adicionar(Lanche lanche);
        void  Atualizar(Lanche lanche);
        void  Remover(Lanche lanche);

    }
}
