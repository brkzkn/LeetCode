using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.WordBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "leetcode";
            List<string> wordDict = new List<string>()
            {
                "leet", "code"
            };

            WordBreak(s, wordDict);

            Console.WriteLine("Hello World!");
        }

        static bool WordBreak(string s, IList<string> wordDict)
        {
            bool[] isWordBreak = new bool[s.Length + 1];
            isWordBreak[0] = true;

            for (int i = 0; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!isWordBreak[j])
                        continue;

                    if (wordDict.Contains(s.Substring(j, i - j)))
                    {
                        isWordBreak[i] = true;
                        break;
                    }
                }
            }

            return isWordBreak[s.Length];
        }
    }
}
