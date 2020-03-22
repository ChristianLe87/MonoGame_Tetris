using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Escena_1
    {
        GameGrid gameGrid;
        NextPiece nextPiece;
        Score score;
        LevelNumber levelNumber;
        Lines lines;

        public Escena_1()
        {
            gameGrid = new GameGrid(new Vector2(10, 10));
            nextPiece = new NextPiece(new Vector2(120, 10));
            score = new Score(new Vector2(120, 70));
            levelNumber = new LevelNumber(new Vector2(120,130));
            lines = new Lines(new Vector2(120, 160));
        }

        public void Update()
        {
            nextPiece.piece = gameGrid.piece.nextPieceDesign;
            gameGrid.Update();
            //score.Update(1);
            levelNumber.Update(1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            nextPiece.Draw(spriteBatch);
            gameGrid.Draw(spriteBatch);
            score.Draw(spriteBatch);
            levelNumber.Draw(spriteBatch);
            lines.Draw(spriteBatch);
        }
    }
}
