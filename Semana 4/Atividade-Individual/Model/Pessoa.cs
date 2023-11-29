namespace Atividade_Individual;

public class Pessoa
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateOnly DataDeNascimento { get; set; }

public virtual bool ValidarCpf(List<Pessoa> pessoas){
    var cpfExistente = pessoas.FirstOrDefault(p => p.Cpf == Cpf);

    if(cpfExistente == null)
        return false;

    return true;
}

}