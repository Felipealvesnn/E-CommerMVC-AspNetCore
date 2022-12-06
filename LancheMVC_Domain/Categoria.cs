namespace LancheMVC_Domain
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string CategoryName { get; set; }
        public string Descricao { get; set; }
        public List<Lanche> Lanches { get; set; }

        //public Categoria(string categoryName, string descricao, List<Lanche> lanches)
        //{
        //    CategoryName = categoryName;
        //    Descricao = descricao;
        //    Lanches = lanches;
        //}
    }
}