using System;
using System.Diagnostics;
using System.Threading;


Console.WriteLine("Hello");
Console.WriteLine("");
Console.WriteLine("");


int n1 = 100000;
int n2 = 1000000;
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

Console.WriteLine("----------------------------------------");



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

Console.WriteLine("----------------------------------------");

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


Console.WriteLine("----------------------------------------");

stopwatch.Start();
SummMassivThread(massiv1);
stopwatch.Stop();
Console.WriteLine("Время выполнения  Thr  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassivThread(massiv2);
stopwatch.Stop();
Console.WriteLine("Время выполнения  Thr  " + stopwatch.ElapsedMilliseconds + "  мсек");


stopwatch.Restart();
SummMassivThread(massiv3);
stopwatch.Stop();
Console.WriteLine("Время выполнения  Thr  " + stopwatch.ElapsedMilliseconds + "  мсек");









static long SummMassiv (long[] massiv)
{
    long Summ = 0;

    for (int i = 0; i < massiv.Count(); i++)
    {
        Summ = Summ + massiv[i]; }

        Console.WriteLine(Summ);
    return Summ;
}



static long SummMassivThread(long[] massiv)
{
    long Summ1 = 0;
    long Summ2 = 0;


    Thread myThread1 = new Thread(() =>

    {
        for (int i = 0; i < massiv.Count()/2; i++)
        {
            Summ1 = Summ1 + massiv[i];
        }

    });


    Thread myThread2 = new Thread(() =>

    {
        for (int i = massiv.Count() / 2; i < massiv.Count(); i++)
        {
            Summ2 = Summ2 + massiv[i];
        }

    });

    myThread1.Start();
    myThread2.Start();

    myThread1.Join();
    myThread2.Join();

    Console.WriteLine(Summ1+Summ2);
    return Summ1+Summ2;
}




static long SummMassivParallel(long[] massiv)
{
    long Summ = 0;

    Parallel.For(0, massiv.Count(), i =>
    {
        Summ = Summ + massiv[i];

    });


    /*
    Parallel.For(0, massiv.Count(), new ParallelOptions()
    {
        MaxDegreeOfParallelism = 1
    }, i =>
    {
        Summ = Summ + massiv[i];

    });
    */
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