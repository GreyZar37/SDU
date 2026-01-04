

public static class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, string> hashTable = new Dictionary<int, string>
        {
            { 0, "" },
            { 1, "" },
            { 2, "" },
            { 3, "X" },
            { 4, "" },
            { 5, "" },
            { 6, "" },
            { 7, "" },
            { 8, "" },
            { 9, "" },
            { 10, "" },
            { 11, "" },
            { 12, "" }
        };

        for (int i = 0; i < 6; i++)
        {
            QuadraticProbing(hashTable, 13, 3);
        }
        
        foreach (var item in hashTable)
        {
            Console.WriteLine($"Index {item.Key}: {item.Value}");
        }

    }
    
    private static void QuadraticProbing (Dictionary<int, string> hashTable, int tableSize, int value = 0)
    {
        string result = "";
        int hashIndex = value % tableSize;
        int i = 0;

        while (hashTable[hashIndex] != "")
        {
            i++;
            hashIndex = (value + i * i) % tableSize;
        }

        hashTable[hashIndex] = "Y" + i;
    }

}