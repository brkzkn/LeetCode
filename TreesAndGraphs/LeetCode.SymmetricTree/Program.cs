using System;
using System.Collections.Generic;

namespace LeetCode.SymmetricTree
{
    class Program
    {
        class TreeNode
        {
            public int Value;
            public TreeNode Left;
            public TreeNode Right;
            public TreeNode(int value = 0, TreeNode left = null, TreeNode right = null)
            {
                this.Value = value;
                this.Left = left;
                this.Right = right;
            }
        }

        static void Main(string[] args)
        {
            var node = new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(4)), new TreeNode(2, new TreeNode(4), new TreeNode(3)));
            var result = IsSymmetric_Recursive(node);
            //var result = IsSymmetric_Iterative(node);
            Console.WriteLine($"Result is {result}");
        }

        static bool IsSymmetric_Recursive(TreeNode root)
        {
            return IsMirror(root, root);
        }

        static bool IsMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;

            return (t1.Value == t2.Value)
                && IsMirror(t1.Left, t2.Right)
                && IsMirror(t1.Right, t2.Left);
        }

        static bool IsSymmetric_Iterative(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(root);
            
            while (q.Count != 0)
            {
                TreeNode t1 = q.Dequeue();
                TreeNode t2 = q.Dequeue();
                if (t1 == null && t2 == null) continue;
                if (t1 == null || t2 == null) return false;
                if (t1.Value != t2.Value) return false;
                q.Enqueue(t1.Left);
                q.Enqueue(t2.Right);
                q.Enqueue(t1.Right);
                q.Enqueue(t2.Left);
            }
            return true;
        }
    }
}
