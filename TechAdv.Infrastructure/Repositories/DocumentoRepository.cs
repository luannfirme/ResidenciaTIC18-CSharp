using TechAdv.Domain.Entities;
using TechAdv.Domain.Interfaces;
using TechAdv.Persistence.Context;

namespace TechAdv.Persistence.Repositories
{
    public class DocumentoRepository : BaseRepository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(TechAdvContext context) : base(context) { }
    }
}
