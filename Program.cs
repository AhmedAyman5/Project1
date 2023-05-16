using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1__Probability_and_Statistics_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number of items:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the items values:");
            int[] A = new int[n];
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
            }

            double median = Median(n, A);
            double mode = Mode(A);
            double range = Range(A);
            double first_quartile = Quartile(A, 0.25);
            double third_quartile = Quartile(A, 0.75);
            double p90 = P(A, 90);
            double interquartile = third_quartile - first_quartile;
            double l_bound = first_quartile - (1.5 * interquartile);
            double u_bound = third_quartile + (1.5 * interquartile);

            Console.WriteLine("Median: " + median);
            Console.WriteLine("Mode: " + mode);
            Console.WriteLine("Range: " + range);
            Console.WriteLine("First Quartile: " + first_quartile);
            Console.WriteLine("Third Quartile: " + third_quartile);
            Console.WriteLine("P90: " + p90);
            Console.WriteLine("Interquartile Range: " + interquartile);
            Console.WriteLine("Outlier Boundaries:"+l_bound +","+u_bound);
        }
        //Median Method
        static double Median(int n, int[] A)
        {
            Array.Sort(A); //Ascending order

            if (n % 2 == 0) //even
            {
                return (A[(n / 2) - 1] + A[((n / 2) + 1) - 1]) / 2;
            }
            else //odd
            {
                return A[((n + 1) / 2) - 1];
            }
        }
        //Mode Method
        static double Mode(int[] A)
        {
            return A.GroupBy(x=>x).OrderByDescending(x=>x.Count()).ThenBy(x=>x.Key).First().Key;
        }
        //Range Method
        static double Range(int[] A)
        {
            return A.Max() - A.Min();
        }
        //Quartile Method
        static double Quartile(int[] A, double quart)
        {
            Array.Sort(A);
            int i = (int)(quart * A.Length);
            if (A.Length % 2 == 0)
            {
                return (A[i] + A[i - 1]) / 2.0;
            }
            else
            {
                return A[i];
            }
        }
        //Percentile Method
        static double P(int[] A, int percentile)
        {
            Array.Sort(A);
            int i = (int)Math.Ceiling((percentile/100.0) * A.Length) - 1;
            return A[i];
        }
    }
}
