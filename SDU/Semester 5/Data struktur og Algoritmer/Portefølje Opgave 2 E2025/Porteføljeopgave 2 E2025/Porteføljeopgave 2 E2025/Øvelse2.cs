using System;
using System.Collections.Generic;
using System.Linq;

namespace Porteføljeopgave_2_E2025
{
    public class Øvelse2
    {
        public static List<Node> branch = new List<Node>();
        
        /*
        static void Main(string[] args)
        {
            Node root = new Node(7);
            Node rootLeft = new Node(4);
            Node rootRight = new Node(28);

            Node rootLeftOne = new Node(3);
            Node rootLeftTwo = new Node(2);
            Node rootLeftFour = new Node(1);

            Node rootRightOne = new Node(55);

            Node rightNodeLeft = new Node(51);
            Node rightNodeLeftOne = new Node(48);
            Node rightNodeLeftTwo = new Node(40);
            Node rightNodeLeftThree = new Node(35);

            Node rightNodeRight = new Node(60);
            Node rightNodeRightLeft = new Node(56);
            Node rightNodeRightLeftOne = new Node(57);
            
            Node rightNodeRightRight = new Node(69);

            root.left = rootLeft;
            root.right = rootRight;

            rootLeft.left = rootLeftOne;
            rootLeftOne.left = rootLeftTwo;
            rootLeftTwo.left = rootLeftFour;

            rootRight.left = rootRightOne;

            rootRightOne.left = rightNodeLeft;
            rightNodeLeft.left = rightNodeLeftOne;
            rightNodeLeftOne.left = rightNodeLeftTwo;
            rightNodeLeftTwo.left = rightNodeLeftThree;

            rootRightOne.right = rightNodeRight;

            rightNodeRight.left = rightNodeRightLeft;
            rightNodeRightLeft.left = rightNodeRightLeftOne;

            rightNodeRight.right = rightNodeRightRight;
            
            root.GetOnlyChild(root);
            
            Console.WriteLine(branch.Count);

        }*/
        
        public class Node {
            public int data;
            public Node left, right;

            public Node(int d) {
                this.data = d;
                left = null;
                right = null;
            }

            public void GetOnlyChild(Node node, Node parent = null)
            {
                if (node == null) return;

                bool oneChild = (node.left != null) ^ (node.right != null);

                bool noSiblings =
                    parent == null ||
                    (parent.left == node && parent.right == null) ||
                    (parent.right == node && parent.left == null);

                if (oneChild && noSiblings)
                {
                    Node child = node.left ?? node.right;
                    bool childOneChild = (child.left != null) ^ (child.right != null);

                    Node grandChild = child.left ?? child.right;
                    bool grandChildIsLeaf =
                        grandChild != null &&
                        grandChild.left == null &&
                        grandChild.right == null;

                    if (childOneChild && grandChildIsLeaf)
                        Øvelse2.branch.Add(node);
                }

                GetOnlyChild(node.left, node);
                GetOnlyChild(node.right, node);
            }


        }
    }
    
 
}