using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameGrid
    {
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


        public GameGrid()
        {

            textureBackgrownd = Tools.CreateColorTexture(Color.Pink);
            texturePlayer = Tools.CreateColorTexture(Color.Red);
            textureBorder = Tools.CreateColorTexture(Color.DarkGreen);
        }


        public void Update(Piece_S piece_S)
        {
            // burn grid
            {

                if (piece_S.canDown == false)
                {
                    this.grid = Tools.BurnPieceIntoGrid(this.grid, piece_S.pieceDesign, piece_S.playerPosition);
                    piece_S.playerPosition = new Vector2(1, 0);
                    piece_S.RandPiece();
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
                                spriteBatch.Draw(this.textureBackgrownd, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                            case 'x':
                                spriteBatch.Draw(this.texturePlayer, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                            default:
                                spriteBatch.Draw(this.textureBorder, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                        }
                    }
                }
            }
        }

       
    }
}
