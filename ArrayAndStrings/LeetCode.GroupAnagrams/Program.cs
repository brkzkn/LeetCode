using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var output = GroupAnagrams(input);

            foreach (var item in output)
            {
                Console.WriteLine($"[{string.Join(",", item)}]");
            }
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                char[] chr = str.ToCharArray();
                Array.Sort(chr);
                String sortedText = new String(chr);
                if (map.TryGetValue(sortedText, out IList<string> anagramGroup))
                    anagramGroup.Add(str);
                else
                    map.Add(sortedText, new List<string>() { str });
            }
            return map.Values.ToList();
        }
    }
}
