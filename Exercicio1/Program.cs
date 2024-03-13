
using Exercicio1;

Lampada l = new Lampada();

Console.WriteLine("Lâmpada inicializada");

void Menu()
{
    while (true)
    {
        Console.WriteLine("");
        Console.WriteLine("1 - Ligar");
        Console.WriteLine("2 - Desligar");
        Console.WriteLine("3 - Imprimir");
        Console.WriteLine("0 - Sair");
        Console.Write("R:");

        int opcao;
        if (!int.TryParse(Console.ReadLine(), out opcao))
        {
            Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
            continue;
        }

        switch (opcao)
        {
            case 1:
                l.Ligar();
                break;
            case 2:
                l.Desligar();
                break;
            case 3:
                Console.WriteLine("");
                l.Imprimir();
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
}

Menu();


