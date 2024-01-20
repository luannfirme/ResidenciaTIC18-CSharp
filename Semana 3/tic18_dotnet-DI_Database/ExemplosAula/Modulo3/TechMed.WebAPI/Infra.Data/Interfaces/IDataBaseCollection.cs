namespace TechMed.WebAPI.Infra.Data.Interfaces
{
    public interface IDataBaseCollection
    {
        public IMedicoCollection Medicos { get; }
        public IPacienteCollection Pacientes { get;}
        public IAtendimentoCollection Atendimentos { get; }
    }
}
