using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class NextPiecePreview
    {
        Rectangle rectangle;
        Texture2D background;
        Texture2D nextPieceTexture;
        char[,] piece;


        public NextPiecePreview(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.background = Tools.CreateColorTexture(Color.Pink);
            this.nextPieceTexture = Tools.CreateColorTexture(Color.Blue);
        }


        internal void Update(char[,] nextPieceDesign)
        {
            this.piece = nextPieceDesign;
        }

        public void Draw(SpriteBatch spriteBatch)
        {


            // draw background
            {
                spriteBatch.Draw(background, rectangle, Color.White);
            }


            // draw piece
            {
                for (int row = 0; row < this.piece.GetLength(1); row++)
                {
                    for (int col = 0; col < this.piece.GetLength(0); col++)
                    {
                        if (this.piece[col, row] == 'p')
                        {
                            spriteBatch.Draw(nextPieceTexture, new Rectangle((row * 10 + rectangle.X) + 10, (col * 10 + rectangle.Y) + 10, 10, 10), Color.White);
                        }
                    }
                }
            }
        }

     
    }
}
