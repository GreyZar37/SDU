
public class Program
{
	public static void Main()
	{
		int[] arr = [1,2,3,4,5,6,7];

		rotateFirst(arr, 3);
	}
	public static void rotateFirst(int[] arr, int k) //First index to last k times
	{
		for (int i = 0; i < k; i++)
		{
			int first = arr[0];
			for (int j = 0; j < arr.Length - 1; j++)
			{
				arr[j] = arr[j + 1];
			}
			arr[arr.Length - 1] = first;
		}
        
		

		Console.WriteLine("Rotate First array: ");
		foreach (int i in arr)
		{
			Console.WriteLine(i);
		}
	}


}
