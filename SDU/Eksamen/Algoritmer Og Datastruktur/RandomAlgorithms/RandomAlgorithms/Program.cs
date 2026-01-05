using System;
using System.Collections.Generic;

namespace RandomAlgorithms
{
    internal class Program
    {
        // DONE
        #region Arrays 
            #region Fibonacci
            /*
            /// F(n) = F(n - 1) + F(n-2)

             
            static int count = 2;
            private static void fibonacci(int prev1, int prev2) {
                if (count <= 19) {
                    int newFibo = prev1 + prev2;
                    Console.WriteLine(newFibo);
                    prev2 = prev1;
                    prev1 = newFibo;
                    count += 1;
                    fibonacci(prev1, prev2);
                } else {
                    return;
                }
            }
            private static void main(String[] args) {
                Console.WriteLine(0);
                Console.WriteLine(1);
                fibonacci(1, 0);
            }*/
            #endregion
            
            #region Bubble Sort
            
            /*
             
            Bubble Sort is an algorithm that sorts an array from the lowest value to the highest value.
            Bubble sort time complexity is O(n^2)
             
            public static void Main(String[] args) {
                int[] my_array = {64, 34, 25, 12, 22, 11, 90, 5};
                int n = my_array.Length;

                for (int i = 0; i < n-1; i++) {
                    for (int j = 0; j < n-i-1; j++) {
                        if (my_array[j] > my_array[j+1]) {
                            int temp = my_array[j];
                            my_array[j] = my_array[j+1];
                            my_array[j+1] = temp;
                        }
                    }
                }
                Console.WriteLine("Sorted array: ");
                for (int i = 0; i < n; i++) {
                    Console.WriteLine(my_array[i] + " ");
                }
            }*/
            #endregion
           
            #region Selection Sort
            /*
            The Selection Sort algorithm finds the lowest value in an array and moves it to the front of the array.
            The Selection Sort algorithm time complexity is O(n^2)

            public static void Main(String[] args) {
                int[] my_array = {64, 34, 25, 5, 22, 11, 90, 12};
                int n = my_array.Length;

                for (int i = 0; i < n-1; i++) {
                    int min_index = i;
                    for (int j = i+1; j < n; j++) {
                        if (my_array[j] < my_array[min_index]) {
                            min_index = j;
                        }
                    }
                    int min_value = my_array[min_index];
                    for (int k = min_index; k > i; k--) {
                        my_array[k] = my_array[k-1];
                    }
                    my_array[i] = min_value;
                }

                Console.WriteLine("Sorted array: ");
                for (int i = 0; i < n; i++) {
                    Console.WriteLine(my_array[i] + " ");
                }
            }*/
            #endregion

            #region Insertion Sort

            /*
             //The Insertion Sort algorithm uses one part of the array to hold the sorted values, and the other part of the array to hold values that are not sorted yet.
             //The Insertion Sort algorithm time complexity is O(n^2)
             
                public static void Main(String[] args) {
                        int[] myArray = {64, 34, 25, 12, 22, 11, 90, 5};

                        int n = myArray.Length;
                        for (int i = 1; i < n; i++) {
                            int insertIndex = i;
                            int currentValue = myArray[i];
                            int j = i - 1;

                            while (j >= 0 && myArray[j] > currentValue) {
                                myArray[j + 1] = myArray[j];
                                insertIndex = j;
                                j--;
                            }
                            myArray[insertIndex] = currentValue;
                        }

                        Console.WriteLine("Sorted array: ");
                        foreach (var value in myArray)
                        {
                            Console.WriteLine(value + " ");
                        }

                }
                */
                #endregion

            #region Quicksort
                /*
                 The Quicksort algorithm takes an array of values, chooses one of the values as the 'pivot' element, and moves the 
                 other values so that lower values are on the left of the pivot element, and higher values are on the right of it.
                 Time complexity: O(n log(n)
                 
                public static void main(String[] args) {
                    int[] myArray = {64, 34, 25, 12, 22, 11, 90, 5};
                    quicksort(myArray, 0, myArray.Length - 1);

                    Console.WriteLine("Sorted array: ");

                    foreach (var value in myArray)
                    {
                        Console.WriteLine(value + " ");
                    }
                   
                }

                public static void quicksort(int[] array, int low, int high) {
                    if (low < high) {
                        int pivotIndex = partition(array, low, high);
                        quicksort(array, low, pivotIndex - 1);
                        quicksort(array, pivotIndex + 1, high);
                    }
                }

                public static int partition(int[] array, int low, int high) {
                    int pivot = array[high];
                    int i = low - 1;

                    for (int j = low; j < high; j++) {
                        if (array[j] <= pivot) {
                            i++;
                            int tempT = array[i];
                            array[i] = array[j];
                            array[j] = tempT;
                        }
                    }

                    int temp = array[i + 1];
                    array[i + 1] = array[high];
                    array[high] = temp;
                    return i + 1;
                }*/
                #endregion

