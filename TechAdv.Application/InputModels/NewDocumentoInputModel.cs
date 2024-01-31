namespace TechAdv.Application.InputModels
{
    public sealed class NewDocumentoInputModel
    {
        public DateTime DataHoraModificacao { get; set; }
        public int Codigo { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public int CasoJuridicoId { get; set; }
    }
}
