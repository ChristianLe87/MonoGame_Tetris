using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Escena_1 : IScene
    {

        char[,] grid = new char[,] {
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

        Texture2D textureBackgrownd;
        Texture2D texturePlayer;
        Texture2D textureBorder;







        Piece_S piece_S;

        public Escena_1()
        {
            piece_S = new Piece_S(new Vector2(1, 0));


            textureBackgrownd = Tools.CreateColorTexture(Color.Pink);
            texturePlayer = Tools.CreateColorTexture(Color.Red);
            textureBorder = Tools.CreateColorTexture(Color.DarkGreen);
        }

        public void Update()
        {
            piece_S.Update(grid);


           




            // burn grid
            {

                if (piece_S.canDown == false)
                {
                    grid = Tools.BurnPieceIntoGrid(grid, piece_S.pieceDesign, piece_S.playerPosition);
                    piece_S.playerPosition = new Vector2(1, 0);
                    grid = Tools.DeliteLine(grid);
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
                        switch (grid[col, row])
                        {
                            case ' ':
                                spriteBatch.Draw(textureBackgrownd, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                            case 'x':
                                spriteBatch.Draw(texturePlayer, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                            default:
                                spriteBatch.Draw(textureBorder, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                        }
                    }
                }
            }


            piece_S.Draw(spriteBatch);

        }


    }
}
