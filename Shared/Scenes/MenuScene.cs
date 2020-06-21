using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MenuScene: IScene
    {
        Text topScore;

        public MenuScene()
        {
            Reset();
        }

        public void Reset()
        {
            topScore = new Text(new Rectangle(20, 20, 50, 20), WK.Font.Arial_10, "hello", HorizontalAlignment.Center, VerticalAlignment.Center);
        }

        public void Update()
        {
            //topScore.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            topScore.Draw(spriteBatch, Color.Orange);
        }
    }
}
