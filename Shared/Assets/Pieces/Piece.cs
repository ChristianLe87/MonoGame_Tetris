using System;
using System.Collections.Generic;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Piece
    {
        List<char[,]> pieces = new List<char[,]>();
        public char[,] actualPieceDesign;
        public char[,] nextPieceDesign;

        public Vector2 playerPosition { get; set; }

        public static readonly Texture2D texture_S = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green);
        public static readonly Texture2D texture_Z = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red);
        public static readonly Texture2D texture_T = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Magenta);
        public static readonly Texture2D texture_O = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Yellow);
        public static readonly Texture2D texture_I = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.LightBlue);
        public static readonly Texture2D texture_L = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Orange);
        public static readonly Texture2D texture_J = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.DarkBlue);

        int framesCount = 0;

        int downSpeed = 30;
        bool canLeft = true;
        bool canRight = true;
        bool previous_keyUp = true;
        public bool canDown = true;

        bool previous_keyRight = true;
        bool previous_keyLeft = true;

        public Piece()
        {
            this.pieces.Add(WK.Piece.S);
            this.pieces.Add(WK.Piece.Z);
            this.pieces.Add(WK.Piece.T);
            this.pieces.Add(WK.Piece.O);
            this.pieces.Add(WK.Piece.I);
            this.pieces.Add(WK.Piece.L);
            this.pieces.Add(WK.Piece.J);
            this.pieces.Add(WK.Piece.S);
            this.pieces.Add(WK.Piece.Z);
            this.pieces.Add(WK.Piece.T);
            this.pieces.Add(WK.Piece.O);
            this.pieces.Add(WK.Piece.I);
            this.pieces.Add(WK.Piece.L);
            this.pieces.Add(WK.Piece.J);

            int r1 = new Random().Next(0, 13);
            actualPieceDesign = pieces[r1];

            int r2 = new Random().Next(0, 13);
            nextPieceDesign = pieces[r2];

            this.playerPosition = new Vector2(4, 0);
        }


        public void Update(char[,] grid)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            framesCount++;
            if (framesCount > downSpeed)
            {
                framesCount = 0;
                this.playerPosition = new Vector2(this.playerPosition.X, (this.playerPosition.Y + 1));
            }

            canRight = CheckIfCanMoveRight(grid, this.actualPieceDesign, this.playerPosition);

            if (canRight && previous_keyRight && keyboardState.IsKeyDown(Keys.Right))
            {
                // move right
                this.playerPosition = new Vector2(this.playerPosition.X + 1, this.playerPosition.Y);
                previous_keyRight = false;
            }
            else if (keyboardState.IsKeyUp(Keys.Right))
            {
                previous_keyRight = true;
            }

            canLeft = CheckIfCanMoveLeft(grid, this.actualPieceDesign, this.playerPosition);
            if (canLeft && previous_keyLeft && keyboardState.IsKeyDown(Keys.Left))
            {
                // move left
                this.playerPosition = new Vector2(this.playerPosition.X - 1, this.playerPosition.Y);
                previous_keyLeft = false;
            }
            else if (keyboardState.IsKeyUp(Keys.Left))
            {
                previous_keyLeft = true;
            }


            if (keyboardState.IsKeyDown(Keys.Down))
            {
                downSpeed = 1;
            }
            else
            {
                downSpeed = 30;
            }


            // rotate
            {
                if (previous_keyUp == true && keyboardState.IsKeyDown(Keys.Up))
                {
                    previous_keyUp = false;
                    this.actualPieceDesign = Rotate90(this.actualPieceDesign, grid, actualPieceDesign, playerPosition);

                }
                else if (keyboardState.IsKeyUp(Keys.Up))
                {
                    previous_keyUp = true;
                }
            }

            canDown = CheckIfCanMoveDown(grid, this.actualPieceDesign, this.playerPosition);

        }

        public void RandPiece()
        {
            this.actualPieceDesign = this.nextPieceDesign;

            int r = new Random().Next(0, 6);
            this.nextPieceDesign = pieces[r];
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 gameGridPosition)
        {
            // draw player
            {
                for (int row = 0; row < this.actualPieceDesign.GetLength(1); row++)
                {
                    for (int col = 0; col < this.actualPieceDesign.GetLength(0); col++)
                    {
                        if (this.actualPieceDesign[col, row] != ' ')
                        {
                            switch (this.actualPieceDesign[col, row])
                            {
                                case 's':
                                    spriteBatch.Draw(Piece.texture_S, new Rectangle((int)((this.playerPosition.X * 10) + row * 10 + gameGridPosition.X), (int)((this.playerPosition.Y * 10 + gameGridPosition.Y) + col * 10), 10, 10), Color.White);
                                    break;
                                case 'z':
                                    spriteBatch.Draw(Piece.texture_Z, new Rectangle((int)((this.playerPosition.X * 10) + row * 10 + gameGridPosition.X), (int)((this.playerPosition.Y * 10 + gameGridPosition.Y) + col * 10), 10, 10), Color.White);
                                    break;
                                case 't':
                                    spriteBatch.Draw(Piece.texture_T, new Rectangle((int)((this.playerPosition.X * 10) + row * 10 + gameGridPosition.X), (int)((this.playerPosition.Y * 10 + gameGridPosition.Y) + col * 10), 10, 10), Color.White);
                                    break;
                                case 'o':
                                    spriteBatch.Draw(Piece.texture_O, new Rectangle((int)((this.playerPosition.X * 10) + row * 10 + gameGridPosition.X), (int)((this.playerPosition.Y * 10 + gameGridPosition.Y) + col * 10), 10, 10), Color.White);
                                    break;
                                case 'i':
                                    spriteBatch.Draw(Piece.texture_I, new Rectangle((int)((this.playerPosition.X * 10) + row * 10 + gameGridPosition.X), (int)((this.playerPosition.Y * 10 + gameGridPosition.Y) + col * 10), 10, 10), Color.White);
                                    break;
                                case 'l':
                                    spriteBatch.Draw(Piece.texture_L, new Rectangle((int)((this.playerPosition.X * 10) + row * 10 + gameGridPosition.X), (int)((this.playerPosition.Y * 10 + gameGridPosition.Y) + col * 10), 10, 10), Color.White);
                                    break;
                                case 'j':
                                    spriteBatch.Draw(Piece.texture_J, new Rectangle((int)((this.playerPosition.X * 10) + row * 10 + gameGridPosition.X), (int)((this.playerPosition.Y * 10 + gameGridPosition.Y) + col * 10), 10, 10), Color.White);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }


        bool CheckIfCanMoveLeft(char[,] grid, char[,] piece_s, Vector2 playerPosition)
        {
            for (var pieceRow = 0; pieceRow < piece_s.GetLength(0); pieceRow++)
            {
                for (int pieceElement = 0; pieceElement < piece_s.GetLength(1); pieceElement++)
                {
                    if (piece_s[pieceRow, pieceElement] != ' ')
                    {
                        char rightChar = grid[(int)playerPosition.Y + pieceRow, (int)playerPosition.X + pieceElement - 1];
                        if (rightChar != ' ')// rightChar == 'x' || rightChar == '|')
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }


        bool CheckIfCanMoveRight(char[,] grid, char[,] piece_s, Vector2 playerPosition)
        {
            for (var pieceRow = 0; pieceRow < piece_s.GetLength(0); pieceRow++)
            {
                for (int pieceElement = 0; pieceElement < piece_s.GetLength(1); pieceElement++)
                {
                    if (piece_s[pieceRow, pieceElement] != ' ')
                    {
                        char leftChar = grid[(int)playerPosition.Y + pieceRow, (int)playerPosition.X + pieceElement + 1];
                        if (leftChar != ' ')// leftChar == 'x' || leftChar == '|')
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }


        bool CheckIfCanMoveDown(char[,] field, char[,] piece_s, Vector2 playerPosition)
        {

            for (int i = 0; i < piece_s.GetLength(0); i++)
            {
                for (int j = 0; j < piece_s.GetLength(1); j++)
                {
                    if (piece_s[i, j] != ' ')
                    {
                        char chr = field[(int)playerPosition.Y + i, (int)playerPosition.X + j];
                        if (chr != ' ')// chr == 'x' || chr == '|' || chr == '-')
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }


        char[,] Rotate90(char[,] piece, char[,] grid, char[,] pieceDesign, Vector2 playerPosition)
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



            bool canRotate = CheckIfCanRotate(grid, result, this.playerPosition);
            if (canRotate == true)
            {
                return result; // new
            }
            else
            {
                return piece; // original
            }

        }

        bool CheckIfCanRotate(char[,] grid, char[,] pieceDesign, Vector2 playerPosition)
        {

            for (int i = 0; i < pieceDesign.GetLength(0); i++)
            {
                for (int j = 0; j < pieceDesign.GetLength(1); j++)
                {
                    if (pieceDesign[i, j] != ' ')
                    {
                        char chr = grid[(int)playerPosition.Y, (int)playerPosition.X + j];
                        if ((chr == ' ') == false)
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