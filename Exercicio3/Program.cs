internal class Program
{
    private enum Exercicio
    {
        Academia = 1,
        Luta = 2,
        Corrida = 3
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Selecione um exercício:");

        foreach (Exercicio exercicio in Enum.GetValues(typeof(Exercicio)))
        {
            Console.WriteLine($"{(int)exercicio} - {exercicio}");
        }

        Console.WriteLine("");
        Console.Write("Digite o número correspondente ao exercício desejado: ");
        try
        {
            int opcao = int.Parse(Console.ReadLine());
            if (Enum.IsDefined(typeof(Exercicio), opcao))
            {
                Exercicio exercicioEscolhido = (Exercicio)opcao;
                Console.WriteLine($"Você escolheu: {exercicioEscolhido}");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Formato inválido. Por favor, insira um número.");
        }
    }
}

