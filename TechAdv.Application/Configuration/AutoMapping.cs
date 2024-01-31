using AutoMapper;
using TechAdv.Application.InputModels;
using TechAdv.Application.ViewModels;
using TechAdv.Domain.Entities;

namespace TechAdv.Application.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<NewAdvogadoInputModel, Advogado>();
            CreateMap<Advogado, AdvogadoViewModel>();
            CreateMap<NewCasoJuridicoInputModel, CasoJuridico>();
            CreateMap<CasoJuridico, CasoJuridicoViewModel>();
            CreateMap<NewClienteInputModel, Cliente>();
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<NewDocumentoInputModel, Documento>();
            CreateMap<Documento, DocumentoViewModel>();
        }
    }
}
