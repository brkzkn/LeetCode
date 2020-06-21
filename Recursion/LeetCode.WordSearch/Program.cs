using System;

namespace LeetCode.WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[][] 
            {
                new char[]{ 'A', 'B', 'C', 'E' },
                new char[]{ 'S', 'F', 'C', 'S' },
                new char[]{ 'A', 'D', 'E', 'E' }
            };

            string word_true = "ABCCED";
            string word_false = "ABCB";

            var trueValue = IsExist(board, word_true);
            var falseValue = IsExist(board, word_false);
            Console.WriteLine($"The result of searching word: {word_true} is {trueValue}");
            Console.WriteLine($"The result of searching word: {word_false} is {falseValue}");
        }

        static bool IsExist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == word[0] && IsFound(board, i, j, 0, word))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool IsFound(char[][] board, int i, int j, int count, string word)
        {
            if (count == word.Length)
                return true;

            if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length || board[i][j] != word[count])
                return false;

            char temp = board[i][j];
            board[i][j] = ' ';

            bool found = IsFound(board, i + 1, j, count + 1, word)
                      || IsFound(board, i - 1, j, count + 1, word)
                      || IsFound(board, i, j + 1, count + 1, word)
                      || IsFound(board, i, j - 1, count + 1, word);

            board[i][j] = temp;

            return found;
        }
    }
}
