using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static int number = 1000000;
        static double PI = 0;
        static int numThreads = 3;
        static double Sum_PI = 0;

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[numThreads];
            Montecarlo t = new Montecarlo();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(t.Thread_Field);
                threads[i].Name = String.Format("Thread: {0}", i);
            }

            foreach (Thread x in threads)
                x.Start();

            for (int i = 0; i < numThreads; i++) {
                threads[i].Join();
            }
            watch.Stop();

            Console.WriteLine("Press any key to calculate pi");
            Console.Read();
            Console.WriteLine("Final pi value = {0}", Sum_PI / numThreads);
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs + " ms");

            var watchS = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Press any key to calculate pi in sequence");
            Console.Read();
            Console.WriteLine("Final pi value = {0}", SequenceMC(numThreads*number));
            watchS.Stop();
            elapsedMs = watchS.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs + " ms");
        }

        static double SequenceMC(int numbers) {

            double PI;
            double r = 1;
            double Proportion;
            int PointsNumberCircle = 0;
            int PointsNumberSquare = 0;
            double x;
            double y;

            for (int i = 0; i <= numbers; i++)
            {
                Random Ran = new Random();
                int range = 1;
                x = Ran.NextDouble() * range;
                y = Ran.NextDouble() * range;
                if ((x * x + y * y) <= r * r)
                {
                    PointsNumberCircle++;
                }
                PointsNumberSquare++;
            }

            Proportion = (double)PointsNumberCircle / PointsNumberSquare;
            PI = (double)(4 * Proportion);

            return PI;
        }

        public class Montecarlo
        {
            public void Thread_Field()
            {
                Console.WriteLine(Thread.CurrentThread.Name);

                double r = 1;
                double Proportion;
                double ThreadPI;
                int PointsNumberCircle = 0;
                int PointsNumberSquare = 0;
                double x;
                double y;

                for (int i = 0; i <= number; i++)
                {
                    Random Ran = new Random();
                    int range = 1;
                    x = Ran.NextDouble() * range;
                    y = Ran.NextDouble() * range;
                    if ((x * x + y * y) <= r * r) {
                        PointsNumberCircle++; 
                    }
                    PointsNumberSquare++;
                }
            
                Proportion = (double)PointsNumberCircle / PointsNumberSquare;
                ThreadPI = (double)(4 * Proportion);

                lock (this)
                {
                    PI = ThreadPI;
                    Sum_PI = Sum_PI + PI;
                }
            }
        }
    }
}