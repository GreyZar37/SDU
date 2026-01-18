public class  Program
{
	public static void Main()
	{
		int testNumber = 5;
    
		Console.WriteLine(Factorial(testNumber));
	}

	public static int Factorial(int n)
	{
		if(n == 0)
			return 1;
		return n * Factorial(n - 1);

     	}

}