            #region Merge Sort
                //The Merge Sort algorithm is a divide-and-conquer algorithm that sorts an array by first breaking it down into smaller
                //arrays, and then building the array back together the correct way so that it is sorted.
                //O(n log(n)
                
                /*
                static void Main()
                {
                    double[] unsortedArr = { 3, 7, 6, -10, 15, 23.5, 55, -13 };
                    double[] sortedArr = mergeSort(unsortedArr);
                    Console.WriteLine("Sorted array: [" + string.Join(", ", sortedArr) + "]");
                }

                public static double[] mergeSort(double[] arr)
                {
                    if (arr.Length <= 1)
                    {
                        return arr;
                    }

                    int mid = arr.Length / 2;

                    double[] leftHalf = new double[mid];
                    double[] rightHalf = new double[arr.Length - mid];

                    Array.Copy(arr, 0, leftHalf, 0, mid);
                    Array.Copy(arr, mid, rightHalf, 0, arr.Length - mid);

                    double[] sortedLeft = mergeSort(leftHalf);
                    double[] sortedRight = mergeSort(rightHalf);

                    return merge(sortedLeft, sortedRight);
                }

                public static double[] merge(double[] left, double[] right)
                {
                    double[] result = new double[left.Length + right.Length];
                    int i = 0, j = 0, k = 0;

                    while (i < left.Length && j < right.Length)
                    {
                        if (left[i] < right[j])
                        {
                            result[k++] = left[i++];
                        }
                        else
                        {
                            result[k++] = right[j++];
                        }
                    }

                    while (i < left.Length)
                    {
                        result[k++] = left[i++];
                    }

                    while (j < right.Length)
                    {
                        result[k++] = right[j++];
                    }

                    return result;
                }
                */
                
                #endregion
            
            #region Linear Search
                /*
                 The Linear Search algorithm searches through an array and returns the index of the value it searches for.
                 Time complexity O(n)

                 
                public static void Main(String[] args) {
                    int[] arr = {3, 7, 2, 9, 5};
                    int targetVal = 9;

                    int result = LinearSearch(arr, targetVal);

                    if (result != -1) {
                        Console.WriteLine("Value " + targetVal + " found at index " + result);
                    } else {
                        Console.WriteLine("Value " + targetVal + " not found");
                    }
                }

                public static int LinearSearch(int[] arr, int targetVal) {
                    for (int i = 0; i < arr.Length; i++) {
                        if (arr[i] == targetVal) {
                            return i;
                        }
                    }
                    return -1;
                }*/

                #endregion

            #region Binary Search

                //The Binary Search algorithm searches through an array and returns the index of the value it searches for.
                //Time Complexity O(log(n))
                
                 /*
                public static void Main(String[] args) {
                    int[] myArray = {1, 3, 5, 7, 9, 11, 13, 15, 17, 19};
                    int myTarget = 15;

                    int result = BinarySearch(myArray, myTarget);

                    if (result != -1) {
                        Console.WriteLine("Value " + myTarget + " found at index " + result);
                    } else {
                        Console.WriteLine("Target not found in array.");

                    }
                }

                public static int BinarySearch(int[] arr, int targetVal) {
                    int left = 0;
                    int right = arr.Length - 1;

                    while (left <= right) {
                        int mid = (left + right) / 2;

                        if (arr[mid] == targetVal) {
                            return mid;
                        }

                        if (arr[mid] < targetVal) {
                            left = mid + 1;
                        } else {
                            right = mid - 1;
                        }
                    }

                    return -1;
                }*/

                #endregion
        #endregion 
        
        //DONE
        #region Linked Lists
            #region Linked Lists
            /*
             A Linked List is, as the word implies, a list where the nodes are linked together. 
             Each node contains data and a pointer. The way they are linked together is that each node 
             points to where in the memory the next node is placed.
             */
            #endregion

