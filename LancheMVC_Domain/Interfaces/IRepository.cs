namespace LancheMVC_Domain.Interfaces
{
    public interface IRepository<t> where t : Entity
    {
        IEnumerable<t> ReTornaTodos();
        t PegaPorId(int? id);


    }
}
