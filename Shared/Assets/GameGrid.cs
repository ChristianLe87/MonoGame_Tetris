using System.Collections.Generic;
using System.Linq;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameGrid
    {
        public Piece piece;

        public char[,] grid = WK.Grid.MainGrid;

        public Texture2D textureBackgrownd;
        public Texture2D texturePlayer;
        public Texture2D textureBorder;

        public Vector2 GameGridPosition;
        public GameGrid(Vector2 GameGridPosition)
        {
            this.GameGridPosition = GameGridPosition;
            textureBackgrownd = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink);
            texturePlayer = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red);
            textureBorder = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Brown);

            piece = new Piece();
        }


        public void Update()
        {

            piece.Update(this.grid);

            // burn grid
            {
                if (piece.canDown == false)
                {
                    // game over
                    if (piece.playerPosition.Y < 1)
                    {
                        Escena_1.isGameOver = true;
                    }
                    else
                    {
                        this.grid = BurnPieceIntoGrid(this.grid, piece.actualPieceDesign, piece.playerPosition);
                        piece.playerPosition = new Vector2(4, 0);
                        piece.RandPiece();
                        this.grid = DeliteLine(this.grid);
                    }
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
                            case 's':
                                spriteBatch.Draw(Piece.texture_S, new Rectangle(row * 10 + (int)GameGridPosition.X, col * 10 + (int)GameGridPosition.Y, 10, 10), Color.White);
                                break;
                            case 'z':
                                spriteBatch.Draw(Piece.texture_Z, new Rectangle(row * 10 + (int)GameGridPosition.X, col * 10 + (int)GameGridPosition.Y, 10, 10), Color.White);
                                break;
                            case 't':
                                spriteBatch.Draw(Piece.texture_T, new Rectangle(row * 10 + (int)GameGridPosition.X, col * 10 + (int)GameGridPosition.Y, 10, 10), Color.White);
                                break;
                            case 'o':
                                spriteBatch.Draw(Piece.texture_O, new Rectangle(row * 10 + (int)GameGridPosition.X, col * 10 + (int)GameGridPosition.Y, 10, 10), Color.White);
                                break;
                            case 'i':
                                spriteBatch.Draw(Piece.texture_I, new Rectangle(row * 10 + (int)GameGridPosition.X, col * 10 + (int)GameGridPosition.Y, 10, 10), Color.White);
                                break;
                            case 'l':
                                spriteBatch.Draw(Piece.texture_L, new Rectangle(row * 10 + (int)GameGridPosition.X, col * 10 + (int)GameGridPosition.Y, 10, 10), Color.White);
                                break;
                            case 'j':
                                spriteBatch.Draw(Piece.texture_J, new Rectangle(row * 10 + (int)GameGridPosition.X, col * 10 + (int)GameGridPosition.Y, 10, 10), Color.White);
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
                        if (piece[i, j] != ' ')
                        {
                            grid[(int)playerPosition.Y + i - 1, (int)playerPosition.X + j] = piece[i, j];
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
            int deletedLines = 0;

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




            for (int i = 0; i < gridList.Count() - 1; i++)
            {
                var r = gridList[i].Where(x => x == ' ').ToList();
                if (r.Count == 0)
                {
                    deletedLines++;
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


            // Change score
            UpdateScore(deletedLines);


            return result;
        }


        private void UpdateScore(int deletedLines)
        {
            if (deletedLines == 0)
                Escena_1.scoreCount += 0;
            else if (deletedLines == 1)
                Escena_1.scoreCount += 40;
            else if (deletedLines == 2)
                Escena_1.scoreCount += 100;
            else if (deletedLines == 3)
                Escena_1.scoreCount += 300;
            else if (deletedLines == 4)
                Escena_1.scoreCount += 1200;
        }
    }
}
