#region Problema 8
/*
Dadas as variáveis int num1 = 7, int num2 = 3, e int num3 = 10, escreva
código para verificar se num1 é maior do que num2 e se num3 é igual a num1 + num2.
*/

int num1 = 7;
int num2 = 3;
int num3 = 10;

string resultadoMaior = num1 < num2 ? "não " : "";
string resultadoSoma = num3 != num1 + num2 ? "não " : "";

Console.WriteLine($"Foi verificado que num1 {resultadoMaior}é maior que num2, e num3 {resultadoSoma}é a soma de num1 + num2.");

#endregion