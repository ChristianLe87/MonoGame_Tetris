using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Lines
    {
        Vector2 position;
        Texture2D backgrownd;
        public int lines;
        Text text;

        public Lines(Vector2 position)
        {
            this.position = position;
            this.backgrownd = Tools.CreateColorTexture(Color.Green);
            this.text = new Text(MyGame.contentManager, position, "MyFont", "bla");
        }

        public void Update(char[,] grid)
        {
            //throw new NotImplementedException();
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, new Rectangle((int)position.X, (int)position.Y, 50, 40), Color.White);
            text.Draw(spriteBatch, Color.Red);
        }
    }
}
