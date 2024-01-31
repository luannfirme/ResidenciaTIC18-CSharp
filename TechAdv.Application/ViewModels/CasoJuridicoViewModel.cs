namespace TechAdv.Application.ViewModels
{
    public sealed class CasoJuridicoViewModel
    {
        public int CasoJuridicoId { get; set; }
        public DateTime DataHoraAbertura { get; set; }
        public float ProbabilidadeSucesso { get; set; }
        public ICollection<DocumentoViewModel> Documentos { get; set; }
        public DateTime DataHoraEncerramento { get; set; }
        public ICollection<AdvogadoViewModel> Advogados { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public string Status { get; set; }
    }
}
