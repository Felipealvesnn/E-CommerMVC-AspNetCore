using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Aplication.DTOs
{
    public class LancheListViewModel
    {
        public IEnumerable<LancheDTO> lanches { get; set; }
        public string CategoriaAtual { get; set; }

    }
}
