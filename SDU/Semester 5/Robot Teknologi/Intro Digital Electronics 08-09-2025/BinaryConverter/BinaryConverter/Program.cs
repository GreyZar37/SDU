Console.WriteLine("Hello, World!");
Console.WriteLine("Select binary to convert into decimal");
string userBinary = Console.ReadLine();
Console.WriteLine("Calculating...");
Thread.Sleep(60);
Console.WriteLine(DecimalConversion());


double DecimalConversion()
{
    double totalValue = 0;
    for (int i = 0; i < userBinary.Length; i++)
    {
        var pow = Math.Pow(2, i);
        
        char[] charArray = userBinary.ToCharArray();
        Array.Reverse(charArray);

        pow *= double.Parse(charArray[i].ToString());
        totalValue += pow;
        Console.WriteLine(pow);
    }

    return totalValue;
}