using System;

namespace LeetCode.DesignTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        class TicTacToe
        {
            private int[] rows;
            private int[] columns;
            private int diag;
            private int xdiag;
            private int n;

            public TicTacToe(int n)
            {
                this.n = n;
                this.rows = new int[n];
                this.columns = new int[n];
                this.diag = 0;
                this.xdiag = 0;
            }

            public int Move(int row, int column, int player)
            {
                int count = player == 1 ? 1 : -1;

                rows[row] += count;
                columns[column] += count;

                if (row == column)
                    diag += count;

                if (row + column == n - 1)
                    xdiag += count;

                if (Math.Abs(rows[row]) == n || Math.Abs(columns[column]) == n || diag == n || xdiag == n)
                    return count > 0 ? 1 : 2;

                return 0;
            }
        }
    }
}
