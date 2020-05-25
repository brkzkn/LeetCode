using System;

namespace LeetCode.MergedTwoSortedLists
{
    class Program
    {
        /// <summary>
        /// Solution ref; https://leetcode.com/explore/interview/card/amazon/77/linked-list/2976/
        /// </summary>
        static void Main(string[] args)
        {
            /*
             * Input: 1->2->4, 1->3->4
             * Output: 1->1->2->3->4->4
             */
            ListNode l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            ListNode l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            //ListNode output = MergeTwoLists_1(l1, l2);
            ListNode output = MergeTwoLists_2(l1, l2);

            Console.Write("Output: ");
            while (output != null)
            {
                Console.Write($"{output.Value}->");
                output = output.Next;
            }
        }

        public class ListNode
        {
            public int Value;
            public ListNode Next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.Value= val;
                this.Next = next;
            }
        }

        #region Approach 1: Recursion
        static ListNode MergeTwoLists_1(ListNode l1, ListNode l2)
        {
            /*
                Complexity Analysis
                Time complexity : O(n+m)
                Space complexity : O(n+m)
             */
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.Value < l2.Value)
            {
                l1.Next= MergeTwoLists_1(l1.Next, l2);
                return l1;
            }
            else
            {
                l2.Next = MergeTwoLists_1(l1, l2.Next);
                return l2;
            }
        }
        #endregion

        #region Approach 2: Iteration

        static ListNode MergeTwoLists_2(ListNode l1, ListNode l2)
        {
            /*
                Complexity Analysis
                Time complexity : O(n+m)
                Space complexity : O(1)
             */

            // maintain an unchanging reference to node ahead of the return node.
            ListNode prehead = new ListNode(-1);

            ListNode prev = prehead;
            while (l1 != null && l2 != null)
            {
                if (l1.Value <= l2.Value)
                {
                    prev.Next = l1;
                    l1 = l1.Next;
                }
                else
                {
                    prev.Next = l2;
                    l2 = l2.Next;
                }
                prev = prev.Next;
            }

            // exactly one of l1 and l2 can be non-null at this point, so connect
            // the non-null list to the end of the merged list.
            prev.Next = l1 == null ? l2 : l1;

            return prehead.Next;
        }

        #endregion
    }
}
