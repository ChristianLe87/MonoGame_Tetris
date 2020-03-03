using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class NextPiece:IAsset
    {
        Rectangle rectangle;
        Texture2D backgrownd;

        public NextPiece(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.backgrownd = Tools.CreateColorTexture(Color.Green);
        }

        public void Update(char[,] grid)
        {
            //throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, rectangle, Color.White);
        }
    }
}
