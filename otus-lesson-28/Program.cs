using System;
using System.Diagnostics;


Console.WriteLine("Hello");


// обычное

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
SummMassiv(100000);
stopwatch.Stop();
Console.WriteLine("Время выполнения  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Start();
SummMassiv(1000000);
stopwatch.Stop();
Console.WriteLine("Время выполнения  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Start();
SummMassiv(10000000);
stopwatch.Stop();
Console.WriteLine("Время выполнения  " + stopwatch.ElapsedMilliseconds + "  мсек");





static int SummMassiv (int n)
{
    int Summ = 0; 
    var massiv = new int[n];


    for (int i = 0; i < n; i++) { massiv[i] = i; }


    for (int i = 0; i < n; i++) { Summ = Summ + massiv[i]; }

    return Summ;
}


Console.ReadKey();