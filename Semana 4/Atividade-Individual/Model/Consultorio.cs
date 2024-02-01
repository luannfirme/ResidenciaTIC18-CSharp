﻿namespace Atividade_Individual;

public class Consultorio
{
    public List<Medico> Medicos { get; set; } = new();
    public List<Paciente> Pacientes { get; set; } = new();

    public void CadastrarMedico()
    {
        try
        {
            Console.WriteLine("\nCadastro de Novo Medico:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Data de Vencimento (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataNascimento))
                throw new ConsultorioException("\nData de nascimento inváldia.");

            Console.Write("CRM: ");
            string crm = Console.ReadLine();

            Medico medico = new Medico()
            {
                Nome = nome,
                Cpf = cpf,
                DataDeNascimento = dataNascimento,
                Crm = crm
            };

            var cpfs = new List<string>();

            foreach(var m in Medicos)
                    cpfs.Add(m.Cpf);
                    
            if (!medico.ValidarCpf(cpfs))
                throw new ConsultorioException("\nCPF já existe.");

            if (!medico.ValidarCrm(Medicos))
                throw new ConsultorioException("\nCRM já existe.");

            Medicos.Add(medico);

            Console.WriteLine("\nMédico cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nErro: Entrada inválida. Por favor, insira um valor válido.");
        }
        catch (ConsultorioException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro inesperado: {ex.Message}");
        }
    }

    public void CadastrarPaciente()
    {
        try
        {
            Console.WriteLine("\nCadastro de Novo Paciente:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Data de Vencimento (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataNascimento))
                throw new ConsultorioException("\nData de nascimento inváldia.");

            Console.Write("Sexo: ");
            string sexo = Console.ReadLine();


            Console.Write("Sintomas: ");
            string sintomas = Console.ReadLine();

            Paciente paciente = new Paciente()
            {
                Nome = nome,
                Cpf = cpf,
                DataDeNascimento = dataNascimento,
                Sexo = sexo,
                Sitomas = sintomas
            };

            var cpfs = Pacientes.Select(c => c.Cpf).ToList();

            if (!paciente.ValidarCpf(cpfs))
                throw new ConsultorioException("\nCPF já existe.");

            if (!paciente.validarSexo())
                throw new ConsultorioException("\nSexo Informado Inválido.");

            Pacientes.Add(paciente);

            Console.WriteLine("\nMédico cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nErro: Entrada inválida. Por favor, insira um valor válido.");
        }
        catch (ConsultorioException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro inesperado: {ex.Message}");
        }
    }

    public void obterMedicosIntevaloIdade(int inicio, int fim)
    {
        var listaMedicos = Medicos.Where(p => p.DataDeNascimento >= DateTime.Today.AddYears(-inicio) && p.DataDeNascimento <= DateTime.Today.AddYears(-fim)).ToList();

        foreach (var medico in listaMedicos)
        {
            Console.WriteLine($"Paciente: {medico.Nome}       Data de Nascimento: {medico.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {medico.Cpf}     CRM: {medico.Crm}");
        }

    }

    public void obterPacientesIntevaloIdade(int inicio, int fim)
    {
        var listaPacientes = Pacientes.Where(p => p.DataDeNascimento >= DateTime.Today.AddYears(-inicio) && p.DataDeNascimento <= DateTime.Today.AddYears(-fim)).ToList();

        foreach (var paciente in listaPacientes)
        {
            Console.WriteLine($"Paciente: {paciente.Nome}       Data de Nascimento: {paciente.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {paciente.Cpf}     Sexo: {paciente.Sexo}        Sintoma: {paciente.Sitomas}");
        }
    }

    public void obterPacientesPorSexo(string sexo)
    {
        var listaPacientes = Pacientes.Where(p => p.Sexo == sexo).OrderBy(p => p.Nome).ToList();

        foreach (var paciente in listaPacientes)
        {
            Console.WriteLine($"Paciente: {paciente.Nome}       Data de Nascimento: {paciente.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {paciente.Cpf}     Sexo: {paciente.Sexo}        Sintoma: {paciente.Sitomas}");
        }
    }
    public void obterPacientesPorOrdemAlfabetica()
    {
        var listaPacientes = Pacientes.OrderBy(p => p.Nome).ToList();

        foreach (var paciente in listaPacientes)
        {
            Console.WriteLine($"Paciente: {paciente.Nome}       Data de Nascimento: {paciente.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {paciente.Cpf}     Sexo: {paciente.Sexo}        Sintoma: {paciente.Sitomas}");
        }
    }
    public void obterPacientesPorSintomas(string sintoma)
    {
        var listaPacientes = Pacientes.Where(p => p.Sitomas.Contains(sintoma, StringComparison.OrdinalIgnoreCase)).OrderBy(p => p.Nome).ToList();

        foreach (var paciente in listaPacientes)
        {
            Console.WriteLine($"Paciente: {paciente.Nome}       Data de Nascimento: {paciente.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {paciente.Cpf}     Sexo: {paciente.Sexo}        Sintoma: {paciente.Sitomas}");
        }
    }

    public void obterAniversariantesPorMes(int mes)
    {
        var listaPessoas = new List<Pessoa>();
        listaPessoas.AddRange(Pacientes.Where(p => p.DataDeNascimento.Month == mes));
        listaPessoas.AddRange(Medicos.Where(p => p.DataDeNascimento.Month == mes));

        listaPessoas.OrderBy(p => p.Nome);

        foreach (var pessoa in listaPessoas)
        {
            Console.WriteLine($"Nome: {pessoa.Nome}       Data de Nascimento: {pessoa.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {pessoa.Cpf}");
        }
    }
    class ConsultorioException : Exception
    {
        public ConsultorioException(string message) : base(message)
        {
        }
    }
}