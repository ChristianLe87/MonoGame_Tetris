using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Score
    {
        Rectangle rectangle;
        Texture2D backgrownd;
        int score;
        Label textScore;
        Label textTitle;

        public Score(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.backgrownd = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.YellowGreen);


            Texture2D texture2D = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.MyFont_PNG_130x28);
            SpriteFont spriteFont = Tools.Font.GenerateFont(texture2D: texture2D, chars: WK.Font.Chars);

            this.textScore = new Label(
                rectangle: new Rectangle(rectangle.X, rectangle.Y + 20, rectangle.Width, 10),
                spriteFont: spriteFont,
                text: "abc",
                textAlignment: Label.TextAlignment.Midle_Center,
                fontColor: Color.Black
            );


            
            this.textTitle = new Label(
                rectangle: new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 10),
                spriteFont: spriteFont,
                text: "Score",
                textAlignment: Label.TextAlignment.Midle_Center,
                fontColor: Color.Black
            );

        }

        public void Update(int score)
        {
            this.score = score;
            this.textScore.Update(this.score.ToString());
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, rectangle, Color.White);
            textScore.Draw(spriteBatch);
            textTitle.Draw(spriteBatch);
        }
    }
}
