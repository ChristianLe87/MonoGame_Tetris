using System;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class LevelNumber
    {
        Vector2 position;
        Texture2D backgrownd;
        Label text;
        int levelCount;

        public LevelNumber(Vector2 position)
        {
            this.position = position;
            this.backgrownd = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink);

            Texture2D texture2D = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.MyFont_PNG_130x28);
            SpriteFont spriteFont = Tools.Font.GenerateFont(texture2D: texture2D, chars: WK.Font.Chars);

            this.text = new Label(
                rectangle: new Rectangle((int)position.X, (int)position.Y, 50, 29),
                spriteFont: spriteFont,
                text: "hello",
                textAlignment: Label.TextAlignment.Midle_Center,
                fontColor: Color.Black
            );
        }

        public void Update(bool bla)
        {
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, new Rectangle((int)position.X, (int)position.Y, 50, 20), Color.White);
            text.Draw(spriteBatch);
        }
    }
}
