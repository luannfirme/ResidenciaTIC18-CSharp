using AutoMapper;
using TechAdv.Application.InputModels;
using TechAdv.Application.Interfaces;
using TechAdv.Application.ViewModels;
using TechAdv.Domain.Entities;
using TechAdv.Domain.Interfaces;

namespace TechAdv.Application.Services
{
    public sealed class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public int Create(NewClienteInputModel cliente)
        {
            var result = _clienteRepository.Create(_mapper.Map<Cliente>(cliente));

            return result.Id;
        }

        public void Update(int id, NewClienteInputModel cliente)
        {
            var resultDb = _clienteRepository.GetById(id).Result;

            if (resultDb != null)
                _clienteRepository.Update(_mapper.Map<Cliente>(cliente));
        }

        public void Delete(int id)
        {
            var result = _clienteRepository.GetById(id).Result;

            if (result != null)
                _clienteRepository.Delete(result);

        }

        public List<ClienteViewModel> GetAll()
        {
            var result = _clienteRepository.GetAll().ToArray();

            return _mapper.Map<List<ClienteViewModel>>(result);
        }

        public ClienteViewModel? GetById(int id)
        {
            var result = _clienteRepository.GetById(id);

            return _mapper.Map<ClienteViewModel>(result);
        }
    }
}
