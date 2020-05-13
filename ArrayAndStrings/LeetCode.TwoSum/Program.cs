using System;
using System.Collections.Generic;

namespace LeetCode.TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] givenNums = new int[] { 2, 7, 11, 15 };
            int target = 9;

            var result = TwoSum_Approach_1(givenNums, target);
            //var result = TwoSum_Approach_2(givenNums, target);
            //var result = TwoSum_Approach_3(givenNums, target);

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }


        /// <summary>
        /// Approach 1: Brute Force
        /// Ref: LeetCode; https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/508/
        /// </summary>
        static int[] TwoSum_Approach_1(int[] nums, int target)
        {
            /*
                Time complexity : O(n^2). For each element, we try to find its complement by looping through the rest of array which 
                takes O(n)time. Therefore, the time complexity is O(n^2)
                Space complexity : O(1)
            */
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new ArgumentException("No two sum solution");
        }

        /// <summary>
        /// Approach 2: Two-pass Hash Table
        /// Ref: LeetCode; https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/508/
        /// </summary>
        static int[] TwoSum_Approach_2(int[] nums, int target)
        {
            /*
                Time complexity : O(n). 
                We traverse the list containing n elements exactly twice. Since the hash table reduces the look up time to O(1), 
                the time complexity is O(n).

                Space complexity : O(n). 
                The extra space required depends on the number of items stored in the hash table, which stores exactly nn elements.
             */
            Dictionary<int,int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                map[nums[i]] = i;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement) && map[complement] != i)
                {
                    return new int[] { i, map[complement] };
                }
            }
            throw new ArgumentException("No two sum solution");
        }

        /// <summary>
        /// Approach 3: One-pass Hash Table
        /// Ref: LeetCode; https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/508/
        /// </summary>
        static int[] TwoSum_Approach_3(int[] nums, int target)
        {
            /*
                Time complexity : O(n). 
                We traverse the list containing n elements only once. Each look up in the table costs only O(1) time.
                
                Space complexity : O(n). 
                The extra space required depends on the number of items stored in the hash table, which stores at most n elements.
            */
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                map[nums[i]] = i;
            }
            throw new ArgumentException("No two sum solution");
        }
    }
}
