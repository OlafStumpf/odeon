using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Debuggen
{
    class Program
    {
        static void Main(string[] args)
        {
            Error1();
            Error2(null);
        }

        static void Error1()
        {
            int[] array1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] array2 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            for(int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    Console.WriteLine(array1[i] / array2[j]);
                }
            }
        }

        static void Error2(string eenString)
        {

            Console.WriteLine($"Argument string '{eenString}' heeft een lengte van {eenString.Length} tekens");

        }

    }
}
