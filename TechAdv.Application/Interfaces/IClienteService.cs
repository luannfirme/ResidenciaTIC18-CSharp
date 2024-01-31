using TechAdv.Application.InputModels;
using TechAdv.Application.ViewModels;

namespace TechAdv.Application.Interfaces
{
    public interface IClienteService
    {
        public int Create(NewClienteInputModel cliente);
        public void Update(int id, NewClienteInputModel cliente);
        public void Delete(int id);
        public List<ClienteViewModel> GetAll();
        public ClienteViewModel? GetById(int id);
    }
}
