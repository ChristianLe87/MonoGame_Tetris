using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Score
    {
        Vector2 position;
        Texture2D backgrownd;
        int score;
        Text text;

        public Score(Vector2 position)
        {
            this.position = position;
            this.backgrownd = Tools.CreateColorTexture(Color.YellowGreen);
            this.text = new Text(MyGame.contentManager, position, "MyFont", "world");
        }

        public void Update(int score)
        {
            this.score = score;
            this.text.Update(this.score.ToString());
        }

   
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, new Rectangle((int)position.X, (int)position.Y,50,50), Color.White);
            text.Draw(spriteBatch, Color.Green);
        }
    }
}
