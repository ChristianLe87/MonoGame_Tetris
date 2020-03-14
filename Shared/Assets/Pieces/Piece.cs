﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Piece : IAsset
    {


        char[,] s = new char[,] {   { ' ', 'p', 'p' },
                                    { 'p', 'p', ' ' }   };

        char[,] z = new char[,] {   { 'p', 'p', ' ' },
                                    { ' ', 'p', 'p' }   };

        char[,] t = new char[,] {   { 'p', 'p', 'p' },
                                    { ' ', 'p', ' ' }   };

        char[,] o = new char[,] {   { 'p', 'p' },
                                    { 'p', 'p' }   };

        char[,] i = new char[,] {   { 'p' },
                                    { 'p' },
                                    { 'p' },
                                    { 'p' }   };

        char[,] l = new char[,] {   { 'p', ' ' },
                                    { 'p', ' ' },
                                    { 'p', 'p' }   };

        char[,] j = new char[,] {   { ' ', 'p' },
                                    { ' ', 'p' },
                                    { 'p', 'p' }   };



        List<char[,]> pieces = new List<char[,]>();
        public char[,] pieceDesign;

        public Vector2 playerPosition;
        public Texture2D texturePiece;


        int framesCount = 0;

        int downSpeed = 30;
        bool canLeft = true;
        bool canRight = true;
        bool previous_keyUp = true;
        public bool canDown = true;

        bool previous_keyRight = true;
        bool previous_keyLeft = true;

        public Piece(Vector2 position)
        {
            this.pieces.Add(s);
            this.pieces.Add(z);
            this.pieces.Add(t);
            this.pieces.Add(o);
            this.pieces.Add(i);
            this.pieces.Add(l);
            this.pieces.Add(j);

            int r = new Random().Next(0, 6);
            pieceDesign = pieces[r];

            this.playerPosition = position;
            this.texturePiece = Tools.CreateColorTexture(Color.Green);

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

            canRight = CheckIfCanMoveRight(grid, this.pieceDesign, this.playerPosition);

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

            canLeft = CheckIfCanMoveLeft(grid, this.pieceDesign, this.playerPosition);
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
                    this.pieceDesign = Rotate90(this.pieceDesign);
                }
                else if (keyboardState.IsKeyUp(Keys.Up))
                {
                    previous_keyUp = true;
                }
            }


            canDown = CheckIfCanMoveDown(grid, this.pieceDesign, this.playerPosition);

        }

        internal void RandPiece()
        {
            int r = new Random().Next(0, 6);
            this.pieceDesign = pieces[r];
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 gameGridPosition)
        {
            // draw player
            {
                for (int row = 0; row < this.pieceDesign.GetLength(1); row++)
                {
                    for (int col = 0; col < this.pieceDesign.GetLength(0); col++)
                    {
                        if (this.pieceDesign[col, row] == 'p')
                        {
                            spriteBatch.Draw(texturePiece, new Rectangle((int)((this.playerPosition.X * 10) + row * 10 + gameGridPosition.X), (int)((this.playerPosition.Y * 10+ gameGridPosition.Y) + col * 10), 10, 10), Color.White);
                        }
                    }
                }
            }
        }


        private bool CheckIfCanMoveLeft(char[,] grid, char[,] piece_s, Vector2 playerPosition)
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


        private bool CheckIfCanMoveRight(char[,] grid, char[,] piece_s, Vector2 playerPosition)
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


        private char[,] Rotate90(char[,] piece)
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


    }
}
