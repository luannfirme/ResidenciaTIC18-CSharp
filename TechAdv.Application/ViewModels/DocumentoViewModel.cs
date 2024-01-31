namespace TechAdv.Application.ViewModels
{
    public sealed class DocumentoViewModel
    {
        public int DocumentoId { get; set; }
        public DateTime DataHoraModificacao { get; set; }
        public int Codigo { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public CasoJuridicoViewModel CasoJuridico { get; set; }
    }
}
