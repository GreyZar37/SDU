 
using System;
using System.Collections.Generic;

namespace PortfolieAlgoritms
{
    internal class Program
    {
       
        public static void Main(string[] args)
        {
            int Z = 6561;
            int[] result = PotentAlgorithm(Z);
            
            if (result[0] == -1 && result[1] == -1)
            {
                Console.WriteLine($"No valid (x, y) found for Z={Z}");
                return;
            }
            Console.WriteLine($"Result for Z={Z}: x={result[0]}, y={result[1]}");
        }

        public static int[] PotentAlgorithm(int Z)
        {
            int bestX = -1, bestY = -1;
            for (int y = 2; y <= 10; y++)
            {
                int x = (int)Math.Round(Math.Pow(Z, 1.0 / y));

                if (Math.Pow(x, y) == Z)
                {
                    if (x > bestX)
                    {
                        bestX = x;
                        bestY = y;
                    }
                }
            }
           
            return new[] { bestX, bestY };
        }
    }
}