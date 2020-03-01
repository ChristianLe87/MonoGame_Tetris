using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Escena_1 : IScene
    {

        char[,] field = new char[,] {
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                    };

        Texture2D backgrownd;
        Texture2D piece;
        Texture2D player;


        Vector2 playerPosition = new Vector2(0, 0);
        new char[,] piece_s = new char[,] { { ' ', 'p', 'p' },
                                            { 'p', 'p', ' ' } };


        int framesCount = 0;
        public Escena_1()
        {
            backgrownd = Tools.CreateColorTexture(Color.Pink);
            piece = Tools.CreateColorTexture(Color.Green);
            player = Tools.CreateColorTexture(Color.Red);
        }

        public void Update()
        {
            framesCount++;
            if(framesCount > 30)
            {
                framesCount = 0;
                playerPosition = new Vector2(playerPosition.X, (playerPosition.Y + 1));
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
                        switch (field[col, row])
                        {
                            case ' ':
                                spriteBatch.Draw(backgrownd, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                            case 'x':
                                spriteBatch.Draw(piece, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                            case 'p':
                                spriteBatch.Draw(player, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            // draw player
            {
                for (int row = 0; row < piece_s.GetLength(1); row++)
                {
                    for (int col = 0; col < piece_s.GetLength(0); col++)
                    {
                        if(piece_s[col, row] == 'p')
                        {
                            spriteBatch.Draw(player, new Rectangle((int)((playerPosition.X * 10) + row*10), (int)((playerPosition.Y * 10) + col*10), 10, 10), Color.White);
                        }
                    }
                }
            }

        }

    }
}
