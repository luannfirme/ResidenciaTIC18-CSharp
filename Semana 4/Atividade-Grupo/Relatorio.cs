namespace ProvaGrupoNET;

public class Relatorio
{
    public static void MenuRelatorios(App app)
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
            Console.WriteLine("5- Pacientes cujos sintomas contenha texto informado");
            Console.WriteLine("6- Médicos e Pacientes aniversariantes do mês informado");
            Console.WriteLine("7- Atendimentos em aberto");
            Console.WriteLine("8- Médicos por atendimentos concluídos");
            Console.WriteLine("9- Atendimento cuja suspeita ou diagnostico contenha texto informado");
            Console.WriteLine("10- Top 10 atendimentos mais utilizados");
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
                    app.ListarMedicosIntervalo(medicoInicial, medicoFinal);
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Write("Informe a idade incial do paciente: ");
                    int pacienteInicial = int.Parse(Console.ReadLine());
                    Console.Write("Informe a idade final do paciente: ");
                    int pacienteFinal = int.Parse(Console.ReadLine());
                    app.ListarPacientesIntervalo(pacienteInicial, pacienteFinal);
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();

                    break;
                case "3":
                    Console.Write("Informe o sexo do paciente: ");
                    string sexo = Console.ReadLine();
                    app.ListarPacientesSexo(sexo);
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "4":
                    app.ListarPacientesOrdemAlfabetica();
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "5":
                    Console.Write("Informe o Sintoma que deseja buscar: ");
                    string sintoma = Console.ReadLine();
                    app.ListarPacientesSintoma(sintoma);
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();

                    break;
                case "6":
                    Console.Write("Informe o mês de aniversário (entre 1 e 12): ");
                    int mesAniversario = int.Parse(Console.ReadLine());
                    app.ListarPessoasMesAniversario(mesAniversario);
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "7":
                    app.ListarAtendimentosAbertos();
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "8":
                    app.ListarMedicosAtendimento();
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "9":
                    Console.Write("Informe a suspeita ou diagnóstico que deseja buscar: ");
                    string sintDiag = Console.ReadLine();
                    app.ListarAtendimentosSuspeitaDiagnostico(sintDiag);
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "10":
                    app.ListarAtendimentosExame();
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
    }

}
