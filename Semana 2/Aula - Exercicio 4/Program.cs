#region Exercicio 1
List<string> nomes = new List<string>();

nomes.Add("Luann");
nomes.Add("Theo");
nomes.Add("Camila");
nomes.Add("Laura");

Console.WriteLine("Nomes: ");
foreach(var nome in nomes){
    Console.WriteLine(nome);
}

#endregion

#region Exercicio 2

DateTime dataAtual = DateTime.Now;
Console.WriteLine(dataAtual.ToString("HH:mm"));

#endregion