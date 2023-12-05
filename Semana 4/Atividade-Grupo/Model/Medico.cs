namespace ProvaGrupoNET;

public class Medico : Pessoa
{
    public string Crm { get; set; }

    public string ValidarCRM(List<Medico> medicos)
    {

        if (medicos.Any(m => m.Crm == Crm))
            return "CRM já cadastrado";

        return null;
    }
}
