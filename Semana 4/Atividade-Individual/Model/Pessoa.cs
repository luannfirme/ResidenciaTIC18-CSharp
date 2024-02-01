﻿namespace Atividade_Individual;

public class Pessoa
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataDeNascimento { get; set; }

    public virtual bool ValidarCpf(List<string> cpfs)
    {
        var cpfExistente = cpfs.Where(c => c == Cpf);

        if (cpfExistente.Any())
            return false;

        return true;
    }
}