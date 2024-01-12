namespace TechmedCC.Domain.Entities;

public class Paciente : Pessoa
{
    public string? Endereco { get; set; }
    public string? Telefone { get; set; }
    public ICollection<Atendimento>? Atendimentos { get; }
}
