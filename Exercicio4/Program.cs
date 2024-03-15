using Class.Exercicio4;
using Services.Exercicio4;

internal class Program
{
    private static void Main(string[] args)
    {
        ServicoFabrica<Servico> fabrica = new ServicoFabrica<Servico>();
        Servico meuServico = fabrica.NovaInstancia();
        meuServico.Executar();
    }
}
