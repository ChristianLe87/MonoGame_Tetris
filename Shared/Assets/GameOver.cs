using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameOver
    {
        Rectangle rectangle;
        Texture2D backgrownd;
        Text label;
        bool isGameOver;

        public GameOver(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.backgrownd = Tools.CreateColorTexture(Color.Yellow);
            this.label = new Text(new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 15), WK.Font.Arial_10, "Game Over", HorizontalAlignment.Center, VerticalAlignment.Center);
        }

        public void Update(bool isGameOver)
        {
            this.isGameOver = isGameOver;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (isGameOver)
            {
                spriteBatch.Draw(backgrownd, rectangle, Color.White);
                label.Draw(spriteBatch, Color.Black);
            }
        }
    }
}
