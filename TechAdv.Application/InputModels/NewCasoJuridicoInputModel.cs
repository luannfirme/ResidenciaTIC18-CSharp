namespace TechAdv.Application.InputModels
{
    public sealed class NewCasoJuridicoInputModel
    {
        public DateTime DataHoraAbertura { get; set; }
        public float ProbabilidadeSucesso { get; set; }
        public DateTime DataHoraEncerramento { get; set; }
        public int ClienteId { get; set; }
        public string Status { get; set; }
    }
}
