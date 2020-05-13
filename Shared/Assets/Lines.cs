using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Lines
    {
        Rectangle rectangle;
        Texture2D backgrownd;
        int lineCount;
        Text title;
        Text lineCountText;

        public Lines(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.backgrownd = Tools.CreateColorTexture(Color.Green);
            this.title = new Text(new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 15), WK.Font.Arial_10, "Lines", HorizontalAlignment.Center, VerticalAlignment.Center);
            this.lineCountText = new Text(new Rectangle(rectangle.X, rectangle.Y + 15, rectangle.Width, rectangle.Height - 15), WK.Font.Arial_10, "0", HorizontalAlignment.Center, VerticalAlignment.Center);
        }

        public void Update(int lines)
        {
            this.lineCount = lines;
            this.lineCountText.Update(this.lineCount.ToString());
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, rectangle, Color.White);
            lineCountText.Draw(spriteBatch, Color.Red);
            title.Draw(spriteBatch, Color.Black);
        }
    }
}
