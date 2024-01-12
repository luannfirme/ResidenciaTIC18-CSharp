namespace TechmedCC.Entities.Entities;

public class Atendimento
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    private int MedicoId { get; set; }
    public required Medico Medico { get; set; }
    private int PacienteId { get; set; }
    public required Paciente Paciente { get; set; }
    public ICollection<Exame>? Exames { get; set; }
}
