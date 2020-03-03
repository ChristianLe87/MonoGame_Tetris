using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Tools
    {
        public static Texture2D CreateColorTexture(Color color)
        {
            Texture2D newTexture = new Texture2D(MyGame.graphicsDeviceManager.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            newTexture.SetData(new Color[] { color });
            return newTexture;
        }

        public static char[,] Rotate90(char[,] piece)
        {
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


        public static char[,] DeliteLine(char[,] grid)
        {
            List<List<char>> gridList = new List<List<char>>();

            for (int i = 0; i < 20; i++)
            {
                List<char> temp = new List<char>();
                for (int j = 0; j < 10; j++)
                {
                    temp.Add(grid[i, j]);
                }
                gridList.Add(temp);
            }




            for (int i = 0; i < gridList.Count(); i++)
            {
                var r = gridList[i].Where(x => x == 'x').ToList();
                if (r.Count == 8)
                {
                    gridList.RemoveAt(i);
                    gridList.Insert(0, new List<char>() { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' });
                    i = 0;
                }
            }



            char[,] result = new char[20, 10];


            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    result[i, j] = gridList[i][j];
                }
            }


            return result;
        }


        public static bool CheckIfCanMoveDown(char[,] field, char[,] piece_s, Vector2 playerPosition)
        {

            for (int i = 0; i < piece_s.GetLength(0); i++)
            {
                for (int j = 0; j < piece_s.GetLength(1); j++)
                {
                    if (piece_s[i, j] == 'p')
                    {
                        char chr = field[(int)playerPosition.Y + i, (int)playerPosition.X + j];
                        if (chr == 'x' || chr == '|' || chr == '-')
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }


        public static char[,] BurnPieceIntoGrid(char[,] grid, char[,] piece, Vector2 playerPosition)
        {
            for (int i = 0; i < piece.GetLength(0); i++)
            {
                for (int j = 0; j < piece.GetLength(1); j++)
                {
                    if (piece[i, j] == 'p')
                    {
                        grid[(int)playerPosition.Y + i - 1, (int)playerPosition.X + j] = 'x';
                    }
                }
            }

            return grid;
        }


        public static bool CheckIfCanMoveLeft(char[,] grid, char[,] piece_s, Vector2 playerPosition)
        {
            for (var pieceRow = 0; pieceRow < piece_s.GetLength(0); pieceRow++)
            {
                for (int pieceElement = 0; pieceElement < piece_s.GetLength(1); pieceElement++)
                {
                    if (piece_s[pieceRow, pieceElement] == 'p')
                    {
                        char rightChar = grid[(int)playerPosition.Y + pieceRow, (int)playerPosition.X + pieceElement - 1];
                        if (rightChar == 'x' || rightChar == '|')
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }


        public static bool CheckIfCanMoveRight(char[,] grid, char[,] piece_s, Vector2 playerPosition)
        {
            for (var pieceRow = 0; pieceRow < piece_s.GetLength(0); pieceRow++)
            {
                for (int pieceElement = 0; pieceElement < piece_s.GetLength(1); pieceElement++)
                {
                    if (piece_s[pieceRow, pieceElement] == 'p')
                    {
                        char leftChar = grid[(int)playerPosition.Y + pieceRow, (int)playerPosition.X + pieceElement + 1];
                        if (leftChar == 'x' || leftChar == '|')
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }
    }
} 

