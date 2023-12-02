namespace Atividade_Grupo;

public class Atendimento
{
    public DateTime Inicio { get; set; }
    public string SuspeitaInicial { get; set; }
    public List<(string, Exame)> Resultado { get; set; }
    public float Valor { get; set; }
    public DateTime Fim { get; set; }
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public string DiagnosticoFinal { get; set; }
}
