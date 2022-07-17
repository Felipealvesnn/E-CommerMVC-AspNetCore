using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Domain.Interfaces
{
    public interface IRepository<t> where t : Entity
    {
        Task<IEnumerable<t>> ReTornaTodos();
        Task<t> PegaPorId(int? id);
       
    }
}
