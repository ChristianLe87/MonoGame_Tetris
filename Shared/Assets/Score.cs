using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Score
    {
        Rectangle rectangle;
        Texture2D backgrownd;
        int score;
        Text text;

        public Score(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.backgrownd = Tools.CreateColorTexture(Color.YellowGreen);
            this.text = new Text(new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 10), WK.Font.Arial_10, "Score", HorizontalAlignment.Center, VerticalAlignment.Center);
        }

        public void Update(int score)
        {
            this.score = score;
            this.text.Update(this.score.ToString());
        }

   
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, rectangle, Color.White);
            text.Draw(spriteBatch, Color.Green);
        }
    }
}
