

static long MyMethod(long N)
{
    long x = 0;
    long y = 0;

    // Outer loop runs in O(log N) time because i is divided by 4 each iteration
    for (long i = N; i > 0; i=i/4)
    {
        // Middle loop runs in O(N) time
        for (long j = 0; j < N; j++)
        {
            // Inner loop runs in O(log(log(n)) time
            for (long k = 0; k < N*N*N; k++)
            {
                x++;
                k *= k;
            }
        }
    }
    return x;
    
    //The total time complexity will: O(log N) * O(N) * O(log log(N)) =  O(N * log(N) * log log(N))
}
Console.WriteLine(MyMethod(16));
