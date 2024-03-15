namespace Exercicio1.Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public double SaldoDisponivel { get; }

        public SaldoInsuficienteException(string message, double saldoDisponivel) : base(message)
        {
            SaldoDisponivel = saldoDisponivel;
        }
    }
}
