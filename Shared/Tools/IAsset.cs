using System;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IAsset
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
