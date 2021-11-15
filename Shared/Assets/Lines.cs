using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Lines
    {
        Rectangle rectangle;
        Texture2D backgrownd;
        int lineCount;
        Label title;
        Label lineCountText;

        public Lines(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.backgrownd = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green);


            Texture2D texture2D = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.MyFont_PNG_130x28);
            SpriteFont spriteFont = Tools.Font.GenerateFont(texture2D: texture2D, chars: WK.Font.Chars);

            this.title = new Label(
                rectangle: new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 15),
                spriteFont: spriteFont,
                text: "Lines",
                textAlignment: Label.TextAlignment.Midle_Center,
                fontColor: Color.Black
            );


            this.lineCountText = new Label(
                rectangle: new Rectangle(rectangle.X, rectangle.Y + 15, rectangle.Width, rectangle.Height - 15),
                spriteFont: spriteFont,
                text: "0",
                textAlignment: Label.TextAlignment.Midle_Center,
                fontColor: Color.Black
            );

        }

        public void Update(int lines)
        {
            this.lineCount = lines;
            this.lineCountText.Update(this.lineCount.ToString());
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, rectangle, Color.White);
            lineCountText.Draw(spriteBatch);
            title.Draw(spriteBatch);
        }
    }
}
