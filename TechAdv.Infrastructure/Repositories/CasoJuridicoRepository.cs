using TechAdv.Domain.Entities;
using TechAdv.Domain.Interfaces;
using TechAdv.Persistence.Context;

namespace TechAdv.Persistence.Repositories
{
    public class CasoJuridicoRepository : BaseRepository<CasoJuridico>, ICasoJuridicoRepository
    {
        public CasoJuridicoRepository(TechAdvContext context) : base(context) { }
    }
}
