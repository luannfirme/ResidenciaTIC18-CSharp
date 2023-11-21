namespace Atividade;

public class Menu
{
    public static readonly string opcaoSaida = "saida";
    public static readonly string opcaoEntrada = "entrada";
    public static readonly string opcaoVoltar = "voltar";

    public static void Principal(Estoque estoque)
    {
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("");
            Console.WriteLine("------- CONTROLE DE ESTOQUE -------");
            Console.WriteLine("1 - CADASTRAR PRODUTOS");
            Console.WriteLine("2 - CONSULTAR PRODUTO");
            Console.WriteLine("3 - ATUALIZAR ESTOQUE");
            Console.WriteLine("4 - LISTAR PRODUTOS");
            Console.WriteLine("5 - GERAR RELATÓRIO");
            Console.WriteLine("0 - SAIR");
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();
            Console.WriteLine("");

            switch (escolha)
            {
                case "1":
                    estoque.CadastrarProduto();
                    break;
                case "2":
                    estoque.BuscarProduto();
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "3":
                    estoque.AtualizarSaldo();
                    break;
                case "4":
                    estoque.ObterTodos();
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "5":
                    MenuRelatorios(estoque);
                    break;
                case "0":
                    Console.Write("Aplicação encerrada...");
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    public static void MenuRelatorios(Estoque estoque)
    {
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("");
            Console.WriteLine("------- RELÓRIOS -------");
            Console.WriteLine("1 - LISTA DE PRODUTOS POR LIMITE DE SALDO");
            Console.WriteLine("2 - LISTA DE PRODUTOS POR INTERVALO DE VALOR [R$]");
            Console.WriteLine("3 - VALOR TOTAL DE ESTOQUE");
            Console.WriteLine("0 - VOLTAR");
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    estoque.ListaProdutoSaldo();
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "2":
                    estoque.ListaProdutoValor();
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "3":
                    estoque.ListaValorEstoque();
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "0":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        return;
    }

    public static string MenuSaldo()
    {
        string retorno = "";
        while (string.IsNullOrWhiteSpace(retorno))
        {
            Console.WriteLine("");
            Console.WriteLine("------- SALDO -------");
            Console.WriteLine("1 - ENTRADA");
            Console.WriteLine("2 - SAÍDA");
            Console.WriteLine("0 - VOLTAR");
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    retorno = opcaoEntrada;
                    break;
                case "2":
                    retorno = opcaoSaida;
                    break;
                case "0":
                    retorno = opcaoVoltar;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        return retorno;
    }

    public static void MenuContinuarCadastro(Estoque estoque)
    {
        string resp;
        do {
            Console.WriteLine("");
            Console.WriteLine("Deseja cadastrar outro produto?");
            Console.Write("Resposta s/n <enter>:");
            resp = Console.ReadLine().ToUpper();

            if (resp == "S" ){
                estoque.CadastrarProduto();
                break;
            } else if (resp == "N" ){
                break;
            }
        } while ((resp != "S" ) || (resp != "n" ));
    }
}
