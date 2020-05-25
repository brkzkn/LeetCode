using System;
using System.Collections.Generic;

namespace LeetCode.AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
             */
            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            var result = AddTwoNumbers(l1, l2);
            Console.Write("Sum: ");
            while (result != null)
            {
                Console.Write(result.Value);
                result = result.Next;
            }
            Console.ReadLine();
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.Value : 0;
                int y = (q != null) ? q.Value : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.Next = new ListNode(sum % 10);
                curr = curr.Next;
                if (p != null) p = p.Next;
                if (q != null) q = q.Next;
            }
            if (carry > 0)
            {
                curr.Next = new ListNode(carry);
            }
            return dummyHead.Next;
        }

        public class ListNode
        {
            public int Value;
            public ListNode Next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.Value = val;
                this.Next = next;
            }
        }
    }
}
