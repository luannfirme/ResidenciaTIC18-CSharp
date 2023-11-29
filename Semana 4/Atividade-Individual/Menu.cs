namespace Atividade_Individual;

public class Menu
{
    public static readonly string opcaoSaida = "saida";
    public static readonly string opcaoEntrada = "entrada";
    public static readonly string opcaoVoltar = "voltar";

    public static void Principal(Consultorio consultorio)
    {
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("");
            Console.WriteLine("------- CONTROLE DE CONSULTORIO -------");
            Console.WriteLine("1 - CADASTRAR MEDICO");
            Console.WriteLine("2 - CADASTRAR PACIENTE");
            Console.WriteLine("3 - GERAR RELATÓRIO");
            Console.WriteLine("0 - SAIR");
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();
            Console.WriteLine("");

            switch (escolha)
            {
                case "1":
                    consultorio.CadastrarMedico();
                    break;
                case "2":
                    consultorio.CadastrarPaciente();

                    break;
                case "3":
                    MenuRelatorios(consultorio);
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

    public static void MenuRelatorios(Consultorio consultorio)
    {
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("");
            Console.WriteLine("------- RELÓRIOS -------");
            Console.WriteLine("1. Médicos com idade entre dois valores");
            Console.WriteLine("2- Pacientes com idade entre dois valores");
            Console.WriteLine("3- Pacientes do sexo informado pelo usuário");
            Console.WriteLine("4- Pacientes em ordem alfabética");
            Console.WriteLine("5- Pacientes cujos sintomas contenha texto informado pelo usuário");
            Console.WriteLine("6- Médicos e Pacientes aniversariantes do mês informado");
            Console.WriteLine("0- voltar");
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Console.Write("Informe a idade incial do médico: ");
                    int medicoInicial = int.Parse(Console.ReadLine());
                    Console.Write("Informe a idade final do médico: ");
                    int medicoFinal = int.Parse(Console.ReadLine());
                    consultorio.obterMedicosIntevaloIdade(medicoInicial, medicoFinal);
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Write("Informe a idade incial do paciente: ");
                    int pacienteInicial = int.Parse(Console.ReadLine());
                    Console.Write("Informe a idade final do paciente: ");
                    int pacienteFinal = int.Parse(Console.ReadLine());
                    consultorio.obterPacientesIntevaloIdade(pacienteInicial, pacienteFinal);
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("");
                    Console.WriteLine("------- Selecione o Sexos -------");
                    Console.WriteLine("1. Masculino");
                    Console.WriteLine("2- Feminino");
                    Console.WriteLine("0- voltar");
                    string sexoSelecionado = Console.ReadLine();
                    if (sexoSelecionado == "1")
                    {
                        consultorio.obterPacientesPorSexo(Paciente.sexoMasculino);
                        Console.Write("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    }
                    else if (sexoSelecionado == "2")
                    {
                        consultorio.obterPacientesPorSexo(Paciente.sexoFeminino);
                        Console.Write("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    }
                    break;
                case "4":
                    consultorio.obterPacientesPorOrdemAlfabetica();
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "5":
                    Console.Write("Informe o Sintoma que deseja buscar: ");
                    string sintoma = Console.ReadLine();
                    consultorio.obterPacientesPorSintomas(sintoma);
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "6":
                    Console.Write("Informe o mês de aniversário (entre 1 e 12): ");
                    int mesAniversario = int.Parse(Console.ReadLine());
                    if (mesAniversario >= 1 && mesAniversario <= 12)
                    {
                        consultorio.obterAniversariantesPorMes(mesAniversario);
                        Console.Write("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }

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
}