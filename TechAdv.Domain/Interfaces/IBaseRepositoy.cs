namespace TechAdv.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        ICollection<T> GetAll();
        Task<T> GetById(int id);
    }
}
