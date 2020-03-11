using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Score
    {
        Vector2 position;
        Texture2D backgrownd;

        public Score(Vector2 position)
        {
            this.position = position;
            this.backgrownd = Tools.CreateColorTexture(Color.YellowGreen);
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

   
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, new Rectangle((int)position.X, (int)position.Y,50,50), Color.White);
        }
    }
}
