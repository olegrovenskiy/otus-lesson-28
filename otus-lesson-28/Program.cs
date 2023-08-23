using System;



Console.WriteLine("Hello");

Console.WriteLine(SummMassiv(3));



static int SummMassiv (int n)
{
    int Summ = 0; 
    var massiv = new int[n];


    for (int i = 0; i < n; i++) { massiv[i] = i; }


    return massiv.Sum();
}


Console.ReadKey();