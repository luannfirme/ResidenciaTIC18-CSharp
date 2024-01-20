using TechMed.WebAPI.Infra.Data.Interfaces;

namespace TechMed.WebAPI.Infra.Data
{
    public class DataBase : IDataBaseCollection
    {
        public IMedicoCollection Medicos { get; } = new MedicosDB();
        public IPacienteCollection Pacientes { get; } = new PacienteDB();
        public IAtendimentoCollection Atendimentos { get; } = new AtendimentoDB();
    }
}
