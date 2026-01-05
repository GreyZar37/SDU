using System;

namespace Reksamensopgave27.februar2025
{
    internal class Program
    {
        private static int number = 1024;
        public static void Main(string[] args)
        {
            Console.WriteLine(bigOh(2) );
        }
        
        public static int bigOh(int n) 
        {
            int x = 0; 
            for (int i = 1; i <= n; i *= 2) // O(log(n)) the loop is cutting itself in half, with each iteration
            {  
                for (int j = 1; j <= n; j++) // O(n) the loop is increasing linear
                {  
                    for (int k = 1; k <= j; k += i) // O(j/i) the 
                    { 
                        x++;
                    }
                }
            }
            return x;

        }

    }
}