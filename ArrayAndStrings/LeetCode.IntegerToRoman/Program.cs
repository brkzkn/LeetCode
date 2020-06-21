using System;

namespace LeetCode.IntegerToRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 1994;
            Console.WriteLine($"Number: {number} is equal to Roman: {IntToRoman(number)}");
        }

        static string IntToRoman(int num)
        {
            string[] thousands = new string[] { "", "M", "MM", "MMM" };
            string[] houndreds = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tens = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] units = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            return thousands[num / 1000] +
                houndreds[(num % 1000) / 100] +
                tens[(num % 100) / 10] +
                units[num % 10];
        }
    }
}
