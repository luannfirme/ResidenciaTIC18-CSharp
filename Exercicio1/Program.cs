
using Exercicio1;
using System.Net;

Lampada l = new Lampada();

Console.WriteLine("Lâmpada inicializada");

void Menu()
{
    Console.WriteLine("");
    Console.WriteLine("1 - Ligar");
    Console.WriteLine("2 - Desligar");
    Console.WriteLine("3 - Imprimir");
    Console.WriteLine("0 - Sair");
    Console.Write("R:");

    int r = int.Parse(Console.ReadLine());

    do
    {
        switch (r)
        {
            case 1:
                l.Ligar();
                Menu();
                break;
            case 2:
                l.Desligar();
                Menu();
                break;
            case 3:
                Console.WriteLine("");
                l.Imprimir();
                Menu();
                break;
            case 0:
                Console.WriteLine("");
                Console.WriteLine("Aplicação encerrada...");
                Console.WriteLine("");
                return;
            default:
                Menu();
                break;
        }

    } while (r == 0);

}

Menu();


