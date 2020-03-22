using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Lines
    {
        Vector2 position;
        Texture2D backgrownd;
        int lineCount;
        Text text;
        Text title;

        public Lines(Vector2 position)
        {
            this.position = position;
            this.backgrownd = Tools.CreateColorTexture(Color.Green);
            this.text = new Text(MyGame.contentManager, new Vector2(position.X, position.Y + 10), "MyFont", "bla");
            this.title = new Text(MyGame.contentManager, position, "MyFont", "Lines:");
        }

        public void Update(int lines)
        {
            this.lineCount = lines;
            this.text.Update(this.lineCount.ToString());
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, new Rectangle((int)position.X, (int)position.Y, 50, 40), Color.White);
            text.Draw(spriteBatch, Color.Red);
            title.Draw(spriteBatch, Color.Black);
        }
    }
}
