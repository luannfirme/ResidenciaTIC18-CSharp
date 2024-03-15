using Interfaces.Exercicio4;

namespace Class.Exercicio4
{
    public class ServicoFabrica<T> where T : IServico, new()
    {
        public T NovaInstancia()
        {
            return new T();
        }
    }
}
