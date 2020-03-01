using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class LevelNumber : IAsset
    {
        Rectangle rectangle;
        Texture2D backgrownd;

        public LevelNumber(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.backgrownd = Tools.CreateColorTexture(Color.Pink);
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, rectangle, Color.White);
        }

    }
}
