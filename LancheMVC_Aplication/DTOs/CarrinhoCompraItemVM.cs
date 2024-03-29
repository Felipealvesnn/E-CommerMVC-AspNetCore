﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LancheMVC_Aplication.DTOs
{
    [Table("CarrinhoCompraItens")]
    public class CarrinhoCompraItemVM
    {
        public int CarrinhoCompraItemId { get; set; }
        public LancheDTO Lanche { get; set; }

        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
