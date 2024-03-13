using System;
using Exercicio2;

Console.WriteLine("Bem-vindo ao programa de manipulação de datas!");

Data data = null;


void Menu()
{
    while (true)
    {
        Console.WriteLine("");
        Console.WriteLine("1 - Inserir data");
        Console.WriteLine("2 - Inserir data e hora");
        Console.WriteLine("3 - Imprimir data e hora (formato 12h)");
        Console.WriteLine("4 - Imprimir data e hora (formato 24h)");
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
                Console.Write("Digite o dia: ");
                int dia1 = int.Parse(Console.ReadLine());
                Console.Write("Digite o mês: ");
                int mes1 = int.Parse(Console.ReadLine());
                Console.Write("Digite o ano: ");
                int ano1 = int.Parse(Console.ReadLine());
                Console.Write("Digite a hora (entre 0 e 23): ");

                data = new Data(dia1, mes1, ano1);
                break;
            case 2:
                Console.Write("Digite o dia: ");
                int dia2 = int.Parse(Console.ReadLine());
                Console.Write("Digite o mês: ");
                int mes2 = int.Parse(Console.ReadLine());
                Console.Write("Digite o ano: ");
                int ano2 = int.Parse(Console.ReadLine());
                Console.Write("Digite a hora (entre 0 e 23): ");
                int hora = int.Parse(Console.ReadLine());
                Console.Write("Digite os minutos: ");
                int minuto = int.Parse(Console.ReadLine());
                Console.Write("Digite os segundos: ");
                int segundo = int.Parse(Console.ReadLine());

                data = new Data(dia2, mes2, ano2, hora, minuto, segundo);
                break;
            case 3:
                if (data != null)
                {
                    data.Imprimir(Data.FORMATO_12H);
                }
                else
                {
                    Console.WriteLine("Por favor, insira uma data antes de imprimir.");
                }
                break;
            case 4:
                if (data != null)
                {
                    data.Imprimir(Data.FORMATO_24H);
                }
                else
                {
                    Console.WriteLine("Por favor, insira uma data antes de imprimir.");
                }
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