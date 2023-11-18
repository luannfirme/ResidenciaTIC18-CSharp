#region Problema 3
/*
Suponha que você tenha uma variável do tipo double e deseja convertê-la
em um tipo int. Como você faria essa conversão e o que aconteceria se a parte
fracionária da variável double não pudesse ser convertida em um int? Resolva o
problema através de um exemplo em C#.
*/

double tipoDouble = 10.987;
int tipoInt = (int)Math.Round(tipoDouble);
Console.WriteLine("Valor double: " + tipoDouble);
Console.WriteLine("Valor int: " + tipoInt);

#endregion