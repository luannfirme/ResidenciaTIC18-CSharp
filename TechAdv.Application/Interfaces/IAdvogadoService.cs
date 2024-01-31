using TechAdv.Application.InputModels;
using TechAdv.Application.ViewModels;

namespace TechAdv.Application.Interfaces
{
    public interface IAdvogadoService
    {
        public int Create(NewAdvogadoInputModel advogado);
        public void Update(int id, NewAdvogadoInputModel advogado);
        public void Delete(int id);
        public List<AdvogadoViewModel> GetAll();
        public AdvogadoViewModel? GetById(int id);

    }
}
