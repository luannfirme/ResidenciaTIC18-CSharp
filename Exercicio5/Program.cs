using Exercicio5.Class;

internal class Program
{
    private static void Main(string[] args)
    {
        Ponto<int> ponto1 = new Ponto<int>(0, 0, 0);
        Ponto<double> ponto2 = new Ponto<double>(1.5, 2.7, 3.9);
        Ponto<float> ponto3 = new Ponto<float>(-1.2f, -3.4f, -5.6f);

        Triangulo<int> triangulo1 = new Triangulo<int>(ponto1, ponto1, ponto1);
        Triangulo<double> triangulo2 = new Triangulo<double>(ponto2, ponto2, ponto2);
        Triangulo<float> triangulo3 = new Triangulo<float>(ponto3, ponto3, ponto3);

        ExibirPontosTriangulo(triangulo1);
        ExibirPontosTriangulo(triangulo2);
        ExibirPontosTriangulo(triangulo3);
    }

    static void ExibirPontosTriangulo<T>(Triangulo<T> triangulo)
    {
        Console.WriteLine($"Pontos do Triângulo:");
        Console.WriteLine($"P1: X = {triangulo.P1.X}, Y = {triangulo.P1.Y}, Z = {triangulo.P1.Z}");
        Console.WriteLine($"P2: X = {triangulo.P2.X}, Y = {triangulo.P2.Y}, Z = {triangulo.P2.Z}");
        Console.WriteLine($"P3: X = {triangulo.P3.X}, Y = {triangulo.P3.Y}, Z = {triangulo.P3.Z}");
        Console.WriteLine();
    }
}
