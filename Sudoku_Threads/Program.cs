using System;
using System.Threading;

namespace Sudoku_Threads
{
    class MainClass
    {
        static Thread[] thread = new Thread[27];
        static bool valid = false;
        static int[,] sudoku = new int[9, 9]
        {
            {5,3,4,6,7,8,9,1,2},
            {6,7,2,1,9,5,3,4,8},
            {1,9,8,3,4,2,5,6,7},
            {8,5,9,7,6,1,4,2,3},
            {4,2,6,8,5,3,7,9,1},
            {7,1,3,9,2,4,8,5,6},
            {9,6,1,5,3,7,2,8,4},
            {2,8,7,4,1,9,6,3,5},
            {3,4,5,2,8,6,1,7,9}
        };
        class parameters
        {
            public int row { get; set; }
            public int column { get; set; }
        }

        public static void Main(string[] args)
        {
            
        }



        private static bool checkOutsideRangeValue(int value)
        {
            if (value < 1 || value > 9)
            {
                return false;
            }
            return true;
        }

        /**
         * Check valid column       
         */
        private bool IsValidColumn(parameters param)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[i, param.column] < 1 || sudoku[i, param.column] > 9)
                {
                    Console.WriteLine("Invalid Matrix in column" + param.column);
                    return false;
                }

                for (int j = i++; j < 9; j++)
                {
                    if (sudoku[i, param.column] == sudoku[j, param.column])
                    {
                        Console.WriteLine("Invalid Matrix in column" + param.column);
                        return false;
                    }
                }
            }
            return true;
        }

        /**
         * Check valid row     
         */
        private bool IsValidRow(parameters param)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[param.row, i] < 1 || sudoku[param.row, i] > 9)
                {
                    Console.WriteLine("Invalid Matrix row at" + param.row);
                    return false;
                }

                for (int j = i++; j < 9; j++)
                {
                    if (sudoku[param.row, i] == sudoku[param.row, j])
                    {
                        Console.WriteLine("Invalid Matrix row at" + param.row);
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValid3x3Matrix(parameters param)
        {
            int[] matrix = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = param.row; i < param.row + 3; i++)
            {
                for (int j = 0; j < param.column+ 3; j++)
                {
                    int num = sudoku[i, j];
                    bool validOutSide = checkOutsideRangeValue(num);
                    if (validOutSide && matrix[num - 1] == 1)
                    {
                        Console.WriteLine("Invalid matrix");
                        return false;
                    }
                    else
                    {
                        matrix[num - 1] = 1;
                    }
                }
            }
            return true;
        }
    }
}
