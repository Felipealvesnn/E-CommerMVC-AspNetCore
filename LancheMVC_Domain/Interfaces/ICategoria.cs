using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Domain.Interfaces
{
    public interface ICategoria 
    {
        IEnumerable<Categoria> ReTornaTodos();
        Categoria PegaPorId(int? id);
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Remover(Categoria categoria);
    }
}
