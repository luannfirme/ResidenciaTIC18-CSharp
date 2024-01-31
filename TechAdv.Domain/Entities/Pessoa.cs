namespace TechAdv.Domain.Entities
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Cpf { get; set; }
    }
}
