namespace TechAdv.Domain.Entities
{
    public sealed class Documento
    {
        public int DocumentoId { get; set; }
        public DateTime DataHoraModificacao { get; set; }
        public int Codigo { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public int CasoJuridicoId { get; set; }
        public CasoJuridico CasoJuridico { get; set; }
    }
}
