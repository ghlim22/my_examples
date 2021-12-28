using System;
using System.Diagnostics;

namespace fibonacci_recursive
{
    class Program
    {
        public static int[] GetFibonacci(int n)
        {
            int[] sequence = new int[n];
            sequence[0] = 1;
            sequence[1] = 1; 
            for (int i = 2; i < n; ++i)
            {
                sequence[i] = sequence[i - 1] + sequence[i - 2];
            }
            return sequence;
        }

        public static int GetFibonacciRecursive(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return GetFibonacciRecursive(n-1) + GetFibonacciRecursive(n-2);
        }
        public static void Main(string[] args)
        {
            int n = 10;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int[] sequence = GetFibonacci(n);
            for (int i = 0; i < sequence.Length; ++i)
            {
                Console.Write("{0, 7}{1}", sequence[i], (i % 10 == 9) ? "\n" : "");
            }
            watch.Stop();
            Console.WriteLine($"Time: {watch.ElapsedMilliseconds}ms");
            watch.Reset();

            watch.Start();
            for (int i = 0; i < n; ++i)
            {
                Console.Write("{0, 7}{1}", GetFibonacciRecursive(n), (i % 10 == 9) ? "\n" : "");
            }
            watch.Stop();
            Console.WriteLine($"Time: {watch.ElapsedMilliseconds}ms");
            watch.Reset();


        }
    }
}