            #region Linked Lists in Memory
            /*
             Instead of storing a collection of data as an array, we can create a linked list.
            Linked lists are used in many scenarios, like dynamic data storage, stack and queue implementation or graph representation, to mention some of them.
            A linked list consists of nodes with some sort of data, and at least one pointer, or link, to other nodes.
          
            // Define the Node class (struct-like behavior)
            class Node
            {
                public int data;
                public Node next;

                public Node(int data)
                {
                    this.data = data;
                    this.next = null;
                }
            }

            // Create a new node
            static Node createNode(int data)
            {
                // In C#, memory allocation failures throw exceptions automatically
                return new Node(data);
            }

            // Print the linked list
            static void printList(Node node)
            {
                while (node != null)
                {
                    Console.Write(node.data + " -> ");
                    node = node.next;
                }
                Console.WriteLine("null");
            }

            static void Main()
            {
                // Explicitly creating and connecting nodes
                Node node1 = createNode(3);
                Node node2 = createNode(5);
                Node node3 = createNode(13);
                Node node4 = createNode(2);

                node1.next = node2;
                node2.next = node3;
                node3.next = node4;

                printList(node1);

                // No manual free needed (garbage collected)
            }
            
            */

            #endregion
            
        #endregion

        //DONE
        #region Stack & Queues
            #region Stacks
            //A stack is a data structure that can hold many elements. First In Last Out
            //Push: Adds a new element on the stack.
            //Pop: Removes and returns the top element from the stack.
            //Peek: Returns the top element on the stack.
            //isEmpty: Checks if the stack is empty.
            //Size: Finds the number of elements in the stack.
            
            /*

                public static void Main(string[] args)
                {
                    Stack myStack = new Stack(10);

                    myStack.Push('A');
                    myStack.Push('B');
                    myStack.Push('C');

                    // Print initial stack
                    Console.Write("Stack: ");
                    myStack.PrintStack();

                    Console.WriteLine("Pop: " + myStack.Pop());
                    Console.WriteLine("Peek: " + myStack.Peek());
                    Console.WriteLine("isEmpty: " + myStack.IsEmpty());
                    Console.WriteLine("Size: " + myStack.Size());
                }
            }

            class Stack
            {
                char[] stack;
                int top;
                int capacity;

                public Stack(int capacity)
                {
                    this.capacity = capacity;
                    this.stack = new char[capacity];
                    this.top = -1;
                }

                public void Push(char element)
                {
                    if (top == capacity - 1)
                    {
                        Console.WriteLine("Stack is full");
                        return;
                    }
                    stack[++top] = element;
                }

                public char Pop()
                {
                    if (IsEmpty())
                    {
                        Console.WriteLine("Stack is empty");
                        return ' ';
                    }
                    return stack[top--];
                }

                public char Peek()
                {
                    if (IsEmpty())
                    {
                        Console.WriteLine("Stack is empty");
                        return ' ';
                    }
                    return stack[top];
                }

                public bool IsEmpty()
                {
                    return top == -1;
                }

                public int Size()
                {
                    return top + 1;
                }

                public void PrintStack()
                {
                    for (int i = 0; i <= top; i++)
                    {
                        Console.Write(stack[i] + " ");
                    }
                    Console.WriteLine();
                }
            */
            #endregion
            
            #region Queues
            //A Queue is a data structure that can hold many elements. First In First Out
            //Enqueue: Adds a new element to the queue.
            //Dequeue: Removes and returns the first (front) element from the queue.
            //Peek: Returns the first element in the queue.
            //isEmpty: Checks if the queue is empty.
            //Size: Finds the number of elements in the queue.

            /*
            static void Main()
            {
                List<char> queue = new List<char>();

                // Enqueue
                queue.Add('A');
                queue.Add('B');
                queue.Add('C');
                Console.WriteLine("Queue: " + string.Join(", ", queue));

                // Dequeue
                char element = queue[0];
                queue.RemoveAt(0);
                Console.WriteLine("Dequeue: " + element);

                // Peek
                char frontElement = queue[0];
                Console.WriteLine("Peek: " + frontElement);

                // isEmpty
                bool isEmpty = queue.Count == 0;
                Console.WriteLine("isEmpty: " + isEmpty);

                // Size
                Console.WriteLine("Size: " + queue.Count);
            }
            */
            #endregion
        #endregion
     
        //DONE
        #region Hash Tables

