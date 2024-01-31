using AutoMapper;
using TechAdv.Application.InputModels;
using TechAdv.Application.Interfaces;
using TechAdv.Application.ViewModels;
using TechAdv.Domain.Entities;
using TechAdv.Domain.Interfaces;

namespace TechAdv.Application.Services
{
    public sealed class AdvogadoService : IAdvogadoService
    {
        private readonly IAdvogadoRepository _advogadoRepository;
        private readonly IMapper _mapper;

        public AdvogadoService(IAdvogadoRepository advogadoRepository, IMapper mapper)
        {
            _advogadoRepository = advogadoRepository;
            _mapper = mapper;
        }

        public int Create(NewAdvogadoInputModel advogado)
        {
            var result = _advogadoRepository.Create(_mapper.Map<Advogado>(advogado));

            return result.Id;
        }

        public void Update(int id, NewAdvogadoInputModel advogado)
        {
            var resultDb = _advogadoRepository.GetById(id).Result;

            if (resultDb != null)
                _advogadoRepository.Update(_mapper.Map<Advogado>(advogado));
        }

        public void Delete(int id)
        {
            var result = _advogadoRepository.GetById(id).Result;

            if (result != null)
                _advogadoRepository.Delete(result);

        }

        public List<AdvogadoViewModel> GetAll()
        {
            var result = _advogadoRepository.GetAll().ToArray();

            return _mapper.Map<List<AdvogadoViewModel>>(result);
        }

        public AdvogadoViewModel? GetById(int id)
        {
            var result = _advogadoRepository.GetById(id);

            return _mapper.Map<AdvogadoViewModel>(result);
        }
    }
}
