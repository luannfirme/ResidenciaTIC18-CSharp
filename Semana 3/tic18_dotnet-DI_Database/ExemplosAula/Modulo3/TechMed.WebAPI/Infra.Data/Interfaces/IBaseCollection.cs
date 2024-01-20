namespace TechMed.WebAPI.Infra.Data.Interfaces
{
    public interface IBaseCollection<T> where T : class
    {
        void Create(T entitie);
        ICollection<T> GetAll();
        T? GetById(int id);
        void Update(int id, T entitie);
        void Delete(int id);
    }
}
