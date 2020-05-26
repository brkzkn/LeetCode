using System;

namespace LeetCode.ValidateBinarySearchTree
{
    class Program
    {
        /// <summary>
        /// Solution ref; https://leetcode.com/explore/interview/card/amazon/78/trees-and-graphs/514/
        /// </summary>
        static void Main(string[] args)
        {
            /*
                 5
                / \
               1   4
                  / \
                 3   6
              Input: [5,1,4,null,null,3,6]
              Output: false
            */
            TreeNode falseInput = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));
            /*
                2
               / \
              1   3
              Input: [2,1,3]
              Output: true 
            */
            TreeNode trueInput = new TreeNode(2, new TreeNode(1), new TreeNode(3));

            bool falseResult = IsValidBST(falseInput);
            bool trueResult = IsValidBST(trueInput);

            Console.WriteLine($"False Result: {falseResult}");
            Console.WriteLine($"True Result: {trueResult}");
        }

        public class TreeNode
        {
            public int Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int value = 0, TreeNode left = null, TreeNode right = null)
            {
                Value = value;
                Left = left;
                Right = right;
            }
        }

        static bool Helper(TreeNode node, int? lower, int? upper)
        {
            /*
             * Complexity Analysis
             * Time complexity : O(n) since we visit each node exactly once.
             * Space complexity : O(n) since we keep up to the entire tree.
             */
            if (node == null) return true;

            int val = node.Value;
            if (lower != null && val <= lower) return false;
            if (upper != null && val >= upper) return false;

            if (!Helper(node.Right, val, upper)) return false;
            if (!Helper(node.Left, lower, val)) return false;

            return true;
        }

        static bool IsValidBST(TreeNode root)
        {
            return Helper(root, null, null);
        }


    }
}