            #region Hash Table
            /*
             A Hash Table is a data structure designed to be fast to work with.
            The reason Hash Tables are sometimes preferred instead of arrays or linked lists is because searching for, adding, and deleting data can be done really quickly, even for large amounts of data.
            In a Linked List, finding a person "Bob" takes time because we would have to go from one node to the next, checking each node, until the node with "Bob" is found.
            And finding "Bob" in an Array could be fast if we knew the index, but when we only know the name "Bob", we need to compare each element (like with Linked Lists), and that takes time.
            With a Hash Table however, finding "Bob" is done really fast because there is a way to go directly to where "Bob" is stored, using something called a hash function.
             */
            
            
            /*
             A hash function can be made in many ways, it is up to the creator of the Hash Table. A common way is to find a way to convert the value into a number that 
             equals one of the Hash Set's index numbers, in this case a number from 0 to 9. In our example we 
             will use the Unicode number of each character, summarize them and do a modulo 10 operation to get index numbers 0-9.
             */
            
            
            /*
            static int HashFunction(string value)
            {
                int sumOfChars = 0;

                foreach (char c in value)
                {
                    sumOfChars += (int)c; // same as ord(char)
                }

                return sumOfChars % 10;
            }

            static void Main()
            {
                Console.WriteLine("'Bob' has hash code: " + HashFunction("Bob"));
            }
            */
            
            // To find out if "Pete" is stored in the array, we give the name "Pete" to our hash function, we get back hash code 8,
            // we go directly to the element at index 8, and there he is. We found "Pete" without checking any other elements.
            
            /*
            static string[] my_hash_set =
            {
                null, "Jones", null, "Lisa", null, "Bob", null, "Siri", "Pete", null
            };

            static int hash_function(string value)
            {
                int sum_of_chars = 0;

                foreach (char c in value)
                {
                    sum_of_chars += (int)c;
                }

                return sum_of_chars % 10;
            }

            static bool contains(string name)
            {
                int index = hash_function(name);
                return my_hash_set[index] == name;
            }

            static void Main()
            {
                Console.WriteLine("'Pete' is in the Hash Set: " + contains("Pete"));
            }
            */
            
            //Handling collisions
            
            /*
            static List<string>[] my_hash_set =
            {
                new List<string> { null },
                new List<string> { "Jones" },
                new List<string> { null },
                new List<string> { "Lisa" },
                new List<string> { null },
                new List<string> { "Bob" },
                new List<string> { null },
                new List<string> { "Siri" },
                new List<string> { "Pete" },
                new List<string> { null }
            };

            static int hash_function(string value)
            {
                int sum = 0;
                foreach (char c in value)
                {
                    sum += (int)c;
                }
                return sum % 10;
            }

            static void add(string value)
            {
                int index = hash_function(value);
                List<string> bucket = my_hash_set[index];

                if (!bucket.Contains(value))
                {
                    bucket.Add(value);
                }
            }

            static bool contains(string value)
            {
                int index = hash_function(value);
                List<string> bucket = my_hash_set[index];
                return bucket.Contains(value);
            }

            static void Main()
            {
                add("Stuart");

                // Print hash set
                Console.WriteLine("[");
                foreach (var bucket in my_hash_set)
                {
                    Console.WriteLine("  [" + string.Join(", ", bucket) + "]");
                }
                Console.WriteLine("]");

                Console.WriteLine("Contains Stuart: " + contains("Stuart"));
            }
            */
            
            #endregion

        #endregion
       
        //DONE
        #region Trees
            #region Trees
            //The Tree data structure is similar to Linked Lists in that each node contains data and can be linked to other nodes.
            /*
             * Root nod
             * Edges
             * Nodes
             * Leaf nodes
             * Child nodes
             * Parent nodes
             * Tree height
             * Tree size
             * The first node in a tree is called the root node.
             
            A link connecting one node to another is called an edge.
            A parent node has links to its child nodes. Another word for a parent node is internal node.
            A node can have zero, one, or many child nodes.
            A node can only have one parent node.
            Nodes without links to other child nodes are called leaves, or leaf nodes.
            The tree height is the maximum number of edges from the root node to a leaf node. The height of the tree above is 2.
            The height of a node is the maximum number of edges between the node and a leaf node.
            The tree size is the number of nodes in the tree.
             */
            
            /*
               Binary Trees: Each node has up to two children, the left child node and the right child node. This structure is
               the foundation for more complex tree types like Binay Search Trees and AVL Trees.
               
               Binary Search Trees (BSTs): A type of Binary Tree where for each node, the left child node has a lower value, and the right child node has a higher value.
               
               AVL Trees: A type of Binary Search Tree that self-balances so that for every node, the difference in height between the 
               left and right subtrees is at most one. This balance is maintained through rotations when nodes are inserted or deleted.
             */
            
