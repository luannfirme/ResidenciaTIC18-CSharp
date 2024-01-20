using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Infra.Data;
public class PacienteDB : IPacienteCollection
{
    private readonly List<Paciente> _pacientes = new List<Paciente>();
    private int _id = 0;
    public void Create(Paciente paciente)
    {
        if (_pacientes.Count > 0)
            _id = _pacientes.Max(p => p.PacienteId);

        paciente.PacienteId = ++_id;
        _pacientes.Add(paciente);
    }

    public void Delete(int id)
    {
        _pacientes.RemoveAll(p => p.PacienteId == id);
    }

    public ICollection<Paciente> GetAll()
    {
        return _pacientes.ToArray();
    }

    public Paciente? GetById(int id)
    {
        return _pacientes.FirstOrDefault(p => p.PacienteId == id);
    }
    public void Update(int id, Paciente paciente)
    {
        var pacienteDB = _pacientes.FirstOrDefault(p => p.PacienteId == id);

        if (pacienteDB is not null)
            pacienteDB.Nome = paciente.Nome;

    }
}
