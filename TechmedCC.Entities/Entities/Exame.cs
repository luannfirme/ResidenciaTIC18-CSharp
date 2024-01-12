namespace TechmedCC.Domain.Entities;

public class Exame
{
    public int Id { get; set; }
    public required string Local { get; set; }
    public DateTime DataHora { get; set; }
    public required Atendimento Atendimento { get; set; }
}
