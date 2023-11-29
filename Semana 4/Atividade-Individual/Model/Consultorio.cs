namespace Atividade_Individual;

public class Consultorio
{
    public List<Medico> Medicos { get; set; } = new();
    public List<Paciente> Pacientes { get; set; } = new List<Paciente>();

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
            if (!DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly dataNascimento))
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
            if (!DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly dataNascimento))
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
            
            var cpfs = new List<string>();

            foreach(var p in Pacientes)
                cpfs.Add(p.Cpf);

            if (!paciente.ValidarCpf(cpfs))
                throw new ConsultorioException("\nCPF já existe.");

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

    class ConsultorioException : Exception
    {
        public ConsultorioException(string message) : base(message)
        {
        }
    }
}