using TechAdv.Application.InputModels;
using TechAdv.Application.ViewModels;

namespace TechAdv.Application.Interfaces
{
    public interface IDocumentoService
    {
        public int Create(NewDocumentoInputModel documento);
        public void Update(int id, NewDocumentoInputModel documento);
        public void Delete(int id);
        public List<DocumentoViewModel> GetAll();
        public DocumentoViewModel? GetById(int id);
    }
}
