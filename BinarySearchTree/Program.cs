using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(3);
            tree.Add(20);

            BST bst = new BST();
            int max = bst.MaxPath(tree.top);
            Console.WriteLine(max);
            Queue q = new Queue();
            Console.WriteLine(q.FindDepth(tree.top));
        }
        public static int Factorial(int n)
        {
            if (n != 1)
                n = n * Factorial(n - 1);
            
                return n;
        }
    }
    class BST
    {
        public int MaxPath(Node node)
        {
            Res res = new Res();
            res.value = int.MinValue;

            MaxPath(node, res);
            return res.value;
        }
        

        public int MaxPath(Node node, Res res)
        {
            if (node == null)
                return 0;
            int l = MaxPath(node.left, res);
            int r = MaxPath(node.right, res);

            int maxSingle = Math.Max(Math.Max(l, r) + node.value, node.value);

            int top = Math.Max(l + r + node.value, maxSingle);

            res.value = Math.Max(res.value, top);

            return maxSingle;
        }
    }
    class Res
    {
        public int value;
    }
    public struct QueueItem
    {
        public Node node;
        public int depth;
    }
    class Queue
    {
        public int FindDepth(Node node)
        {
            if (node == null)
                return 0;
            
            Queue<QueueItem> q = new Queue<QueueItem>();
            QueueItem qi;
            qi.depth = 1;
            qi.node = node;
            q.Enqueue(qi);

            while (q.Count != 0)
            {
                qi = q.Dequeue();
                int depth = qi.depth;
                node = qi.node;

                if (node.left == null || node.right == null)
                    return depth;

                if (node.left != null)
                {
                    qi.node = node.left;
                    qi.depth = depth + 1;
                    q.Enqueue(qi);
                }
                if(node.right != null)
                {
                    qi.node = node.right;
                    qi.depth = depth + 1;
                    q.Enqueue(qi);
                }
            }
            return 0;
        }
    }

    public class Node
    { 
        public int value;
        public Node left;
        public Node right;

        public Node()
        {

        }

        public Node(int initial)
        {
            value = initial;
            left = null;
            right = null;
        }
    }
    class Tree
    {
        public Node top;
        public Tree()
        {
            top = null;
        }
        public Tree(int initial)
        {
            top = new Node(initial);
        }
        public void Add(int value)
        {
            if (top == null)
            {
                top = new Node(value);
            }
            Node current = top;
            bool isAdded = false;
            do
            {
                if(value < current.value)
                {
                    if (current.left == null)
                    {
                        Node newNode = new Node(value);
                        current.left = newNode;
                        isAdded = true;
                    }
                    else
                    {
                        current = current.left;
                    }
                }
                if(value >= current.value)
                {
                    if(current.right == null)
                    {
                        Node newNode = new Node(value);
                        current.right = newNode;
                        isAdded = true;
                    }
                    else
                    {
                        current = current.right;
                    }
                }
            } while (!isAdded);
        }
        public void AddRc(int value)
        {
            AddR(ref top, value);
        }
        public void AddR(ref Node N, int value)
        {
            if(N == null)
            {
                Node NewNode = new Node(value);
                N = NewNode;
                return;
            }
            if(value < N.value)
            {
                AddR(ref N.left, value);
                return;
            }
            if(value >= N.value)
            {
                AddR(ref N.right, value);
                return;
            }
        }
        public void Print(Node N, ref string newString)
        {
            if (N == null)
                N = top;
            if (N.left != null)
            {
                Print(N.left, ref newString);
                newString = newString + N.value.ToString();
            }
            else
            {
                newString = newString + N.value.ToString();
            }
            if (N.right != null)
            {
                Print(N.right, ref newString);
            }
        }

            
    }
}
