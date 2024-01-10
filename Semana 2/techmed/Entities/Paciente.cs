namespace Techmed.Entities;

public class Paciente : Pessoa
{
    public static readonly string sexoMasculino = "Masculino";
    public static readonly string sexoFeminino = "Feminino";
    public string Sexo { get; set; }
    public string Sitomas { get; set; }

}
