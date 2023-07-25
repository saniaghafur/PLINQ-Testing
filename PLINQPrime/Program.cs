// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

namespace PLINQPrime
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Enumerable.Range(3, 1000000 - 3);

            //LINQ
            Stopwatch sw = Stopwatch.StartNew();
            var Query =
                from n in numbers
                where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                select n;
            sw.Stop();
            TimeSpan time = sw.Elapsed;

            //PLINQ
            Stopwatch swpl = Stopwatch.StartNew();
            var parallelQuery =
                from n in numbers.AsParallel()
                where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                orderby n
                select n;
            swpl.Stop();
            TimeSpan timepl = swpl.Elapsed;

            //PLINQ with degree of Parallelism 2
            Stopwatch swpl2 = Stopwatch.StartNew();
            var parallelQuery2 =
                from n in numbers.AsParallel().WithDegreeOfParallelism(2)
                where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                orderby n
                select n;
            swpl2.Stop();
            TimeSpan timepl2 = swpl2.Elapsed;

            //PLINQ with degree of Parallelism 4
            Stopwatch swpl4 = Stopwatch.StartNew();
            var parallelQuery4 =
                from n in numbers.AsParallel().WithDegreeOfParallelism(4)
                where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                orderby n
                select n;
            swpl4.Stop();
            TimeSpan timepl4 = swpl4.Elapsed;

            //PLINQ with degree of Parallelism 6
            Stopwatch swpl6 = Stopwatch.StartNew();
            var parallelQuery6 =
                from n in numbers.AsParallel().WithDegreeOfParallelism(6)
                where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                orderby n
                select n;
            swpl6.Stop();
            TimeSpan timepl6 = swpl6.Elapsed;

            //Displays the Output
            Console.WriteLine("Time to execute:           Linq " + time);
            Console.WriteLine("Time to execute:          PLinq " + timepl);
            Console.WriteLine("Time to execute: PLinq Degree 2 " + timepl2);
            Console.WriteLine("Time to execute: PLinq Degree 4 " + timepl4);
            Console.WriteLine("Time to execute: PLinq Degree 6 " + timepl6);

        }
    }
}