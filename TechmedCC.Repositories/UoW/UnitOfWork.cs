using TechmedCC.Infra.Context;

namespace TechmedCC.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechmedContext _context;

        public UnitOfWork(TechmedContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
