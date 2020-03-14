using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Escena_1
    {
        GameGrid gameGrid;
        NextPiece nextPiece;
        Score score;
        public Escena_1()
        {
            gameGrid = new GameGrid(new Vector2(10, 10));
            nextPiece = new NextPiece(new Vector2(120, 10));
            score = new Score(new Vector2(120, 70));
        }

        public void Update()
        {
            nextPiece.piece = gameGrid.piece.pieceDesign;
            gameGrid.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            nextPiece.Draw(spriteBatch);
            gameGrid.Draw(spriteBatch);
            score.Draw(spriteBatch);
        }
    }
}
