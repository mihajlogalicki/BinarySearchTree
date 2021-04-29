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
            bst.Insert(45);
            bst.Insert(60);
            bst.Insert(86);
            bst.Insert(93);
            bst.Insert(99);

            //bst.InOrderTraversal();
            //bst.PreOrderTraversal();
            //bst.PreOrderTraversal();

            //var node = bst.Find(1);
            //var node = bst.FindRecursive(71);
            //if (node.HasValue)
            //{
            //    Console.WriteLine("Node found: " + node.Value);
            //}
            //else
            //{
            //    Console.WriteLine("Node NOT found");

            //bst.Remove(90);
            //bst.InOrderTraversal();
            //bst.Smallest();
            //Console.WriteLine(bst.Smallest());
            //Console.WriteLine(bst.NumberOfLeafNodes());      
            Console.WriteLine(bst.Heigth());
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

        public void PostOrderTraversal()
        {
            if (Left != null)
            {
                Left.PostOrderTraversal();
            }

            if (Right != null)
            {
                Right.PostOrderTraversal();
            }

            Console.WriteLine(Node + " ");
        }
        public Nullable<int> Find(int value)
        {
            TreeNode currNode = this;

            while (currNode != null)
            {
                if (value == currNode.Node)
                {
                    return currNode.Node;
                }
                else if (value > currNode.Node)
                {
                    currNode = currNode.Right;
                }
                else if (value < currNode.Node)
                {
                    currNode = currNode.Left;
                }
            }

            return null;
        }

        public Nullable<int> FindRecursive(int value)
        {
            int currNode = Node;

            if (value == currNode)
            {
                return currNode;
            }
            else if (value > currNode && Right != null)
            {
                return Right.FindRecursive(value);
            }
            else if (value < currNode && Left != null)
            {
                return Left.FindRecursive(value);
            }
            else
            {
                return null;
            }
        }

        public int Smallest()
        {
           if(Left != null)
            {
               return Left.Smallest();
            }
            else
            {
                return Node;
            }
        }
        public int Larger()
        {
            if(Right != null)
            {
                return Right.Larger();
            }else
            {
                return Node;
            }
        }

        public int NumberOfLeafNodes()
        {
            TreeNode node = this;

            if(Left == null && Right == null)
            {
                return 1;
            }

            int leftLeaves = 0;
            int rightLeaves = 0;

            if (Left != null)
            {
                leftLeaves = Left.NumberOfLeafNodes();
            }
            if (Right != null)
            {
                rightLeaves = Right.NumberOfLeafNodes();
            }

            return leftLeaves + rightLeaves;
        }

        public int Heigth()
        {
            if(Left == null && Right == null)
            {
                return 1;
            }

            int left = 0;
            int right = 0;

            if(Left != null)
            {
               left = Left.Heigth();
            }
            if(Right != null)
            {
                right = Right.Heigth();
            }

            if(left > right)
            {
                return (left + 1);
            }
            else
            {
                return (right + 1);
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

        public void PostOrderTraversal()
        {
            if (root != null)
            {
                root.PostOrderTraversal();
            }
        }

        public Nullable<int> Find(int value)
        {
            if (root != null)
            {
                return root.Find(value);
            }
            else
            {
                return null;
            }
        }
        public Nullable<int> FindRecursive(int value)
        {
            if (root != null)
            {
                return root.FindRecursive(value);
            }
            else
            {
                return null;
            }
        }

        private TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.Right;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.Left;
            }

            if (successor != node.Right)
            {
                parentOfSuccessor.Left = successor.Right;
                successor.Right = node.Right;
            }
            successor.Left = node.Left;
            return successor;
        }

        public void Remove(int value)
        {
            TreeNode currNode = root;
            TreeNode Parent = root;
            bool IsLeftNode = false;

            while (currNode != null && currNode.Node != value)
            {
                Parent = currNode;

                if (value < currNode.Node)
                {
                    currNode = currNode.Left;
                    IsLeftNode = true;
                }
                else
                {
                    currNode = currNode.Right;
                    IsLeftNode = false;
                }
            }

            if (currNode == null)
            {
                throw new Exception("Node not exists in the Tree!");
            }

            // We found a LEAF node (no childrens)
            if (currNode.Left == null && currNode.Right == null)
            {
                if (currNode == root)
                {
                    root = null;
                }
                else
                {
                    if (IsLeftNode)
                    {
                        Parent.Left = null;
                    }
                    else
                    {
                        Parent.Right = null;
                    }
                }
            }
            // We found node with one Children (left or right)
            else if (currNode.Left == null)
            {
                if (currNode == root)
                {
                    root = null;
                }
                else
                {
                    if (IsLeftNode)
                    {
                        Parent.Left = currNode.Right;
                    }
                    else
                    {
                        Parent.Right = currNode.Right;
                    }
                }
            }
            else if (currNode.Right == null)
            {
                if (currNode == root)
                {
                    root = null;
                }
                else
                {
                    if (IsLeftNode)
                    {
                        Parent.Left = currNode.Left;
                    }
                    else
                    {
                        Parent.Right = currNode.Right;
                    }
                }
            }
            // we found node with both children
            else
            {
                TreeNode successor = GetSuccessor(currNode);
                if (currNode == root)
                {
                    root = successor;
                }
                else if (IsLeftNode)
                {
                    Parent.Left = successor;
                }
                else
                {
                    Parent.Right = successor;
                }
            }
        }

        public Nullable<int> Smallest()
        {
            if(root != null)
            {
               return root.Smallest();
            }
            return null;
        }

        public Nullable<int> Larger()
        {
            if (root != null)
            {
                return root.Larger();
            }
            return null;
        }

        public int NumberOfLeafNodes()
        {
            if(root != null)
            {
                return root.NumberOfLeafNodes();
            } else
            {
                return 0;
            }
        }

        public int Heigth()
        {
            if(root == null)
            {
                return 0;
            }
            return root.Heigth();
        }
    }

  }
