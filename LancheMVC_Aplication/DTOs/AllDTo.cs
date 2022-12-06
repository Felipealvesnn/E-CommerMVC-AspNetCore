namespace LancheMVC_Aplication.DTOs
{
    public class AllDTo
    {
        public CategoriaDTO categoriadto { get; set; }
        public LancheDTO LancheDTO { get; set; }

        public ResultCategoria resultCategoria { get; set; }
        public ResultLanche resultLanche { get; set; }

        public class ResultCategoria
        {
            public List<CategoriaDTO> lCategorias { get; set; }
        }

        public class ResultLanche
        {
            public List<LancheDTO> lLanches { get; set; }
        }

    }
}
