using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Piece_S : IAsset
    {

        public char[,] pieceDesign = new char[,] {  { ' ', 'p', 'p' },
                                                    { ' ', 'p', ' ' },
                                                    { ' ', 'p', ' ' } };

        public Vector2 playerPosition;
        public Texture2D texturePiece;


        int framesCount = 0;

        int gameSpeed = 30;
        bool canLeft = true;
        bool canRight = true;
        bool previous_keyUp = true;
        public bool canDown = true;

        bool previous_keyRight = true;
        bool previous_keyLeft = true;

        public Piece_S(Vector2 position)
        {
            this.playerPosition = position;
            this.texturePiece = Tools.CreateColorTexture(Color.Green);

        }


        public void Update(char[,] grid)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            framesCount++;
            if (framesCount > gameSpeed)
            {
                framesCount = 0;
                this.playerPosition = new Vector2(this.playerPosition.X, (this.playerPosition.Y + 1));
            }

            canRight = Tools.CheckIfCanMoveRight(grid, this.pieceDesign, this.playerPosition);

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

            canLeft = Tools.CheckIfCanMoveLeft(grid, this.pieceDesign, this.playerPosition);
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
                gameSpeed = 1;
            }
            else
            {
                gameSpeed = 30;
            }


            // rotate
            {

                if (previous_keyUp == true && keyboardState.IsKeyDown(Keys.Up))
                {
                    previous_keyUp = false;
                    this.pieceDesign = Tools.Rotate90(this.pieceDesign);
                }
                else if (keyboardState.IsKeyUp(Keys.Up))
                {
                    previous_keyUp = true;
                }
            }


            canDown = Tools.CheckIfCanMoveDown(grid, this.pieceDesign, this.playerPosition);

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // draw player
            {
                for (int row = 0; row < this.pieceDesign.GetLength(1); row++)
                {
                    for (int col = 0; col < this.pieceDesign.GetLength(0); col++)
                    {
                        if (this.pieceDesign[col, row] == 'p')
                        {
                            spriteBatch.Draw(texturePiece, new Rectangle((int)((this.playerPosition.X * 10) + row * 10), (int)((this.playerPosition.Y * 10) + col * 10), 10, 10), Color.White);
                        }
                    }
                }
            }
        }

       
    }
}
