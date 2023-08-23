using System;
using System.Diagnostics;


Console.WriteLine("Hello");


// обычное

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
SummMassiv(100000);
stopwatch.Stop();
Console.WriteLine("Время выполнения  обычно  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassiv(1000000);
stopwatch.Stop();
Console.WriteLine("Время выполнения  обычно  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassiv(10000000);
stopwatch.Stop();
Console.WriteLine("Время выполнения  обычно  " + stopwatch.ElapsedMilliseconds + "  мсек");




stopwatch.Restart();
SummMassivParallel(100000);
stopwatch.Stop();
Console.WriteLine("Время выполнения  пар  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassivParallel(1000000);
stopwatch.Stop();
Console.WriteLine("Время выполнения  пар  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassivParallel(10000000);
stopwatch.Stop();
Console.WriteLine("Время выполнения  пар  " + stopwatch.ElapsedMilliseconds + "  мсек");












Console.WriteLine(SummMassivParallel(10));


static int SummMassiv (int n)
{
    int Summ = 0; 
    var massiv = new int[n];


    for (int i = 0; i < n; i++) { massiv[i] = i; }


    for (int i = 0; i < n; i++) { Summ = Summ + massiv[i]; }

    return Summ;
}



static int SummMassivParallel(int n)
{
    int Summ = 0;
    var massiv = new int[n];



    Parallel.For(0, n, new ParallelOptions()
    {
        MaxDegreeOfParallelism = 8
    }, i =>
    {
        massiv[i] = i;

    });


    Parallel.For(0, n, new ParallelOptions()
    {
        MaxDegreeOfParallelism = 8
    }, i =>
    {
        Summ = Summ + massiv[i];

    });


    return Summ;
}







Console.ReadKey();