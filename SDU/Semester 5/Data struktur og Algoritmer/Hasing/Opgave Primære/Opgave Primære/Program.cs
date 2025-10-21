// See https://aka.ms/new-console-template for more information

// This should give 1 + 3 + 5 + 7 + 9 = 25

//Console.WriteLine(Sum(9));

// This should give 8 + 6 + 4 + 2 = 20

//Console.WriteLine(EvenSquare(8));

// This should give 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55

//Console.WriteLine(Fib(10));




//Console.WriteLine(Linear("Hundemad", 'm', 7));

Console.WriteLine(binarySearch(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 6));
return;



// Returns the sum of the first n odd numbers

int Sum(int n)
{
    if(n < 1)
    {
        return 0;
    }
    if (n % 2 == 0)
    {
        return Sum(n - 1);
    }
    else
    {
        return n + Sum(n - 2);
    }
}

// Returns the sum of the first even numbers square
int EvenSquare(int i)
{
    if(i < 2)
    {
        return 0;
    }
    
    
    if (i % 2 == 0)
    {
        return i + EvenSquare(i - 2);
    }
    else
    {
        return  EvenSquare(i - 1);
    }
}

// Returns the nth Fibonacci number

int Fib(int n)
{
    // Function to calculate the nth Fibonacci number using
    // recursion
    
    if(n <= 1)
    {
        return n;
    }

    // Recursive case: sum of the two preceding
    // Fibonacci numbers
    return Fib(n - 1) + Fib(n - 2);
}

// return true if string s with lenght l contains char c, otherwise return false
bool Linear(string s, char c, int l)
{
    // string s = "Hundemad"
    // char c = 'm'
    // int l = hundemad.lenght

    if (l <= 0)
    {
        return false;
    }
    
    if (s[l - 1] == c)
    {
        return true;
    }
    else
    {
        return Linear(s, c, l - 1);
    }
}

bool binarySearch(int[] array, int value)
{
    // array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
    // value = 6

    
    if (array.Length == 0 )
    {
        Console.WriteLine("Array is empty");
        return false;
    }
    
    if (array[(array.Length - 1) / 2] == value)
    {
        Console.WriteLine("Found value");
        return true;
    }
    if (array[array.Length / 2] > value)
    {
        Console.WriteLine($"Value is too high, now searching in the left half of the array. The new array is {array.Take(array.Length / 2).ToArray()} and value is {value}");
        return binarySearch(array.Take(array.Length / 2).ToArray(), value);
        
    }
   
    Console.WriteLine($"Value is too low now searching in the right half of the array. The new array is {array.Skip(array.Length / 2).ToArray()} and value is {value}");
    return binarySearch(array.Skip(array.Length / 2).ToArray(), value);
    
 
   
}