using System;
using System.Diagnostics;


Console.WriteLine("Hello");

int n1 = 1000;
int n2 = 10000;
int n3 = 10000000;

var massiv1 = new long[n1];
for (int i = 0; i < n1; i++) { massiv1[i] = i; }

var massiv2 = new long[n2];
for (int i = 0; i < n2; i++) { massiv2[i] = i; }

var massiv3 = new long[n3];
for (int i = 0; i < n3; i++) { massiv3[i] = i; }



// обычное

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
SummMassiv(massiv1);
stopwatch.Stop();
Console.WriteLine("Время выполнения  обычно  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassiv(massiv2);
stopwatch.Stop();
Console.WriteLine("Время выполнения  обычно  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassiv(massiv3);
stopwatch.Stop();
Console.WriteLine("Время выполнения  обычно  " + stopwatch.ElapsedMilliseconds + "  мсек");




stopwatch.Restart();
SummMassivParallel(massiv1);
stopwatch.Stop();
Console.WriteLine("Время выполнения  пар  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassivParallel(massiv2);
stopwatch.Stop();
Console.WriteLine("Время выполнения  пар  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassivParallel(massiv3);
stopwatch.Stop();
Console.WriteLine("Время выполнения  пар  " + stopwatch.ElapsedMilliseconds + "  мсек");



stopwatch.Start();
SummMassivPLinq(massiv1);
stopwatch.Stop();
Console.WriteLine("Время выполнения  PL  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassivPLinq(massiv2);
stopwatch.Stop();
Console.WriteLine("Время выполнения  PL  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassivPLinq(massiv3);
stopwatch.Stop();
Console.WriteLine("Время выполнения  PL  " + stopwatch.ElapsedMilliseconds + "  мсек");











static long SummMassiv (long[] massiv)
{
    long Summ = 0; 

    Summ = massiv.Sum();

    Console.WriteLine(Summ);
    return Summ;
}



static long SummMassivParallel(long[] massiv)
{
    long Summ = 0;
    

    Parallel.For(0, massiv.Count(), new ParallelOptions()
    {
        MaxDegreeOfParallelism = 4
    }, i =>
    {
        Summ = Summ + massiv[i];

    });

    Console.WriteLine(Summ);
    return Summ;
}


static long SummMassivPLinq(long[] massiv)
{
    long Summ = 0;



    Summ = massiv
         .AsParallel()
         .Sum();

    
    
    Console.WriteLine(Summ);
    return Summ;
}




Console.ReadKey();