using System;

namespace LeetCode.MaximumSubarray
{
    class Program
    {
        /// <summary>
        /// Solution ref; https://leetcode.com/explore/interview/card/amazon/80/dynamic-programming/899/
        /// </summary>
        static void Main(string[] args)
        {
            int[] input = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //var result = MaxSubArray_Approach_1(input);
            var result = MaxSubArray_Approach_2(input);
            //var result = MaxSubArray_Approach_3(input);

            Console.WriteLine(result);
        }

        #region Approach 1: Divide and Conquer
        static int CrossSum(int[] nums, int left, int right, int p)
        {
            if (left == right) return nums[left];

            int leftSubsum = int.MinValue;
            int currSum = 0;
            for (int i = p; i > left - 1; --i)
            {
                currSum += nums[i];
                leftSubsum = Math.Max(leftSubsum, currSum);
            }

            int rightSubsum = int.MinValue;
            currSum = 0;
            for (int i = p + 1; i < right + 1; ++i)
            {
                currSum += nums[i];
                rightSubsum = Math.Max(rightSubsum, currSum);
            }

            return leftSubsum + rightSubsum;
        }

        static int Helper(int[] nums, int left, int right)
        {
            if (left == right) return nums[left];

            int p = (left + right) / 2;

            int leftSum = Helper(nums, left, p);
            int rightSum = Helper(nums, p + 1, right);
            int crossSum = CrossSum(nums, left, right, p);

            return Math.Max(Math.Max(leftSum, rightSum), crossSum);
        }

        static int MaxSubArray_Approach_1(int[] nums)
        {
            /*
                Complexity Analysis
                    Time complexity : O(NlogN). 
                    Space complexity : O(logN) to keep the recursion stack. 
             */
            return Helper(nums, 0, nums.Length - 1);
        }

        #endregion

        #region Approach 2: Greedy

        static int MaxSubArray_Approach_2(int[] nums)
        {
            /*
                Complexity Analysis
                Time complexity : O(N) since it's one pass along the array.
                Space complexity : O(1), since it's a constant space solution. 
             */
            int n = nums.Length;
            int currSum = nums[0], maxSum = nums[0];

            for (int i = 1; i < n; ++i)
            {
                currSum = Math.Max(nums[i], currSum + nums[i]);
                maxSum = Math.Max(maxSum, currSum);
            }
            return maxSum;
        }

        #endregion

        #region Approach 3: Dynamic Programming (Kadane's algorithm)

        static int MaxSubArray_Approach_3(int[] nums)
        {
            /*
                Complexity Analysis
                Time complexity : O(N) since it's one pass along the array.
                Space complexity : O(1), since it's a constant space solution.
             */
            int n = nums.Length, maxSum = nums[0];
            for (int i = 1; i < n; ++i)
            {
                if (nums[i - 1] > 0) nums[i] += nums[i - 1];
                maxSum = Math.Max(nums[i], maxSum);
            }
            return maxSum;
        }

        #endregion
    }
}
