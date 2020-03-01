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
        Texture2D texturePiece;
        Texture2D texturePlayer;
        Texture2D textureBorder;


        Vector2 playerPosition = new Vector2(1, 0);
        new char[,] piece_s = new char[,] { { ' ', 'p', ' ' },
                                            { 'p', 'p', 'p' } };

        bool previous_keyUp = true;
        bool previous_keyRight = true;
        bool previous_keyLeft = true;

        bool canDown = true;
        bool canLeft = true;
        bool canRight = true;

        int framesCount = 0;

        int gameSpeed = 30;

        public Escena_1()
        {
            textureBackgrownd = Tools.CreateColorTexture(Color.Pink);
            texturePiece = Tools.CreateColorTexture(Color.Green);
            texturePlayer = Tools.CreateColorTexture(Color.Red);
            textureBorder = Tools.CreateColorTexture(Color.DarkGreen);
        }

        public void Update()
        {
            framesCount++;
            if (framesCount > gameSpeed)
            {
                framesCount = 0;
                playerPosition = new Vector2(playerPosition.X, (playerPosition.Y + 1));
            }


            // rotate
            {
                KeyboardState keyboardState = Keyboard.GetState();

                if (previous_keyUp == true && keyboardState.IsKeyDown(Keys.Up))
                {
                    previous_keyUp = false;
                    piece_s = Tools.Rotate90(piece_s);
                }
                else if (keyboardState.IsKeyUp(Keys.Up))
                {
                    previous_keyUp = true;
                }
            }

            // move
            {
                KeyboardState keyboardState = Keyboard.GetState();

                if (previous_keyRight && keyboardState.IsKeyDown(Keys.Right))
                {
                    // move right
                    playerPosition = new Vector2(playerPosition.X + 1, playerPosition.Y);
                    previous_keyRight = false;
                }
                else if (keyboardState.IsKeyUp(Keys.Right))
                {
                    previous_keyRight = true;
                }

                canLeft = CheckIfCanMoveLeft(grid, piece_s, playerPosition);
                if (canLeft && previous_keyLeft && keyboardState.IsKeyDown(Keys.Left))
                {
                    // move left
                    playerPosition = new Vector2(playerPosition.X - 1, playerPosition.Y);
                    previous_keyLeft = false;
                }
                else if (keyboardState.IsKeyUp(Keys.Left))
                {
                    previous_keyLeft = true;
                }

                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    gameSpeed = 1;
                }
                else
                {
                    gameSpeed = 30;
                }

            }


            // burn grid
            {
                canDown = Tools.CheckIfCanMoveDown(grid, piece_s, playerPosition);

                if (canDown == false)
                {
                    grid = Tools.BurnPieceIntoGrid(grid, piece_s, playerPosition);
                    playerPosition = new Vector2(1, 0);
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
                                spriteBatch.Draw(texturePiece, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                            case 'p':
                                spriteBatch.Draw(texturePlayer, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
                                break;
                            default:
                                spriteBatch.Draw(textureBorder, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
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
                        if (piece_s[col, row] == 'p')
                        {
                            spriteBatch.Draw(texturePlayer, new Rectangle((int)((playerPosition.X * 10) + row * 10), (int)((playerPosition.Y * 10) + col * 10), 10, 10), Color.White);
                        }
                    }
                }
            }

        }

        public static bool CheckIfCanMoveLeft(char[,] grid, char[,] piece_s, Vector2 playerPosition)
        {
          

            return true;

        }
    }
}
