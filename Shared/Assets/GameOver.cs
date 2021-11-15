using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameOver
    {
        Rectangle rectangle;
        Texture2D backgrownd;
        Label label;
        bool isGameOver;

        public GameOver(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.backgrownd = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Yellow);


            Texture2D texture2D = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.MyFont_PNG_130x28);
            SpriteFont spriteFont = Tools.Font.GenerateFont(texture2D: texture2D, chars: WK.Font.Chars);

            this.label = new Label(
                rectangle: new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 15),
                spriteFont: spriteFont,
                text: "Game Over",
                textAlignment: Label.TextAlignment.Midle_Center,
                fontColor: Color.Black
            );
        }

        public void Update(bool isGameOver)
        {
            this.isGameOver = isGameOver;

            if (isGameOver == true)
                label.Update("Game Over\n'Q' to menu");
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (isGameOver)
            {
                spriteBatch.Draw(backgrownd, rectangle, Color.White);
                label.Draw(spriteBatch);
            }
        }
    }
}
