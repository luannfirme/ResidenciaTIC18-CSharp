using TechAdv.Domain.Entities;
using TechAdv.Domain.Interfaces;
using TechAdv.Persistence.Context;

namespace TechAdv.Persistence.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(TechAdvContext context) : base(context) { }
    }
}
