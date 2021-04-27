using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree \n");

            BinaryTree bst = new BinaryTree();
            bst.Insert(75);
            bst.Insert(57);
            bst.Insert(90);
            bst.Insert(32);
            bst.Insert(7);
            bst.Insert(44);
            bst.Insert(60);
            bst.Insert(86);
            bst.Insert(93);
            bst.Insert(99);

            //bst.InOrderTraversal();
            bst.PreOrderTraversal();

        }
    }

    public class TreeNode
    {
        private int _node;
        public int Node
        {
            get { return _node; }
        }

        private TreeNode _left;
        public TreeNode Left
        {
            get { return _left; }
            set { _left = value; }
        }
        
        private TreeNode _right;
        public TreeNode Right
        {
            get { return _right; }
            set { _right = value; }
        }

        public TreeNode(int data)
        {
            _node = data;
        }

        // Methods for BST

        /* Rekurzivno se krecemo po stablu dok ne nadjemo prazno mesto za ubacivanje cvora */
        public void Insert(int value)
        {
            if(value > Node)
            {
                if(Right == null)
                {
                    Right = new TreeNode(value);
                } else
                {
                    Right.Insert(value);
                }
            } else
            {
                if(Left == null)
                {
                    Left = new TreeNode(value);
                } else
                {
                    Left.Insert(value);
                }
            }
        }

        public void InOrderTraversal()
        {
            if (Left != null)
            {
                Left.InOrderTraversal();
            }

            // print root node of the end
            Console.WriteLine(Node + " ");

            if (Right != null)
            {
                Right.InOrderTraversal();
            }
        }

        public void PreOrderTraversal()
        {
            Console.WriteLine(Node + " ");

            if (Left != null)
            {
                Left.PreOrderTraversal();
            }

            if (Right != null)
            {
                Right.PreOrderTraversal();
            }
        }
    }

    public class BinaryTree
    {
        private TreeNode root;
       
        public void Insert(int value)
        {
            if(root != null)
            {
                root.Insert(value);
            } else
            {
                root = new TreeNode(value);
            }
        }

        public void InOrderTraversal()
        {
            if(root != null)
            {
                root.InOrderTraversal();
            }
        }

        public void PreOrderTraversal()
        {
            if (root != null)
            {
                root.PreOrderTraversal();
            }
        }

    }

}

