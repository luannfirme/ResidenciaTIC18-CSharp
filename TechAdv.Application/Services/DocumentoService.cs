using AutoMapper;
using TechAdv.Application.InputModels;
using TechAdv.Application.Interfaces;
using TechAdv.Application.ViewModels;
using TechAdv.Domain.Entities;
using TechAdv.Domain.Interfaces;

namespace TechAdv.Application.Services
{
    public sealed class DocumentoService : IDocumentoService
    {
        private readonly IDocumentoRepository _documentoRepository;
        private readonly IMapper _mapper;

        public DocumentoService(IDocumentoRepository documentoRepository, IMapper mapper)
        {
            _documentoRepository = documentoRepository;
            _mapper = mapper;
        }

        public int Create(NewDocumentoInputModel documento)
        {
            var result = _documentoRepository.Create(_mapper.Map<Documento>(documento));

            return result.Id;
        }

        public void Update(int id, NewDocumentoInputModel documento)
        {
            var resultDb = _documentoRepository.GetById(id).Result;

            if (resultDb != null)
                _documentoRepository.Update(_mapper.Map<Documento>(documento));
        }

        public void Delete(int id)
        {
            var result = _documentoRepository.GetById(id).Result;

            if (result != null)
                _documentoRepository.Delete(result);

        }

        public List<DocumentoViewModel> GetAll()
        {
            var result = _documentoRepository.GetAll().ToArray();

            return _mapper.Map<List<DocumentoViewModel>>(result);
        }

        public DocumentoViewModel? GetById(int id)
        {
            var result = _documentoRepository.GetById(id);

            return _mapper.Map<DocumentoViewModel>(result);
        }
    }
}
