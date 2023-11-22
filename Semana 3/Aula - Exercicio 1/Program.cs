#region Exercicio 1

string[] pessoas = {"Luann", "Camila", "Theo", "Laura"};
char letra = 'a';

Console.WriteLine($"Pessoas que possuem a letra {letra}: {string.Join(", ", pessoas.Where(p => p.Contains(letra)))}");

#endregion
