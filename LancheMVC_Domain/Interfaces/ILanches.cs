using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Domain.Interfaces
{
    public interface ILanches
    {
        IQueryable<Lanche> RetornaLanchePreferido ();
        Lanche PegaLanchePorId(int? id);
        IQueryable<Lanche> RetornaLancheComCategoria();
        IQueryable<Lanche> RetornaLanchePorNome(string t);
        void  Adicionar(Lanche lanche);
        void  Atualizar(Lanche lanche);
        void  Remover(Lanche lanche);

    }
}
