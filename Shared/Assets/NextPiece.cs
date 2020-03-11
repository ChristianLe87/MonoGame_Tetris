using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class NextPiece
    {
        Vector2 position;
        Texture2D texture2D;
        Texture2D background;
        public char[,] piece = new char[,] {   { ' ', 'p', 'p' },
                                        { 'p', 'p', ' ' }   };


        public NextPiece(Vector2 position)
        {
            this.position = position;
            this.texture2D = Tools.CreateColorTexture(Color.Red);
            this.background = Tools.CreateColorTexture(Color.Pink);
        }


        public void Update()
        {
            throw new NotImplementedException();
        }


        public void Draw(SpriteBatch spriteBatch)
        {


            // draw background
            {
                spriteBatch.Draw(background, new Rectangle((int)position.X, (int)position.Y, 50, 50), Color.White);
            }


            // draw piece
            {
                for (int row = 0; row < this.piece.GetLength(1); row++)
                {
                    for (int col = 0; col < this.piece.GetLength(0); col++)
                    {
                        if (this.piece[col, row] == 'p')
                        {
                            spriteBatch.Draw(texture2D, new Rectangle((int)(row * 10 + position.X), (int)(col * 10 + position.Y), 10, 10), Color.White);
                        }
                    }
                }
            }



        }
    }
}
