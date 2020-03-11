using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Escena_1 : IScene
    {
        GameGrid gameGrid;

        public Escena_1()
        {
            gameGrid = new GameGrid(new Vector2(10, 10));

        }

        public void Update()
        {
            gameGrid.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            gameGrid.Draw(spriteBatch);
        }
    }
}
