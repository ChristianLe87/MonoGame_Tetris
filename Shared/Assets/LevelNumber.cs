using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class LevelNumber
    {
        Vector2 position;
        Texture2D backgrownd;
        Text text;
        int levelCount;

        public LevelNumber(Vector2 position)
        {
            this.position = position;
            this.backgrownd = Tools.CreateColorTexture(Color.Pink);
            this.text = new Text(new Rectangle((int)position.X, (int)position.Y,50,29), WK.Font.Arial_10, "hello", HorizontalAlignment.Center, VerticalAlignment.Center);
        }

        public void Update(bool bla)
        {
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, new Rectangle((int)position.X,(int)position.Y, 50, 20), Color.White);
            text.Draw(spriteBatch, Color.Black);
        }
    }
}
