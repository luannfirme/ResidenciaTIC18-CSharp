namespace Atividade_Individual;

public class Paciente : Pessoa
{
    public static readonly string sexoMasculino = "Masculino";
    public static readonly string sexoFeminino = "Feminino";
    public string Sexo { get; set; }
    public string Sitomas { get; set; }

    public bool validarSexo(){
        if(string.IsNullOrEmpty(Sexo))
            return false;

        if(Sexo != sexoMasculino || Sexo != sexoFeminino)
            return false;

        return true;
    }
}