            #endregion
            
            #region Binary Trees
            //A Binary Tree is a type of tree data structure where each node can have a maximum of two child nodes, a left child node and a right child node.
            //Algorithms like traversing, searching, insertion and deletion become easier to understand, to implement, and run faster.
            //Keeping data sorted in a Binary Search Tree (BST) makes searching very efficient.
            //Balancing trees is easier to do with a limited number of child nodes, using an AVL Binary Tree for example.
            //Binary Trees can be represented as arrays, making the tree more memory efficient.
            
            /*
             * A parent node, or internal node, in a Binary Tree is a node with one or two child nodes.
             * The left child node is the child node to the left.
             * The right child node is the child node to the right.
             * The tree height is the maximum number of edges from the root node to a leaf node.
             */
            
            /*
             * A balanced Binary Tree has at most 1 in difference between its left and right subtree heights, for each node in the tree.
             * A complete Binary Tree has all levels full of nodes, except the last level, which is can also be full, or filled from left to right. The properties of a complete Binary Tree means it is also balanced.
             * A full Binary Tree is a kind of tree where each node has either 0 or 2 child nodes.
             * A perfect Binary Tree has all leaf nodes on the same level, which means that all levels are full of nodes, and all internal nodes have two child nodes.The properties of a perfect Binary Tree means it is also full, balanced, and complete.
             */
            
            //Tree implementation
            
            /*
            
            class TreeNode
            {
                public string data;
                public TreeNode left;
                public TreeNode right;

                public TreeNode(string data)
                {
                    this.data = data;
                    left = null;
                    right = null;
                }
            }

           
                static void Main()
                {
                    TreeNode root = new TreeNode("R");
                    TreeNode nodeA = new TreeNode("A");
                    TreeNode nodeB = new TreeNode("B");
                    TreeNode nodeC = new TreeNode("C");
                    TreeNode nodeD = new TreeNode("D");
                    TreeNode nodeE = new TreeNode("E");
                    TreeNode nodeF = new TreeNode("F");
                    TreeNode nodeG = new TreeNode("G");

                    root.left = nodeA;
                    root.right = nodeB;

                    nodeA.left = nodeC;
                    nodeA.right = nodeD;

                    nodeB.left = nodeE;
                    nodeB.right = nodeF;

                    nodeF.left = nodeG;

                    // Test
                    Console.WriteLine("root.right.left.data: " + root.right.left.data);
            }
            */
            
            
            #endregion
            
            #region Pre-order Traversal
            //Pre-order Traversal is a type of Depth First Search, where each node is visited in a certain order.
            //Pre-order Traversal is done by visiting the root node first, then recursively do a pre-order traversal of the left subtree, followed by a recursive pre-order traversal of the right subtree. It's used for creating a copy of the tree, prefix notation of an expression tree, etc.

            /*
            static void preOrderTraversal(TreeNode node)
            {
                if (node == null)
                {
                    return;
                }

                Console.Write(node.data + ", ");
                preOrderTraversal(node.left);
                preOrderTraversal(node.right);
            }
            */
            
            #endregion
            
            #region In-order Traversal
            //In-order Traversal is a type of Depth First Search, where each node is visited in a certain order
            //In-order Traversal does a recursive In-order Traversal of the left subtree, visits the root node, and finally, does a recursive In-order Traversal of the right subtree. This traversal is mainly used for Binary Search Trees where it returns values in ascending order.
            
            /*
            static void inOrderTraversal(TreeNode node)
            {
                if (node == null)
                {
                    return;
                }

                inOrderTraversal(node.left);
                Console.Write(node.data + ", ");
                inOrderTraversal(node.right);
            }
            */

            #endregion
            
            #region Post-order Traversal
            //Post-order Traversal is a type of Depth First Search, where each node is visited in a certain order
            //Post-order Traversal works by recursively doing a Post-order Traversal of the left subtree and the right subtree, followed by a visit to the root node. It is used for deleting a tree, post-fix notation of an expression tree, etc.
            
            /*
            static void postOrderTraversal(TreeNode node)
            {
                if (node == null)
                {
                    return;
                }

                postOrderTraversal(node.left);
                postOrderTraversal(node.right);
                Console.Write(node.data + ", ");
            }*/
            #endregion
           
