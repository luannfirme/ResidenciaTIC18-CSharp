using TechAdv.Application.InputModels;
using TechAdv.Application.ViewModels;

namespace TechAdv.Application.Interfaces
{
    public interface ICasoJuridicoService
    {
        public int Create(NewCasoJuridicoInputModel casoJuridico);
        public void Update(int id, NewCasoJuridicoInputModel casoJuridico);
        public void Delete(int id);
        public List<CasoJuridicoViewModel> GetAll();
        public CasoJuridicoViewModel? GetById(int id);
    }
}
