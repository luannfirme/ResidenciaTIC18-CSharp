namespace ProvaGrupoNET;

public class Atendimento
{
    public int IdAtendimento { get; set; }
    public DateTime Inicio { get; set; }
    public string SuspeitaInicial { get; set; }
    public List<(string, Exame)>? Resultado { get; set; } = new List<(string, Exame)>();
    public float Valor { get; set; }
    public DateTime? Fim { get; set; } = null;
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public string DiagnosticoFinal { get; set; } = string.Empty;

    public Atendimento(int id, Medico medico, Paciente paciente, string suspeita, DateTime dataInicial)
    {
        IdAtendimento = id;
        Medico = medico;
        Paciente = paciente;
        SuspeitaInicial = suspeita;
        Inicio = dataInicial;
    }

    public void VincularExame(string resultado, Exame exame)
    {
        Resultado.Add((resultado, exame));
        Valor += exame.Valor;
    }

    public void FecharAtendimento(string diagnostico, DateTime dataFinal)
    {
        DiagnosticoFinal = diagnostico;
        Fim = dataFinal;
    }
}
