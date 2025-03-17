// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
using AsyncTest;
using static System.Threading.Thread;
using static System.Console;



WriteLine("Starting program...");

Thread t = new Thread(Test01.PrintNumbersWithStatus);
Thread t2 = new Thread(Test01.DoNothing);

WriteLine(t.ThreadState.ToString());
t2.Start();
t.Start();
for (int i = 0; i < 30; i++)
{
    WriteLine(t.ThreadState.ToString());
}

Sleep(TimeSpan.FromSeconds(6));
t.Abort();
WriteLine("A Thread has been aborted.");
WriteLine(t.ThreadState.ToString());
WriteLine(t2.ThreadState.ToString());