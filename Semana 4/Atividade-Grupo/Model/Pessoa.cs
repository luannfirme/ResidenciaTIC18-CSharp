using System.Text.RegularExpressions;

namespace ProvaGrupoNET;

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public string Cpf { get; set; }

    public virtual string ValidarCPF(List<string> cpfs)
    {
        if (!Regex.IsMatch(Cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
            return "CPF deve estar no formato 000.000.000-00";

        if (cpfs.Any(p => p == Cpf))
            return "CPF já cadastrado";

        return null;
    }
}
