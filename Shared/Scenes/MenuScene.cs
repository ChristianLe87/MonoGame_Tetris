using System;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MenuScene : IScene
    {
        Label topScore;

        public MenuScene()
        {
            Reset();
        }

        public void Reset()
        {
            Texture2D texture2D = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.MyFont_PNG_130x28);
            SpriteFont spriteFont = Tools.Font.GenerateFont(texture2D: texture2D, chars: WK.Font.Chars);

            topScore = new Label(
                rectangle: new Rectangle(20, 20, 50, 20),
                spriteFont: spriteFont,
                text: "hello",
                textAlignment: Label.TextAlignment.Midle_Center,
                fontColor: Color.Black
            );
        }

        public void Update()
        {
            //topScore.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            topScore.Draw(spriteBatch);
        }
    }
}
