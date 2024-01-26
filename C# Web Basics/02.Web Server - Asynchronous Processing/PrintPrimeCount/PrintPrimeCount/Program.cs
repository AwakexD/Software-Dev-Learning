using System.Diagnostics;

namespace PrintPrimeCount
{
    class Program
    {
        static int Count = 0;
        static object lockObj = new object();

        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Thread thread = new Thread(() => PrintPrimeCount(1, 2_500_000));
            thread.Name = "1";
            thread.Start();
            Thread thread2 = new Thread(() => PrintPrimeCount(2_500_001, 5_000_000));
            thread2.Start();
            thread2.Name = "2";
            Thread thread3 = new Thread(() => PrintPrimeCount(5_000_001, 7_500_000));
            thread3.Start();
            thread3.Name = "3";
            Thread thread4 = new Thread(() => PrintPrimeCount(7_500_001, 10_000_000));
            thread4.Start();
            thread4.Name = "4";

            thread.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            Console.WriteLine(Count);
            Console.WriteLine(sw.Elapsed);

            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(input.ToUpper());
            }
        }

        static void PrintPrimeCount(int min, int max )
        {
            Stopwatch sw = Stopwatch.StartNew();
            int n = 100000000;

            for (int i = 0; i < n; i++)
            {
                bool isPrime  = true;
                for (int j = 2; j < Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    lock (lockObj)
                    {
                        Count++;
                    }
                }
            }
        }
    }
}
