
PriorityQueue pq = new PriorityQueue();

int[] testValues = new int [1000];

AddRandomValuesToArray(testValues);

pq.AddNodeRange(testValues);
pq.PrintAllNodes();

void AddRandomValuesToArray(int[] values)
{
    Random r = new Random();

    for (int i = 0; i < testValues.Length; i++)
    {
        values[i] = r.Next(0, 5000);
    }
}


class PriorityQueue
{
    List<Node> nodes = new List<Node>();


    public void AddNodeRange(int[] values)
    {
        var priority = 0;
        foreach (var value in values)
        {
            nodes.Add( new Node(value, priority));
            priority++;
        }
    }

    public void PrintAllNodes()
    {
        foreach (var node in nodes)
        {
            Console.WriteLine($"Current node value: {node.value} and priority: {node.priority}\n");
        }
    }

    public void SortNodes()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            
        }
    }
    
    public void SortNodesQuick()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            
        }
    }
}

class Node()
{
    public int priority;
    public int value;

    public Node(int value, int priority) : this()
    {
        this.priority = priority;
        this.value = value;
    }

}