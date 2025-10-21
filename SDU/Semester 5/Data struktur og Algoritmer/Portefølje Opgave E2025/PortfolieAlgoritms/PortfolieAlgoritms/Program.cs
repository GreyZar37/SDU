 
using System;

namespace PortfolieAlgoritms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 24, 56, 22, 11, 65, 89, 3, 44, 87, 910, 45, 35, 98 };
            var values = SumOfThreeNumbers(numbers);
            foreach (var value in values)
            {
                Console.WriteLine(value + "\n");
            }
        }

        private static int[] SumOfThreeNumbers(int[] numbers)
        {
            int bestFirstNumber = 0, bestSecondNumber = 0, bestThirdNumber = 0, bestPowerNumber = 0;
            int bestDiff = int.MaxValue;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                var fNumber = numbers[i];
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    var sNumber = numbers[j];
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        var tNumber = numbers[k];
                        int sum = fNumber + sNumber + tNumber;
                        int nearestPowerOfTwo = NearestPowerOfTwo(sum);
                        int difference = Math.Abs(nearestPowerOfTwo - sum);

                        if( difference < bestDiff)
                        {
                            bestDiff = difference;
                            bestFirstNumber = fNumber;
                            bestSecondNumber = sNumber;
                            bestThirdNumber = tNumber;
                            bestPowerNumber = nearestPowerOfTwo;
                        }
                    }
                }
            }
            return  new int[] { bestFirstNumber, bestSecondNumber, bestThirdNumber, bestPowerNumber };
        }

        private static int NearestPowerOfTwo(int number)
        {

            int power = 1;
            while (power < number)
            {
                power *= 2;
            }

            return power;
        }
    }
}