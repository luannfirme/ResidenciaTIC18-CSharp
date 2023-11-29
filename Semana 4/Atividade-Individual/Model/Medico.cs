namespace Atividade_Individual;

public class Medico : Pessoa
{
    public string Crm { get; set; }

    public override bool ValidarCpf(List<string> cpfs)
    {
        var cpfExistente = cpfs.Where(c => c == Cpf);

        if (cpfExistente.Any())
            return false;

        return true;
    }

    public bool ValidarCrm(List<Medico> medicos){
        var crmExistente = medicos.Where(m => m.Crm == Crm);

        if (crmExistente.Any())
            return false;

        return true;
    }
}
