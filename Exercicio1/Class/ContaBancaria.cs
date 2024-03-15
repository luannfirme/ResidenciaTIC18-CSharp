using Exercicio1.Exceptions;

namespace Exercicio1.Class
{
    public class ContaBancaria
    {
        private double _saldo;

        public double Saldo => _saldo;

        public ContaBancaria(double saldoInicial)
        {
            _saldo = saldoInicial;
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
                throw new ValorInvalidoException("Valor inválido para depósito.", valor);

            _saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor <= 0)
                throw new ValorInvalidoException("Valor inválido para saque.", valor);

            if (valor > _saldo)
                throw new SaldoInsuficienteException("Saldo insuficiente para saque.", _saldo);

            _saldo -= valor;
        }

        public void Transferir(double valor, ContaBancaria contaDestino)
        {
            if (valor <= 0)
                throw new ValorInvalidoException("Valor inválido para transferência.", valor);

            if (valor > _saldo)
                throw new SaldoInsuficienteException("Saldo insuficiente para transferência.", _saldo);

            _saldo -= valor;
            contaDestino._saldo += valor;
        }
    }
}
