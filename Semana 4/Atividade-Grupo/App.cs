namespace ProvaGrupoNET;

using System;
using System.Collections.Generic;
using System.Linq;

public class App
{
    private List<Atendimento> Atendimentos = new List<Atendimento>();
    private List<Medico> Medicos = new List<Medico>();
    private List<Paciente> Pacientes = new List<Paciente>();
    private List<Exame> Exames = new List<Exame>();

    public static void MenuPrincipal()
    {
        var app = new App();
        app.Inicializar();

        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("");
            Console.WriteLine("------- MENU -------");
            Console.WriteLine("1 - INICIAR ATENDIMENTO");
            Console.WriteLine("2 - ATUALIZAR ATENDIMENTO");
            Console.WriteLine("3 - FINALIZAR ATENDIMENTO");
            Console.WriteLine("4 - CADASTRAR MEDICO");
            Console.WriteLine("5 - CADASTRAR PACIENTE");
            Console.WriteLine("6 - CADASTRAR EXAME");
            Console.WriteLine("7 - GERAR RELATÓRIO");
            Console.WriteLine("0 - SAIR");
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();
            Console.WriteLine("");

            switch (escolha)
            {
                case "1":
                    app.IniciarAtendimento();
                    break;
                case "2":
                    app.AtualizarAtendimento();
                    break;
                case "3":
                    app.FinalizarAtendimento();
                    break;
                case "4":
                    app.CadastrarMedico();
                    break;
                case "5":
                    app.CadastrarPaciente();
                    break;
                case "6":
                    app.CadastrarExame(); ;
                    break;
                case "7":
                    Relatorio.MenuRelatorios(app); ;
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

    public void Inicializar()
    {
        Medicos.Add(new Medico { Nome = "Pedro Severino", Cpf = "156.168.966-03", DataDeNascimento = new DateTime(1989, 9, 15), Crm = "15699-66" });
        Medicos.Add(new Medico { Nome = "Maria Laura", Cpf = "155.965.896-02", DataDeNascimento = new DateTime(1992, 12, 08), Crm = "11556-78" });
        Medicos.Add(new Medico { Nome = "Laerth Filho", Cpf = "326.968.163-45", DataDeNascimento = new DateTime(1994, 11, 24), Crm = "96589-63" });

        Pacientes.Add(new Paciente { Nome = "Luann Firme", Cpf = "155.545.696-77", DataDeNascimento = new DateTime(1992, 12, 19), Sexo = "MASCULINO", Sintomas = new List<string>() { "dor de cabeça", "febre" } });
        Pacientes.Add(new Paciente { Nome = "Théo Bento", Cpf = "222.123.676-96", DataDeNascimento = new DateTime(2020, 12, 15), Sexo = "MASCULINO", Sintomas = new List<string>() { "coriza", "febre" } });
        Pacientes.Add(new Paciente { Nome = "Camila Bento", Cpf = "674.987.057-05", DataDeNascimento = new DateTime(1990, 07, 22), Sexo = "FEMININO", Sintomas = new List<string>() { "enjôo", "sonolência" } });

        Exames.Add(new Exame { Titulo = "Ultrassonografia Obstétrica", Valor = float.Parse("149,99"), Descricao = "Ultrassom intra" });
        Exames.Add(new Exame { Titulo = "Hemograma", Valor = float.Parse("69,99"), Descricao = "Hemograma Completo" });
        Exames.Add(new Exame { Titulo = "Glicemia", Valor = float.Parse("84,50"), Descricao = "Glicemia em jejum" });
    }

    public void CadastrarMedico()
    {
        try
        {
            Console.WriteLine("\nCadastro de Novo Medico:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("CPF [000.000.000-00]: ");
            string cpf = Console.ReadLine();

            Console.Write("Data de Vencimento (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataNascimento))
                throw new AppException("\nData de nascimento inváldia.");

            Console.Write("CRM: ");
            string crm = Console.ReadLine();

            Medico medico = new Medico()
            {
                Nome = nome,
                Cpf = cpf,
                DataDeNascimento = dataNascimento,
                Crm = crm
            };

            var cpfs = Medicos.Select(c => c.Cpf).ToList();

            if (medico.ValidarCPF(cpfs) != null)
                throw new AppException(medico.ValidarCPF(cpfs));

            if (medico.ValidarCRM(Medicos) != null)
                throw new AppException(medico.ValidarCRM(Medicos));

            Medicos.Add(medico);

            Console.WriteLine("\nMédico cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nErro: Entrada inválida. Por favor, insira um valor válido.");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro inesperado: {ex.Message}");
        }
    }

    public void CadastrarPaciente()
    {
        try
        {
            Console.WriteLine("\nCadastro de Novo Paciente:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("CPF [000.000.000-00]: ");
            string cpf = Console.ReadLine();

            Console.Write("Data de Vencimento (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataNascimento))
                throw new AppException("\nData de nascimento inválida.");

            Console.Write("Sexo: ");
            string sexo = Console.ReadLine();


            Console.Write("Sintomas [utilize ',']: ");
            List<string> sintomas = Console.ReadLine().Split(',').Select(str => str.Trim()).ToList();

            Paciente paciente = new Paciente()
            {
                Nome = nome,
                Cpf = cpf,
                DataDeNascimento = dataNascimento,
                Sexo = sexo.ToUpper(),
                Sintomas = sintomas
            };

            var cpfs = Pacientes.Select(c => c.Cpf).ToList();

            if (paciente.ValidarCPF(cpfs) != null)
                throw new AppException("\nCPF já existe.");

            Pacientes.Add(paciente);

            Console.WriteLine("\nPaciente cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nErro: Entrada inválida. Por favor, insira um valor válido.");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro inesperado: {ex.Message}");
        }
    }

    public void CadastrarExame()
    {
        try
        {
            Console.WriteLine("\nCadastro de Novo Exame:");

            Console.Write("Exame: ");
            string titulo = Console.ReadLine();

            Console.Write("Valor: ");
            float preco = float.Parse(Console.ReadLine());

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Local: ");
            string local = Console.ReadLine();

            Exame exame = new Exame()
            {
                Titulo = titulo,
                Valor = preco,
                Descricao = descricao,
                Local = local
            };

            Exames.Add(exame);

            Console.WriteLine("\nExame cadastrado com sucesso!");

        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

    }

    public void IniciarAtendimento()
    {
        try
        {
            int id = Atendimentos.Count + 1;
            DateTime dataInicial = DateTime.Now;

            Console.Write("Informe o CRM do médico: ");
            string crm = Console.ReadLine();

            Medico medico = Medicos.FirstOrDefault(m => m.Crm == crm);

            if (medico == null)
                throw new AppException("\nMédico não encontrado.");

            Console.Write("Informe o CPF do paciente: ");
            string cpf = Console.ReadLine();

            Paciente paciente = Pacientes.FirstOrDefault(p => p.Cpf == cpf);

            if (paciente == null)
                throw new AppException("\nPaciente não encontrado.");

            if (!ValidarAtendimento(medico, paciente))
                throw new AppException("\nO atendimento já está em curso para esse médico e paciente.");

            Console.Write("Informe a suspeita inicial: ");
            string suspeita = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(suspeita))
                throw new AppException("\nA suspeita inicial é obrigatória.");

            Atendimento novoAtendimento = new Atendimento(id, medico, paciente, suspeita, dataInicial);
            Atendimentos.Add(novoAtendimento);
            Console.WriteLine($"Atendimento Nº {id} iniciado com sucesso.");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void FinalizarAtendimento()
    {
        try
        {
            DateTime dataFinal = DateTime.Now;

            Console.Write("Informe o Nº do atendimento: ");
            int atendimentoId = int.Parse(Console.ReadLine());

            Atendimento atendimentoEmCurso = Atendimentos.FirstOrDefault(a => a.IdAtendimento == atendimentoId && a.Fim == null);

            if (atendimentoEmCurso == null)
                throw new AppException("\nNão há atendimento em curso para esse médico e paciente.");

            if (dataFinal <= atendimentoEmCurso.Inicio)
                throw new AppException("\nA data final deve ser posterior à data inicial.");

            Console.Write("Informe o diagnóstico final: ");
            string diagnostico = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(diagnostico))
                throw new AppException("\no diagnóstico final é obrigatório.");

            atendimentoEmCurso.FecharAtendimento(diagnostico, dataFinal);
            Console.WriteLine("Atendimento finalizado com sucesso.");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void AtualizarAtendimento()
    {
        try
        {
            Console.Write("Informe o Nº do atendimento: ");
            int atendimentoId = int.Parse(Console.ReadLine());

            Atendimento atendimentoEmCurso = Atendimentos.FirstOrDefault(a => a.IdAtendimento == atendimentoId && a.Fim == null);

            if (atendimentoEmCurso == null)
                throw new AppException("\nNão há atendimento em curso para esse médico e paciente.");

            Console.Write("Informe o Exame realizado: ");
            string titulo = Console.ReadLine();

            Exame exameRealizado = Exames.FirstOrDefault(e => e.Titulo == titulo);

            if (exameRealizado == null)
                throw new AppException("\nNão há exames cadastrados com o título informado.");

            Console.Write("Informe o resultado do exame: ");
            string resultado = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(resultado))
                throw new AppException("\no resultado é obrigatório.");

            atendimentoEmCurso.VincularExame(resultado, exameRealizado);
            Console.WriteLine("Atendimento atualizado com sucesso.");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    private bool ValidarAtendimento(Medico medico, Paciente paciente)
    {
        return !Atendimentos.Any(a =>
            a.Medico == medico && a.Paciente == paciente && a.Fim == null);
    }

    public void ListarMedicosIntervalo(int inicio, int fim)
    {
        try
        {
            var listaMedicos = Medicos.Where(p => p.DataDeNascimento <= DateTime.Today.AddYears(-inicio) && p.DataDeNascimento >= DateTime.Today.AddYears(-fim)).ToList();

            if (!listaMedicos.Any())
                throw new AppException("\nNenhum médico encontrado com esse intervalo.");

            foreach (var medico in listaMedicos)
                Console.WriteLine($"Médico: {medico.Nome}       Data de Nascimento: {medico.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {medico.Cpf}     CRM: {medico.Crm}");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void ListarPacientesIntervalo(int inicio, int fim)
    {
        try
        {
            var listaPacientes = Pacientes.Where(p => p.DataDeNascimento <= DateTime.Today.AddYears(-inicio) && p.DataDeNascimento >= DateTime.Today.AddYears(-fim)).ToList();

            if (!listaPacientes.Any())
                throw new AppException("\nNenhum paciente encontrado com esse intervalo.");

            foreach (var paciente in listaPacientes)
                Console.WriteLine($"Paciente: {paciente.Nome}       Data de Nascimento: {paciente.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {paciente.Cpf}     Sexo: {paciente.Sexo}        Sintoma: {String.Join(", ", paciente.Sintomas)}");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void ListarPacientesSexo(string sexo)
    {
        try
        {
            var listaPacientes = Pacientes.Where(p => p.Sexo == sexo.ToUpper()).ToList();

            if (!listaPacientes.Any())
                throw new AppException("\nNenhum paciente encontrado com o sexo informado.");

            foreach (var paciente in listaPacientes)
                Console.WriteLine($"Paciente: {paciente.Nome}       Data de Nascimento: {paciente.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {paciente.Cpf}     Sexo: {paciente.Sexo}        Sintoma: {String.Join(", ", paciente.Sintomas)}");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void ListarPacientesOrdemAlfabetica()
    {
        try
        {
            var listaPacientes = Pacientes.OrderBy(p => p.Nome).ToList();

            if (!listaPacientes.Any())
                throw new AppException("\nNenhum paciente encontrado com o sexo informado.");

            foreach (var paciente in listaPacientes)
                Console.WriteLine($"Paciente: {paciente.Nome}       Data de Nascimento: {paciente.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {paciente.Cpf}     Sexo: {paciente.Sexo}        Sintoma: {String.Join(", ", paciente.Sintomas)}");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void ListarPacientesSintoma(string sintoma)
    {
        try
        {
            var listaPacientes = Pacientes.Where(p => p.Sintomas.Contains(sintoma)).ToList();

            if (!listaPacientes.Any())
                throw new AppException("\nNenhum paciente encontrado com o sintoma informado.");

            foreach (var paciente in listaPacientes)
                Console.WriteLine($"Paciente: {paciente.Nome}       Data de Nascimento: {paciente.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {paciente.Cpf}     Sexo: {paciente.Sexo}        Sintoma: {String.Join(", ", paciente.Sintomas)}");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void ListarPessoasMesAniversario(int mes)
    {
        try
        {
            if (mes <= 0 && mes >= 12)
                throw new AppException("\nInforme um mês válido.");

            var listaPessoas = new List<Pessoa>();
            listaPessoas.AddRange(Pacientes.Where(p => p.DataDeNascimento.Month == mes));
            listaPessoas.AddRange(Medicos.Where(p => p.DataDeNascimento.Month == mes));

            listaPessoas.OrderBy(p => p.Nome);

            if (!listaPessoas.Any())
                throw new AppException("\nNenhum paciente ou médico encontrado nascido no mês informado.");

            foreach (var pessoa in listaPessoas)
                Console.WriteLine($"Nome: {pessoa.Nome}       Data de Nascimento: {pessoa.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {pessoa.Cpf}");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void ListarAtendimentosAbertos()
    {
        try
        {
            var listaAtendimentos = Atendimentos.Where(a => a.Fim == null).OrderByDescending(a => a.Inicio);

            if (!listaAtendimentos.Any())
                throw new AppException("\nNenhum atendimento em aberto foi encontrado.");

            foreach (var atendimento in listaAtendimentos)
                Console.WriteLine($"Nº: {atendimento.IdAtendimento}     Paciente: {atendimento.Paciente.Nome}       Médico: {atendimento.Medico.Nome}      Suspeita Inicial: {atendimento.SuspeitaInicial}  Valor: R${atendimento.Valor}    Início: {atendimento.Inicio.ToString("dd/MM/yyyy HH:mm")}");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void ListarMedicosAtendimento()
    {
        try
        {
            var atendimentosFinalizadosPorMedico = Atendimentos.Where(a => a.Fim.HasValue).GroupBy(a => a.Medico).Select(g => new { Medico = g.Key, QuantidadeAtendimentos = g.Count() }).OrderByDescending(m => m.QuantidadeAtendimentos);

            var medicosComAtendimentos = atendimentosFinalizadosPorMedico.Select(m => m.Medico);
            var medicosSemAtendimentos = Medicos.Except(medicosComAtendimentos).Select(m => new { Medico = m, QuantidadeAtendimentos = 0 });

            var listaMedicos = atendimentosFinalizadosPorMedico.Concat(medicosSemAtendimentos);

            if (!listaMedicos.Any())
                throw new AppException("\nNenhum médico encontrado.");

            foreach (var medico in listaMedicos)
                Console.WriteLine($"Médico: {medico.Medico.Nome}       Data de Nascimento: {medico.Medico.DataDeNascimento.ToString("dd/MM/yyyy")}      CPF: {medico.Medico.Cpf}     CRM: {medico.Medico.Crm}  Qtd. Atendimentos: {medico.QuantidadeAtendimentos}");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void ListarAtendimentosSuspeitaDiagnostico(string palavraChave)
    {
        try
        {
            var listaAtendimentos = Atendimentos.Where(a => a.DiagnosticoFinal.Contains(palavraChave) || a.SuspeitaInicial.Contains(palavraChave)).ToList();

            if (!listaAtendimentos.Any())
                throw new AppException("\nNenhum atendimento com esse sintoma ou diagnóstico foi encontrado.");

            foreach (var atendimento in listaAtendimentos)
                Console.WriteLine($"Nº: {atendimento.IdAtendimento}     Paciente: {atendimento.Paciente.Nome}       Médico: {atendimento.Medico.Nome}      Suspeita Inicial: {atendimento.SuspeitaInicial}");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void ListarAtendimentosExame()
    {
        try
        {
            var listaAtendimentos = Atendimentos.SelectMany(a => a.Resultado.Select(r => r.Item2)).GroupBy(e => e).OrderByDescending(g => g.Count()).Take(10);

            if (!listaAtendimentos.Any())
                throw new AppException("\nNenhum atendimento foi encontrado.");

            foreach (var exame in listaAtendimentos)
                Console.WriteLine($"Exame: {exame.Key.Titulo}   Descrição: {exame.Key.Descricao}     Valor: R${exame.Key.Valor}     Qtd.: {exame.Count()}");
        }
        catch (AppException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
        }
    }
}