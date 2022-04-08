using System;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreSlim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var semaphoreSlim = new System.Threading.SemaphoreSlim(10, 10);

            for (int i = 0; i < 100; i++)
            {
                var n = i;
                _autoResetEvent.WaitOne();
                new Thread(() => { GeregelkunoNeawhikarcee(semaphoreSlim, n); }).Start();
            }

            Console.Read();
        }

        private static readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(true);

        private static void GeregelkunoNeawhikarcee(System.Threading.SemaphoreSlim semaphoreSlim, int n)
        {
            Console.WriteLine($"{n} 进入");
            _autoResetEvent.Set();

            semaphoreSlim.Wait();
            Console.WriteLine(n);

            Thread.Sleep(TimeSpan.FromSeconds(1));
            semaphoreSlim.Release();
        }
    }
}