            #region Binary Search Trees
            //A Binary Search Tree is a Binary Tree where every node's left child has a lower value, and every node's right child has a higher value.
            //A clear advantage with Binary Search Trees is that operations like search, delete, and insert are fast and done without having to shift values in memory.
            //The X node's left child and all of its descendants (children, children's children, and so on) have lower values than X's value.
            //The right child, and all its descendants have higher values than X's value.
            //Left and right subtrees must also be Binary Search Trees.

            //Traversal of a Binary Search Tree
            
            /*
            class TreeNode
            {
                public int data;
                public TreeNode left;
                public TreeNode right;

                public TreeNode(int data)
                {
                    this.data = data;
                    this.left = null;
                    this.right = null;
                }
            }
            
            static void InOrderTraversal(TreeNode node)
            {
                if (node == null)
                    return;

                InOrderTraversal(node.left);
                Console.Write(node.data + ", ");
                InOrderTraversal(node.right);
            }

            static void Main()
            {
                TreeNode root = new TreeNode(13);
                TreeNode node7 = new TreeNode(7);
                TreeNode node15 = new TreeNode(15);
                TreeNode node3 = new TreeNode(3);
                TreeNode node8 = new TreeNode(8);
                TreeNode node14 = new TreeNode(14);
                TreeNode node19 = new TreeNode(19);
                TreeNode node18 = new TreeNode(18);

                root.left = node7;
                root.right = node15;

                node7.left = node3;
                node7.right = node8;

                node15.left = node14;
                node15.right = node19;

                node19.left = node18;

                // Traverse
                InOrderTraversal(root);
            }
            */
            
            //Search for a Value in a BST
            
            /*
            
            static TreeNode Search(TreeNode node, int target)
            {
                if (node == null)
                {
                    return null;
                }
                else if (node.data == target)
                {
                    return node;
                }
                else if (target < node.data)
                {
                    return Search(node.left, target);
                }
                else
                {
                    return Search(node.right, target);
                }
            }
            */
            
            //Insert a Node in a BST
            /*
            static TreeNode Insert(TreeNode node, int data)
            {
                if (node == null)
                {
                    return new TreeNode(data);
                }
                else
                {
                    if (data < node.data)
                    {
                        node.left = Insert(node.left, data);
                    }
                    else if (data > node.data)
                    {
                        node.right = Insert(node.right, data);
                    }
                }
                return node;
            }*/
            
            //Find the lowest value
            
            /*
            static TreeNode MinValueNode(TreeNode node)
            {
                TreeNode current = node;

                while (current.left != null)
                {
                    current = current.left;
                }

                return current;
            }*/
            
            //Delete a Node in a BST
            /*
            static TreeNode Delete(TreeNode node, int data)
            {
                if (node == null)
                {
                    return null;
                }

                if (data < node.data)
                {
                    node.left = Delete(node.left, data);
                }
                else if (data > node.data)
                {
                    node.right = Delete(node.right, data);
                }
                else
                {
                    // Node with only one child or no child
                    if (node.left == null)
                    {
                        TreeNode temp = node.right;
                        node = null;
                        return temp;
                    }
                    else if (node.right == null)
                    {
                        TreeNode temp = node.left;
                        node = null;
                        return temp;
                    }

                    // Node with two children, get the in-order successor
                    node.data = MinValueNode(node.right).data;
                    node.right = Delete(node.right, node.data);
                }

                return node;
            }
            */

            #endregion
            
            #region AVL Trees
            //The Balance Factor BF for a node X is the difference in height between its right and left subtrees.
            //Balance factor values
            //0: The node is in balance.
            //more than 0: The node is "right heavy".
            //less than 0: The node is "left heavy".
        
            #endregion

        #endregion
        
        #region Graphs
            #region MyRegion
            #endregion
            
            #region MyRegion
            #endregion
            
            #region MyRegion
            #endregion
        #endregion
        
        #region Shortest Path

            #region MyRegion
            #endregion
            
            #region MyRegion
            #endregion
            
            #region MyRegion
            #endregion
            
            #region MyRegion
            #endregion

        #endregion
        
        #region Minimum Spanning Tree

            #region MyRegion
            #endregion
            
            #region MyRegion
            #endregion
            
            #region MyRegion
            #endregion

        #endregion
        
        #region Maximum Flow

            #region MyRegion
            #endregion
            
            #region MyRegion
            #endregion
            
            #region MyRegion
            #endregion

        #endregion
       
        #region Time Complexity

        

        #endregion
            
    }
}