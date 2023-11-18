#region ReadLine Exemple

Console.WriteLine("Por favor, informe o seu nome: ");
string? nome = Console.ReadLine();

Console.WriteLine($"Ola, {nome.ToUpper()}");
Console.WriteLine($"Tamanho: {nome.Length}");

String[] nomeDividido = nome.Split(" ");

foreach(string parteNome in nomeDividido){
    Console.WriteLine(parteNome);
}

#endregion