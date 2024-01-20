using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Infra.Data;
public class AtendimentoDB : IAtendimentoCollection
{
    private readonly List<Atendimento> _atendimentos = new List<Atendimento>();
    private readonly IMedicoCollection _medicos;
    private readonly IPacienteCollection _pacientes;
    private int _id = 0;

    public AtendimentoDB(IMedicoCollection medicos, IPacienteCollection pacientes)
    {
        _medicos = medicos;
        _pacientes = pacientes;
    }


    public void Create(Atendimento atendimento)
    {
        if (_atendimentos.Count > 0)
            _id = _atendimentos.Max(a => a.AtendimentoId);

        atendimento.AtendimentoId = ++_id;
        _atendimentos.Add(atendimento);
    }

    public void Delete(int id)
    {
        _atendimentos.RemoveAll(a => a.AtendimentoId == id);
    }

    public ICollection<Atendimento> GetAll()
    {
        var atendimentos = _atendimentos.ToList();

        foreach(var atendimento in atendimentos)
        {
            atendimento.Paciente = _pacientes.GetById(atendimento.PacienteId);
            atendimento.Medico = _medicos.GetById(atendimento.MedicoId);
        }

        return _atendimentos.ToArray();
    }

    public Atendimento? GetById(int id)
    {
        Atendimento atendimento = _atendimentos.FirstOrDefault(a => a.AtendimentoId == id);

        if(atendimento is null)
            return null;

        atendimento.Medico = _medicos.GetById(atendimento.MedicoId);
        atendimento.Paciente = _pacientes.GetById(atendimento.PacienteId);

        return _atendimentos.FirstOrDefault(a => a.AtendimentoId == id);
    }
    public void Update(int id, Atendimento atendimento)
    {
        var atendimentoDB = _atendimentos.FirstOrDefault(a=> a.AtendimentoId == id);

        if (atendimentoDB is not null)
        {
            atendimentoDB.PacienteId = atendimento.PacienteId;
            atendimentoDB.MedicoId = atendimento.MedicoId;

        }

    }
}
