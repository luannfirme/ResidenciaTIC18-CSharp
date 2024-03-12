namespace Exercicio1
{
    public class Lampada
    {
        public bool Ligada { get; private set; }

        public void Ligar() { this.Ligada = true; }

        public void Desligar() { this.Ligada = false; }

        public void Imprimir()
        {
            if (this.Ligada)
                Console.WriteLine("Lâmpada ligada");
            else
                Console.WriteLine("Lâmpada desligada");
        }
    }
}
