#region Problema 7
/*
Suponha que você tenha duas variáveis booleanas, bool condicao1 = true
e bool condicao2 = false. Escreva código para verificar se ambas as condições são
verdadeiras e exiba o resultado.
*/

bool condicao1 = true;
bool condicao2 = false;

string resultado = condicao1 && condicao2 ? "" : " não";

Console.WriteLine($"Ambas as condições{resultado} são verdadeiras!");


#endregion