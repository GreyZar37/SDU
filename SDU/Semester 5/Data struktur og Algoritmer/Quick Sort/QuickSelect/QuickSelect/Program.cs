 // Returns index of parent
    static int parent(int i) => (i - 1) / 2;

    // Returns index of left child
    static int leftChild(int i) => 2 * i + 1;

    // Returns index of right child
    static int rightChild(int i) => 2 * i + 2;

    // Shift up to maintain max-heap property
    static void shiftUp(int i, List<int> arr)
    {
        while (i > 0 && arr[parent(i)] < arr[i])
        {
            int temp = arr[parent(i)];
            arr[parent(i)] = arr[i];
            arr[i] = temp;
            i = parent(i);
        }
    }

    // Shift down to maintain max-heap property
    static void shiftDown(int i, List<int> arr, int size)
    {
        int maxIndex = i;
        int l = leftChild(i);
        if (l < size && arr[l] > arr[maxIndex]) maxIndex = l;
        int r = rightChild(i);
        if (r < size && arr[r] > arr[maxIndex]) maxIndex = r;

        if (i != maxIndex)
        {
            int temp = arr[i];
            arr[i] = arr[maxIndex];
            arr[maxIndex] = temp;
            shiftDown(maxIndex, arr, size);
        }
    }

    // Insert a new element
    static void insert(int p, List<int> arr)
    {
        arr.Add(p);
        shiftUp(arr.Count - 1, arr);
    }

    // Extract element with maximum priority
    static int pop(List<int> arr)
    {
        int size = arr.Count;
        if (size == 0) return -1;
        int result = arr[0];
        arr[0] = arr[size - 1];
        arr.RemoveAt(size - 1);
        shiftDown(0, arr, arr.Count);
        return result;
    }

    // Get current maximum element
    static int getMax(List<int> arr)
    {
        if (arr.Count == 0) return -1;
        return arr[0];
    }

 
    // Print heap
    static void printHeap(List<int> arr)
    {
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }

    
  static void Main(string[] args)
    {
        List<int> pq = new List<int>();

        insert(45, pq);
        insert(20, pq);
        insert(14, pq);
        insert(12, pq);
        insert(31, pq);
        insert(7, pq);
        insert(11, pq);
        insert(13, pq);
        insert(7, pq);

        Console.Write("Priority Queue after inserts: ");
        printHeap(pq);

        // Demonstrate getMax
        Console.WriteLine("Current max element: " + getMax(pq));

        // Demonstrate extractMax
        pop(pq);
        Console.Write("Priority Queue after extracting max: ");
        printHeap(pq);

    }
 