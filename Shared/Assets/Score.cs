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
        Text textScore;
        Text textTitle;

        public Score(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.backgrownd = Tools.CreateColorTexture(Color.YellowGreen);
            this.textScore = new Text(new Rectangle(rectangle.X, rectangle.Y + 20, rectangle.Width, 10), WK.Font.Arial_10, "abc", HorizontalAlignment.Center, VerticalAlignment.Center);
            this.textTitle = new Text(new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 10), WK.Font.Arial_10, "Score", HorizontalAlignment.Center, VerticalAlignment.Center);
        }

        public void Update(int score)
        {
            this.score = score;
            this.textScore.Update(this.score.ToString());
        }

   
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, rectangle, Color.White);
            textScore.Draw(spriteBatch, Color.Green);
            textTitle.Draw(spriteBatch, Color.Green);
        }
    }
}
