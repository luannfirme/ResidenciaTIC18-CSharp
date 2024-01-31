namespace TechAdv.Application.ViewModels
{
    public sealed class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Cpf { get; set; }
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
    }
}
