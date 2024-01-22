using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MenuScene : IScene
    {
        //Label topScore;
        Button playButton;

        public MenuScene()
        {
            Initialize();
        }

        public void Initialize()
        {
            Texture2D fontTexture = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.MyFont_PNG_130x28);
            SpriteFont spriteFont = Tools.Font.GenerateFont(texture2D: fontTexture, chars: WK.Font.Chars);

            /*topScore = new Label(
                rectangle: new Rectangle(20, 20, 50, 20),
                spriteFont: spriteFont,
                text: "hello",
                textAlignment: Label.TextAlignment.Midle_Center,
                fontColor: Color.Black
            );*/

            this.playButton = new Button(
                rectangle: new Rectangle(20, 20, 50, 20),
                text: "Play",
                defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                spriteFont: spriteFont,
                fontColor: Color.Black,
                ButtonID: ""
            );


        }

        public void Update()
        {
            playButton.Update(OnClickAction: () => Game1.ChangeToScene(WK.Scene.GameScene)
);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //topScore.Draw(spriteBatch);
            playButton.Draw(spriteBatch);
        }


    }
}
