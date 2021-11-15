using System;
using ChristianTools.Tools;
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
            this.background = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink);
            this.nextPieceTexture = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Blue);
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
                        if (this.piece[col, row] != ' ')
                        {
                            switch (this.piece[col, row])
                            {
                                case 's':
                                    spriteBatch.Draw(Piece.texture_S, new Rectangle((row * 10 + rectangle.X) + 10, (col * 10 + rectangle.Y) + 10, 10, 10), Color.White);
                                    break;
                                case 'z':
                                    spriteBatch.Draw(Piece.texture_Z, new Rectangle((row * 10 + rectangle.X) + 10, (col * 10 + rectangle.Y) + 10, 10, 10), Color.White);
                                    break;
                                case 't':
                                    spriteBatch.Draw(Piece.texture_T, new Rectangle((row * 10 + rectangle.X) + 10, (col * 10 + rectangle.Y) + 10, 10, 10), Color.White);
                                    break;
                                case 'o':
                                    spriteBatch.Draw(Piece.texture_O, new Rectangle((row * 10 + rectangle.X) + 10, (col * 10 + rectangle.Y) + 10, 10, 10), Color.White);
                                    break;
                                case 'i':
                                    spriteBatch.Draw(Piece.texture_I, new Rectangle((row * 10 + rectangle.X) + 10, (col * 10 + rectangle.Y) + 10, 10, 10), Color.White);
                                    break;
                                case 'l':
                                    spriteBatch.Draw(Piece.texture_L, new Rectangle((row * 10 + rectangle.X) + 10, (col * 10 + rectangle.Y) + 10, 10, 10), Color.White);
                                    break;
                                case 'j':
                                    spriteBatch.Draw(Piece.texture_J, new Rectangle((row * 10 + rectangle.X) + 10, (col * 10 + rectangle.Y) + 10, 10, 10), Color.White);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }


    }
}
