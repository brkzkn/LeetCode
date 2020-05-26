using System;
using System.Collections.Generic;

namespace LeetCode.LetterCombinationsOfAPhoneNumber
{
    class Program
    {
        /// <summary>
        /// Solution ref; https://leetcode.com/explore/interview/card/amazon/84/recursion/521/
        /// </summary>
        static void Main(string[] args)
        {
            /*
             * Input: "23"
             * Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
             */
            string input = "23";
            LetterCombinations(input);
            Console.WriteLine($"Output: [{string.Join(", ", output)}]");
        }

        static Dictionary<string, string> phone = new Dictionary<string, string>()
        {
            {"2", "abc" },
            {"3", "def" },
            {"4", "ghi" },
            {"5", "jkl" },
            {"6", "mno" },
            {"7", "pqrs" },
            {"8", "tuv" },
            {"9", "wxyz" }
        };

        static List<string> output = new List<string>();

        static void Backtrack(string combination, string next_digits)
        {
            /*
             * Complexity Analysis
             * Time complexity : O(3^N x 4^M)
             * Space complexity : O(3^N x 4^M) since one has to keep 3^N x 4^M solutions.
             */

            // if there is no more digits to check
            if (next_digits.Length == 0)
            {
                // the combination is done
                output.Add(combination);
            }
            // if there are still digits to check
            else
            {
                // iterate over all letters which map 
                // the next available digit
                string digit = next_digits.Substring(0, 1);
                string letters = phone[digit];
                for (int i = 0; i < letters.Length; i++)
                {
                    String letter = phone[digit].Substring(i, 1);
                    // append the current letter to the combination
                    // and proceed to the next digits
                    Backtrack(combination + letter, next_digits.Substring(1));
                }
            }
        }

        static List<string> LetterCombinations(string digits)
        {
            if (digits.Length != 0)
                Backtrack("", digits);
            return output;
        }
    }
}
