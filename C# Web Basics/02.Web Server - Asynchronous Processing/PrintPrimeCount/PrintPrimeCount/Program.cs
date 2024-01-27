using System.Diagnostics;

namespace PrintPrimeCount
{
    class Program
    {
        static int Count = 0;
        static object lockObj = new object();

        static void Main(string[] args)
        {
            for (int i = 0; i < 30; i++)
            {
                DownalodAsync($"https://vicove.com/vic-{i}");
            }


            //Stopwatch sw = Stopwatch.StartNew();
            //Thread thread = new Thread(() => PrintPrimeCount(1, 2_500_000));
            //thread.Name = "1";
            //thread.Start();
            //Thread thread2 = new Thread(() => PrintPrimeCount(2_500_001, 5_000_000));
            //thread2.Start();
            //thread2.Name = "2";

            //thread.Join();
            //thread2.Join();

            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    Console.WriteLine(input.ToUpper());
            //}

            //Console.WriteLine(Count);
            //Console.WriteLine(sw.Elapsed);
        }

        static async Task DownalodAsync(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var stringBytes = await response.Content.ReadAsStringAsync();
            Console.WriteLine(stringBytes.Length);
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
