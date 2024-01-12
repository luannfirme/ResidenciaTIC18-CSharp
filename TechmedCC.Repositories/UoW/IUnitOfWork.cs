namespace TechmedCC.Infra.UoW
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
