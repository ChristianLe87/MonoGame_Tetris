using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameGrid
    {
        public Piece piece;

        public char[,] grid = new char[,] {
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                    { '|', '-', '-', '-', '-', '-', '-', '-', '-', '|' },
                                    };

        public Texture2D textureBackgrownd;
        public Texture2D texturePlayer;
        public Texture2D textureBorder;

        public Vector2 GameGridPosition;
        public GameGrid(Vector2 GameGridPosition)
        {
            this.GameGridPosition = GameGridPosition;
            textureBackgrownd = Tools.CreateColorTexture(Color.Pink);
            texturePlayer = Tools.CreateColorTexture(Color.Red);
            textureBorder = Tools.CreateColorTexture(Color.DarkGreen);

            piece = new Piece(new Vector2(1, 0));

        }


        public void Update()
        {

            piece.Update(this.grid);

            // burn grid
            {

                if (piece.canDown == false)
                {
                    this.grid = BurnPieceIntoGrid(this.grid, piece.actualPieceDesign, piece.playerPosition);
                    piece.playerPosition = new Vector2(1, 0);
                    piece.RandPiece();
                    this.grid = DeliteLine(this.grid);
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw grid
            {
                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 20; col++)
                    {
                        switch (this.grid[col, row])
                        {
                            case ' ':
                                spriteBatch.Draw(this.textureBackgrownd, new Rectangle(row * 10 + (int)GameGridPosition.X, col * 10 + (int)GameGridPosition.Y, 10, 10), Color.White);
                                break;
                            case 'x':
                                spriteBatch.Draw(this.texturePlayer, new Rectangle(row * 10 + (int)GameGridPosition.X, col * 10 + (int)GameGridPosition.Y, 10, 10), Color.White);
                                break;
                            default:
                                spriteBatch.Draw(this.textureBorder, new Rectangle(row * 10 + (int)GameGridPosition.X, col * 10 + (int)GameGridPosition.Y, 10, 10), Color.White);
                                break;
                        }
                    }
                }
            }

            piece.Draw(spriteBatch, GameGridPosition);

        }



        private char[,] BurnPieceIntoGrid(char[,] grid, char[,] piece, Vector2 playerPosition)
        {
            for (int i = 0; i < piece.GetLength(0); i++)
            {
                for (int j = 0; j < piece.GetLength(1); j++)
                {
                    try
                    {
                        if (piece[i, j] == 'p')
                        {
                            grid[(int)playerPosition.Y + i - 1, (int)playerPosition.X + j] = 'x';
                        }
                    }
                    catch
                    {
                        return grid;
                    }
                }
            }

            return grid;
        }


        private char[,] DeliteLine(char[,] grid)
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
                    Escena_1.lineCount++;
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


    }
}
