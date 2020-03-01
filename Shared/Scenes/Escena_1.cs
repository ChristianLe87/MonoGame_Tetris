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

        char[,] field = new char[,] {
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

        Texture2D backgrownd;
        Texture2D piece;
        Texture2D player;
        Texture2D border;


        Vector2 playerPosition = new Vector2(1, 0);
        new char[,] piece_s = new char[,] { { ' ', 'p', 'p' },
                                            { 'p', 'p', ' ' } };

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
            backgrownd = Tools.CreateColorTexture(Color.Pink);
            piece = Tools.CreateColorTexture(Color.Green);
            player = Tools.CreateColorTexture(Color.Red);
            border = Tools.CreateColorTexture(Color.DarkGreen);
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

                if (previous_keyLeft && keyboardState.IsKeyDown(Keys.Left))
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
                canDown = CheckIfCanMoveDown(field, piece_s, playerPosition);

                if (canDown == false)
                {
                    field = BurnPieceIntoGrid(field, piece_s, playerPosition);
                    playerPosition = new Vector2(1, 0);
                    field = DeliteLine(field);
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
                                spriteBatch.Draw(border, new Rectangle(row * 10, col * 10, 10, 10), Color.White);
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
                            spriteBatch.Draw(player, new Rectangle((int)((playerPosition.X * 10) + row * 10), (int)((playerPosition.Y * 10) + col * 10), 10, 10), Color.White);
                        }
                    }
                }
            }

        }


        private bool CheckIfCanMoveDown(char[,] field, char[,] piece_s, Vector2 playerPosition)
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


        public char[,] BurnPieceIntoGrid(char[,] grid, char[,] piece, Vector2 playerPosition)
        {
            for (int i = 0; i < piece.GetLength(0); i++)
            {
                for (int j = 0; j < piece.GetLength(1); j++)
                {
                    if (piece[i, j] == 'p')
                    {
                        field[(int)playerPosition.Y + i - 1, (int)playerPosition.X + j] = 'x';
                    }
                }
            }

            return field;
        }



        public char[,] DeliteLine(char[,] grid)
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

    }
}