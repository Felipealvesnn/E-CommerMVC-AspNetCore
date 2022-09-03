using LancheMVC_Aplication.DTOs;
using LancheMVC_Domain;

namespace LancheMVC.Helps
{
    public static class MapNaMao
    {
        public static LancheDTO TOLancheDTO (this Lanche model)
        {

            return new LancheDTO()
            {
                Id = model.Id,
                Nome = model.Nome,
                DescricaoCurta = model.DescricaoCurta,
                DescricaoDetalhada = model.DescricaoDetalhada,
                Preco = model.Preco,
                ImagemUrl = model.ImagemUrl,
                ImagemThumbnailUrl = model.ImagemUrl,
                IsLanchePreferido = model.IsLanchePreferido,
                EmEstoque = model.EmEstoque,
                CategoriaId = model.CategoriaId,
                Categoria = model.Categoria,

            };

        }
        public static Lanche TOLanche(this LancheDTO model)
        {

            return new Lanche()
            {
                Id = model.Id,
                Nome = model.Nome,
                DescricaoCurta = model.DescricaoCurta,
                DescricaoDetalhada = model.DescricaoDetalhada,
                Preco = model.Preco,
                ImagemUrl = model.ImagemUrl,
                ImagemThumbnailUrl = model.ImagemUrl,
                IsLanchePreferido = model.IsLanchePreferido,
                EmEstoque = model.EmEstoque,
                CategoriaId = model.CategoriaId,
                Categoria = model.Categoria,


            };

        }

    }
}
