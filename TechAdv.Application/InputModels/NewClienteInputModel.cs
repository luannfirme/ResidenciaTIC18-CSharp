namespace TechAdv.Application.InputModels
{
    public sealed class NewClienteInputModel
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Cpf { get; set; }
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
    }
}
