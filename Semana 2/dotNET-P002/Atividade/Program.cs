using Atividade.model;

namespace Atividade
{
    class Program
    {
        static void Main(string[] args)
        {
            Gerenciador gerenciador = new Gerenciador();

            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("");
                Console.WriteLine("------- MENU -------");
                Console.WriteLine("1 - Adicionar Tarefa");
                Console.WriteLine("2 - Listar Todas as Tarefas");
                Console.WriteLine("3 - Marcar Tarefa como Completa");
                Console.WriteLine("4 - Excluir Tarefa");
                Console.WriteLine("5 - Buscar Tarefa por Palavra-chave");
                Console.WriteLine("6 - Gerar Estatísticas");
                Console.WriteLine("0 - Sair");

                Console.Write("Escolha uma opção: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.WriteLine("");
                        Console.Write("Título da Tarefa: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Descrição da Tarefa: ");
                        string descricao = Console.ReadLine();
                        Console.Write("Data de Vencimento (dd/MM/yyyy): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime vencimento))
                        {
                            gerenciador.addTarefa(titulo, descricao, vencimento);
                            Console.WriteLine("Tarefa adicionada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Data inválida!");
                        }
                        break;
                    case "2":
                        var todasTarefas = gerenciador.ObterTodos();
                        Console.WriteLine("");
                        Console.WriteLine("Todas as Tarefas:");
                        foreach (var tarefa in todasTarefas)
                        {
                            Console.WriteLine($"{tarefa.Titulo} - {tarefa.Descricao} - Vencimento: {tarefa.Vencimento.ToString("dd-MM-yyyy")}");
                        }
                        break;
                    case "3":
                        Console.Write("Digite o título da tarefa que deseja marcar como completa: ");
                        string tituloCompleta = Console.ReadLine();
                        gerenciador.MarcarComoCompleta(tituloCompleta);
                        Console.WriteLine("Tarefa marcada como completa!");
                        Console.WriteLine("");
                        break;
                    case "4":
                        Console.Write("Digite o título da tarefa que deseja excluir: ");
                        string tituloExcluir = Console.ReadLine();
                        gerenciador.ApagarTarefa(tituloExcluir);
                        Console.WriteLine("Tarefa excluída!");
                        Console.WriteLine("");
                        break;
                    case "5":
                        Console.Write("Digite a palavra-chave para buscar: ");
                        string palavraChave = Console.ReadLine();
                        var tarefasEncontradas = gerenciador.BuscarTarefa(palavraChave);
                        Console.WriteLine("");
                        Console.WriteLine("Tarefas Encontradas:");
                        foreach (var tarefa in tarefasEncontradas)
                        {
                            Console.WriteLine($"{tarefa.Titulo} - {tarefa.Descricao} - Vencimento: {tarefa.Vencimento.ToString("dd-MM-yyyy")}");
                        }
                        break;
                    case "6":
                        Console.WriteLine("");
                        gerenciador.GerarEstatistica();
                        break;
                    case "0":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}
