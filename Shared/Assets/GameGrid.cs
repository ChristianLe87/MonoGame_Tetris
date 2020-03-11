using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameGrid
    {
        Piece piece;

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
                    this.grid = Tools.BurnPieceIntoGrid(this.grid, piece.pieceDesign, piece.playerPosition);
                    piece.playerPosition = new Vector2(1, 0);
                    piece.RandPiece();
                    this.grid = Tools.DeliteLine(this.grid);
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


    }
}
