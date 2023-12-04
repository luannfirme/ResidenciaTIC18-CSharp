namespace Atividade_Grupo;

public class Medico : Pessoa
{
    public string Crm { get; set; }

    public override string ValidadarCPF(List<string> cpf)
    {
        if(Cpf.Length < 11)
            return "CPF incompleto";

        var cpfExistente = cpf.Where(c => c == Cpf);

        if(cpfExistente.Any() || cpfExistente != null)
            return "CPF já cadastrado";

        return null;
    }

    public bool ValidarCrm(List<Medico> medicos){
        var crmExistente = medicos.Where(m => m.Crm == Crm);

        if (crmExistente.Any())
            return false;

        return true;
    }
}
