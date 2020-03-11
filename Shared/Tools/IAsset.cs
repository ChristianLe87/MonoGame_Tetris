using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IAsset
    {
        public void Update(char[,] grid);
        public void Draw(SpriteBatch spriteBatch, Vector2 position = (new Vector2()));
    }
}
