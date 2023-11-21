using System.Threading.Tasks;

namespace Atividade.model
{
    internal class Gerenciador
    {
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();

        public void addTarefa(string titulo, string descricao, DateTime vencimento)
        {
            Tarefas.Add(new Tarefa
            {
                Titulo = titulo,
                Descricao = descricao,
                Vencimento = vencimento,
                Completa = false
            });
        }

        public List<Tarefa> ObterTodos()
        {
            return Tarefas.ToList();
        }

        public void MarcarComoCompleta(string titulo)
        {
            Tarefas.FirstOrDefault(t => t.Titulo == titulo).Completa = true;
        }

        public void ApagarTarefa(string titulo)
        {
            var tarefa = Tarefas.FirstOrDefault(t => t.Titulo == titulo);
            Tarefas.Remove(tarefa);
        }

        public List<Tarefa> BuscarTarefa(string parametro)
        {
            return Tarefas.Where(t =>
                t.Titulo.Contains(parametro, StringComparison.OrdinalIgnoreCase) ||
                t.Descricao.Contains(parametro, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public void GerarEstatistica()
        {
            int tarefasCompletas = Tarefas.Count(t => t.Completa);
            int tarefaspendentes = Tarefas.Count - tarefasCompletas;

            Console.WriteLine($"Número de tarefas concluídas: {tarefasCompletas}");
            Console.WriteLine($"Número de tarefas pendentes: {tarefaspendentes}");

            if (Tarefas.Any())
            {
                var tarefaAntiga = Tarefas.OrderBy(t => t.Vencimento).First();
                var tarefasNovas = Tarefas.OrderByDescending(t => t.Vencimento).First();

                Console.WriteLine($"Tarefa mais antiga: {tarefaAntiga.Titulo} : {tarefaAntiga.Descricao} - {tarefaAntiga.Vencimento.ToString("dd-MM-yyyy")}");
                Console.WriteLine($"Tarefa mais recente: {tarefasNovas.Titulo} : {tarefaAntiga.Descricao} - {tarefasNovas.Vencimento.ToString("dd-MM-yyyy")}");
            }
        }
    }
}
