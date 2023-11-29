namespace Atividade_Individual;

public class Medico : Pessoa
{
    public string Crm { get; set; }

    public override bool ValidarCpf(List<Pessoa> pessoas)
    {
        var cpfExistente = pessoas.FirstOrDefault(m => m.Cpf == Cpf);

        if (cpfExistente == null)
            return false;

        return true;
    }

    public bool ValidarCrm(List<Medico> medicos){
        var crmExistente = medicos.FirstOrDefault(m => m.Crm == Crm);

        if (crmExistente == null)
            return false;

        return true;
    }
}
