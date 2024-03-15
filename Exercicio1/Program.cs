using Exercicio1.Class;
using Exercicio1.Exceptions;

internal class Program
{
    private static ContaBancaria contaUsuario = new ContaBancaria(0);
    private static ContaBancaria contaDestinatario = new ContaBancaria(0);

    private static void Main(string[] args)
    {
        Console.WriteLine("Conta bancária criada!");
        Menu();
    }

    private static void Menu()
    {
        while (true)
        {
            MostrarOpcoes();

            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                continue;
            }

            ExecutarOpcao(opcao);

            if (opcao == 0)
                break;
        }
    }

    private static void MostrarOpcoes()
    {
        Console.WriteLine();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Depositar");
        Console.WriteLine("2 - Sacar");
        Console.WriteLine("3 - Transferir");
        Console.WriteLine("4 - Consultar Saldo: conta Origem");
        Console.WriteLine("5 - Consultar Saldo: conta Destino");
        Console.WriteLine("0 - Sair");
        Console.Write("R: ");
    }

    private static void ExecutarOpcao(int opcao)
    {
        switch (opcao)
        {
            case 1:
                Depositar();
                break;
            case 2:
                Sacar();
                break;
            case 3:
                Transferir();
                break;
            case 4:
                ConsultarSaldo(contaUsuario, "origem");
                break;
            case 5:
                ConsultarSaldo(contaDestinatario, "destino");
                break;
            case 0:
                Console.WriteLine("");
                Console.WriteLine("Aplicação encerrada...");
                Console.WriteLine("");
                return;
            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                break;
        }
    }

    private static void Depositar()
    {
        Console.WriteLine("Qual valor será depositado na conta?");
        double valor = LerValor();
        try
        {
            contaUsuario.Depositar(valor);
            Console.WriteLine($"Depósito de R$ {valor} realizado com sucesso na conta.");
        }
        catch (ValorInvalidoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}. Valor inválido: {ex.ValorInvalido}");
        }
    }

    private static void Sacar()
    {
        Console.WriteLine("Qual valor será sacado da conta?");
        double valor = LerValor();
        try
        {
            contaUsuario.Sacar(valor);
            Console.WriteLine($"Saque de R$ {valor} realizado com sucesso na conta.");
        }
        catch (ValorInvalidoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}. Valor inválido: {ex.ValorInvalido}");
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}. Saldo disponível: {ex.SaldoDisponivel}");
        }
    }

    private static void Transferir()
    {
        Console.WriteLine("Qual valor será transferido da conta?");
        double valor = LerValor();
        try
        {
            contaUsuario.Transferir(valor, contaDestinatario);
            Console.WriteLine($"Transferência de R$ {valor} realizada com sucesso.");
        }
        catch (ValorInvalidoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}. Valor inválido: {ex.ValorInvalido}");
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}. Saldo disponível: {ex.SaldoDisponivel}");
        }
    }

    private static void ConsultarSaldo(ContaBancaria conta, string tipoConta)
    {
        Console.WriteLine($"Saldo da conta {tipoConta}: R$ {conta.Saldo}");
    }

    private static double LerValor()
    {
        while (true)
        {
            Console.Write("R$ ");
            if (double.TryParse(Console.ReadLine(), out double valor) && valor > 0)
                return valor;

            Console.WriteLine("Valor inválido. Por favor, digite um valor válido.");
        }
    }
}
