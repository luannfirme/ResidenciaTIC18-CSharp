namespace Techmed.Entities;
public abstract class Pessoa
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string CPF { get; set; }
}
