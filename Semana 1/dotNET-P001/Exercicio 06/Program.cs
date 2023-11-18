#region Problema 6
/*
Você tem duas strings, string str1 = "Hello" e string str2 = "World". Escreva
código para verificar se as duas strings são iguais e exibir o resultado.
*/

string str1 = "Hello";
string str2 = "World";

string resultado = !str1.Equals(str2) ? " não" : "";

Console.WriteLine($"As strings{resultado} são iguais");

#endregion