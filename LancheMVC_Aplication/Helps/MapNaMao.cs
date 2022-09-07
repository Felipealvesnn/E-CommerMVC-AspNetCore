using LancheMVC_Aplication.DTOs;
using LancheMVC_Domain;

namespace LancheMVC
{
    public static class MapNaMao
    {
        public static LancheDTO TOLancheDTO (this Lanche model)
        {

            return new LancheDTO()
            {
                Id = model.LancheId,
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
                LancheId = model.Id,
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

        
            public static IEnumerable<LancheDTO> TOLancheDTOEnumerable(this IEnumerable<Lanche> model)
            {

                return model.Select(p => new LancheDTO()
                {
                    Id = p.LancheId,
                    Nome = p.Nome,
                    DescricaoCurta = p.DescricaoCurta,
                    DescricaoDetalhada = p.DescricaoDetalhada,
                    Preco = p.Preco,
                    ImagemUrl = p.ImagemUrl,
                    ImagemThumbnailUrl = p.ImagemUrl,
                    IsLanchePreferido = p.IsLanchePreferido,
                    EmEstoque = p.EmEstoque,
                    CategoriaId = p.CategoriaId,
                    Categoria = p.Categoria,
                });
            }

        }
}
