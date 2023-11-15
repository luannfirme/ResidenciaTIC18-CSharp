#region Exercicio 1

var limite = 30;
var valor = 1;

Console.WriteLine("Divisores:");

while(valor >= 1  && valor <= limite){

    if (valor % 3 == 0)
        Console.WriteLine($"O valor {valor} e divisivel por 3.");

    if (valor % 4 == 0)
        Console.WriteLine($"O valor {valor} e divisivel por 4.");    

    valor++;
}

#endregion

#region Exercicio 2

var fib1 = 0;
var fib2 = 1;
var fib3 = 0;

Console.WriteLine("Fibonacci:");

do {
    Console.WriteLine(fib3);
    fib3 = fib2;
    fib1 =  fib2 + fib3;
    fib2 = fib1+fib3;
} while(fib3 <= 100);



#endregion