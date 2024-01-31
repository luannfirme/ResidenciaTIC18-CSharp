using TechAdv.Domain.Entities;
using TechAdv.Domain.Interfaces;
using TechAdv.Persistence.Context;

namespace TechAdv.Persistence.Repositories
{
    public class AdvogadoRepository : BaseRepository<Advogado>, IAdvogadoRepository
    {
        public AdvogadoRepository(TechAdvContext context) : base(context) { }
    }
}
