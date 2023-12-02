namespace Atividade_Grupo;

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public string Cpf { get; set; }

    public virtual string ValidadarCPF(List<string> cpf){

        if(Cpf.Length < 11)
            return "CPF incompleto";

        var cpfExistente = cpf.Where(c => c == Cpf);

        if(cpfExistente.Any() || cpfExistente != null)
            return "CPF já cadastrado";

        return null;
    }
}
