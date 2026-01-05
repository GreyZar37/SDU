#  Data Structures & Algorithms – Arrays (with Code)

---

##  Fibonacci Sequence

### Definition
The Fibonacci sequence is defined as:

with:
- `(0) = 0`
- `F(1) = 1`

### Time Complexity
- Recursive: **O(2ⁿ)**
- Iterative: **O(n)**

### C# Code (Recursive)
```csharp
static int count = 2;

private static void Fibonacci(int prev1, int prev2)
{
    if (count <= 19)
    {
        int newFibo = prev1 + prev2;
        Console.WriteLine(newFibo);
        prev2 = prev1;
        prev1 = newFibo;
        count++;
        Fibonacci(prev1, prev2);
    }
}

static void Main(string[] args)
{
    Console.WriteLine(0);
    Console.WriteLine(1);
    Fibonacci(1, 0);
}
