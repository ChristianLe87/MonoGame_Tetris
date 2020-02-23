using System;
using System.Collections.Generic;

namespace MyTests
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            char[,] piece_s1 = new char[,] {
                                        { 'x', 'x', ' ' },
                                        { ' ', 'x', 'x' }
                                    };
            char[,] piece_s2 = new char[,] {
                                        { '1', '2', '3' },
                                        { '4', '5', '6' }
                                    };

            char[,] piece_s3 = new char[,] {
                                        { '3', '6' },
                                        { '2', '5' },
                                        { '1', '4' },
                                    };

            var result = Rotate90(piece_s2);

            
            var bla = 0;
        }


        public static char[,] Rotate90(char[,] piece)
        {
            /*char[,] result = new char[piece.GetLength(1), piece.GetLength(0)];

            for (int i = (piece.GetLength(1)-1); i > -1; i--)
            {
                for (int j = (piece.GetLength(0)-1); j > -1; j--)
                {
                    result[i,j] = piece[j, i];
                }
            }*/


            char[,] result = new char[piece.GetLength(1), piece.GetLength(0)];
            int newCol = 0;
            int newRow = 0;
            for (int col = piece.GetLength(1) - 1; col >= 0; col--)
            {
                newCol = 0;
                for (int row = 0; row < piece.GetLength(0); row++)
                {
                    result[newRow, newCol] = piece[row, col];
                    newCol++;
                }
                newRow++;
            }

            return result;
        }
    }
}
