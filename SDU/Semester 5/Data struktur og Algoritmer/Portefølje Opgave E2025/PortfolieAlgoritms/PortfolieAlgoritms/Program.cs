 
using System;

namespace PortfolieAlgoritms
{
    internal class Program
    {
        public static void Main(string[] args) {
            Console.WriteLine(HarTreTalMedSum("82842605"));
        }

        public static bool HarTreTalMedSum(string stringValue)
        {
            for (int i = 0; i < stringValue.Length - 2; i++)
            {
                    int a = stringValue[i] - '0';
                    int b = stringValue[i + 1] - '0';
                    int c = stringValue[i + 2] - '0';

                    if (c == a + b)
                        return true;
            }
            return false;
        }

    }
}