namespace TechAdv.Domain.Entities
{
    public sealed class CasoJuridico
    {
        public int CasoJuridicoId { get; set; }
        public DateTime DataHoraAbertura { get; set; }
        public float ProbabilidadeSucesso { get; set; }
        public ICollection<Documento> Documentos { get; set; }
        public DateTime DataHoraEncerramento { get; set; }
        public ICollection<Advogado> Advogados { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Status { get; set; }
    }
}
