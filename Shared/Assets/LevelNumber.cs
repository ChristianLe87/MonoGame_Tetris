using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class LevelNumber
    {
        Rectangle rectangle;
        Texture2D backgrownd;

        public LevelNumber(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.backgrownd = Tools.CreateColorTexture(Color.Pink);
        }

        public void Update(char[,] grid)
        {
            //throw new NotImplementedException();
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 position = default)
        {
            spriteBatch.Draw(backgrownd, rectangle, Color.White);
        }
    }
}
