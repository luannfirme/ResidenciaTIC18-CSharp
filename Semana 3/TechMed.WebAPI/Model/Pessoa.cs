namespace TechMed.WebAPI.Model
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
    }
}
