using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMVC_Domain
{
    public class Lanche : Entity
    {
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public Lanche(string nome, string descricaoCurta, string descricaoDetalhada, decimal preco, string imagemUrl, string imagemThumbnailUrl, bool isLanchePreferido, bool emEstoque, int categoriaId, Categoria categoria)
        {
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoDetalhada = descricaoDetalhada;
            Preco = preco;
            ImagemUrl = imagemUrl;
            ImagemThumbnailUrl = imagemThumbnailUrl;
            IsLanchePreferido = isLanchePreferido;
            EmEstoque = emEstoque;
            CategoriaId = categoriaId;
            Categoria = categoria;
        }
    }
}
