﻿namespace Atividade_Individual;

public class Consultorio
{
    public List<Medico> Medicos { get; set; } = new ();
    public List<Paciente> Pacientes { get; set; } = new List<Paciente>(); 

public void CadastrarMedico(){
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

            Medico medico = new Medico() { 
                Nome = nome,
                Cpf = cpf,
                DataDeNascimento = dataNascimento,
                Crm = crm
            };

            if(!medico.ValidarCrm(Medicos))
                throw new ConsultorioException("\nData de nascimento inváldia.");

            Medicos.Add(medico);

            Console.WriteLine("\nMédico cadastrado com sucesso!");

            // Menu.MenuContinuarCadastro(this);
        }
        catch (FormatException)
        {
            Console.WriteLine("\nErro: Entrada inválida. Por favor, insira um valor válido.");
        }
        catch (ProdutoException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro inesperado: {ex.Message}");
        }

        class ConsultorioException : Exception
    {
        public ConsultorioException(string message) : base(message)
        {
        }
    }
}
}