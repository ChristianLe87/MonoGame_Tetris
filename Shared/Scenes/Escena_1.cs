using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Escena_1 : IScene
    {
        GameGrid gameGrid;
        Piece_S piece_S;

        public Escena_1()
        {
            piece_S = new Piece_S(new Vector2(1, 0));
            gameGrid = new GameGrid();

        }

        public void Update()
        {
            piece_S.Update(gameGrid.grid);
            gameGrid.Update(piece_S);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            gameGrid.Draw(spriteBatch);
            piece_S.Draw(spriteBatch);
        }
    }
}
