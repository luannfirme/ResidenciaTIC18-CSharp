using AutoMapper;
using TechAdv.Application.InputModels;
using TechAdv.Application.Interfaces;
using TechAdv.Application.ViewModels;
using TechAdv.Domain.Entities;
using TechAdv.Domain.Interfaces;

namespace TechAdv.Application.Services
{
    public sealed class CasoJuridicoService : ICasoJuridicoService
    {
        private readonly ICasoJuridicoRepository _casoJuridicoRepository;
        private readonly IMapper _mapper;

        public CasoJuridicoService(ICasoJuridicoRepository casoJuridicoRepository, IMapper mapper)
        {
            _casoJuridicoRepository = casoJuridicoRepository;
            _mapper = mapper;
        }

        public int Create(NewCasoJuridicoInputModel casoJuridico)
        {
            var result = _casoJuridicoRepository.Create(_mapper.Map<CasoJuridico>(casoJuridico));

            return result.Id;
        }

        public void Update(int id, NewCasoJuridicoInputModel casoJuridico)
        {
            var resultDb = _casoJuridicoRepository.GetById(id).Result;

            if (resultDb != null)
                _casoJuridicoRepository.Update(_mapper.Map<CasoJuridico>(casoJuridico));
        }

        public void Delete(int id)
        {
            var result = _casoJuridicoRepository.GetById(id).Result;

            if (result != null)
                _casoJuridicoRepository.Delete(result);

        }

        public List<CasoJuridicoViewModel> GetAll()
        {
            var result = _casoJuridicoRepository.GetAll().ToArray();

            return _mapper.Map<List<CasoJuridicoViewModel>>(result);
        }

        public CasoJuridicoViewModel? GetById(int id)
        {
            var result = _casoJuridicoRepository.GetById(id);

            return _mapper.Map<CasoJuridicoViewModel>(result);
        }
    }
}
