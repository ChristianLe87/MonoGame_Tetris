using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Piece_S : IAsset
    {
        List<char[,]> pieces;
        char[,] piece_s;
        Texture2D texture;
        Vector2 position;

        int frameCount = 0;

        public Piece_S(Vector2 position)
        {
            this.texture = Tools.CreateColorTexture(Color.Red);
            this.piece_s = new char[,] { { ' ', 'x', 'x' },
                                         { 'x', 'x', ' ' } };
            this.position = position;
        }



        public void Update()
        {
            frameCount++;
            KeyboardState keyboardState = Keyboard.GetState();

            if (frameCount > 30 && keyboardState.IsKeyDown(Keys.Q))
            {
                Rotate90();
                frameCount = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < piece_s.GetLength(0); i++)
            {
                for (int j = 0; j < piece_s.GetLength(1); j++)
                {
                    if (piece_s[i, j] == 'x') { spriteBatch.Draw(texture, new Rectangle(j * 10, i * 10, 10, 10), Color.White); }                    
                }
            }
        }


        public void Rotate90()
        {
            char[,] result = new char[this.piece_s.GetLength(1), this.piece_s.GetLength(0)];
            int newCol = 0;
            int newRow = 0;

            for (int col = this.piece_s.GetLength(1) - 1; col >= 0; col--)
            {
                newCol = 0;
                for (int row = 0; row < this.piece_s.GetLength(0); row++)
                {
                    result[newRow, newCol] = this.piece_s[row, col];
                    newCol++;
                }
                newRow++;
            }

            this.piece_s = result;
        }
    }
}
