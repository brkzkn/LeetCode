using System;
using System.Collections.Generic;

namespace LeetCode.RomanToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int RomanToInt(string roman)
        {
            Dictionary<char, int> romanInteger = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };

            int result = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i > 0 && romanInteger[roman[i]] > romanInteger[roman[i - 1]])
                {
                    result += romanInteger[roman[i]] - 2 * romanInteger[roman[i - 1]];
                }
                else
                {
                    result += romanInteger[roman[i]];
                }
            }

            return result;
        }
    }
}
