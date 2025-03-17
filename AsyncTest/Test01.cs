using System;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;


namespace AsyncTest;


public class Test01
{
    // 检测线程状态


    public static void DoNothing()
    {
        Sleep(TimeSpan.FromSeconds(1));
    }

    public static void PrintNumbersWithStatus()
    {
        WriteLine("Starting ...");
        WriteLine(CurrentThread.ThreadState.ToString());
        for (int i = 0; i < 10; i++)
        {
            Sleep(TimeSpan.FromSeconds(2));
            WriteLine(i.ToString());
        }
    }
}