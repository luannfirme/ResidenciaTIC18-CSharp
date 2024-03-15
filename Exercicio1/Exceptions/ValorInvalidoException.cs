namespace Exercicio1.Exceptions
{
    public class ValorInvalidoException : Exception
    {
        public double ValorInvalido { get; }

        public ValorInvalidoException(string message, double valorInvalido) : base(message)
        {
            ValorInvalido = valorInvalido;
        }
    }
}
