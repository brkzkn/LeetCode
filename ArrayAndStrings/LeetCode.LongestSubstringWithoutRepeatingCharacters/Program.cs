using System;
using System.Collections.Generic;

namespace LeetCode.LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        /// <summary>
        /// Solution ref; https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/779/
        /// </summary>
        static void Main(string[] args)
        {
            string input = "abcabcdbb";
            int output = LengthOfLongestSubstring_1(input);
            //int output = LengthOfLongestSubstring_2(input);
            //int output = LengthOfLongestSubstring_3(input);
            Console.WriteLine($"Result : {output}");
            Console.Read();
        }

        #region Approach 1: Brute Force
        static int LengthOfLongestSubstring_1(String s)
        {
            /*
                Complexity Analysis
                Time complexity : Time complexity : O(n^3)
                Space complexity : O(min(n, m))
             */
            int n = s.Length;
            int ans = 0;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j <= n; j++)
                    if (AllUnique(s, i, j)) ans = Math.Max(ans, j - i);
            return ans;
        }

        static bool AllUnique(String s, int start, int end)
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = start; i < end; i++)
            {
                char ch = s[i];
                if (set.Contains(ch)) return false;
                set.Add(ch);
            }
            return true;
        }
        #endregion

        #region Approach 2: Sliding Window
        static int LengthOfLongestSubstring_2(String s)
        {
            /*
                Complexity Analysis
                Time complexity : O(2n) = O(n). In the worst case each character will be visited twice by i and j.
                Space complexity : O(min(m, n)). 
             */
            int n = s.Length;
            HashSet<char> set = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n)
            {
                // try to extend the range [i, j]
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s[i++]);
                }
            }
            return ans;
        }
        #endregion

        #region Approach 3: Sliding Window Optimized
        static int LengthOfLongestSubstring_3(String s)
        {
            int n = s.Length, ans = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();// current index of character
                                                                    // try to extend the range [i, j]

            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(map[s[j]], i);
                }
                ans = Math.Max(ans, j - i + 1);
                map[s[j]] = j + 1;
            }
            return ans;
        }
        #endregion

    }
}
