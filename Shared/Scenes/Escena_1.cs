using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Escena_1
    {
        GameGrid gameGrid;
        NextPiecePreview nextPiecePreview;
        Score score;
        LevelNumber levelNumber;
        Lines lines;

        public static int lineCount;
        public static int scoreCount;
        public static int levelCount;

        public Escena_1()
        {
            gameGrid = new GameGrid(new Vector2(10, 10));
            nextPiecePreview = new NextPiecePreview(new Vector2(120, 10));
            score = new Score(new Vector2(120, 70));
            levelNumber = new LevelNumber(new Vector2(120,130));
            lines = new Lines(new Vector2(120, 160));
        }

        public void Update()
        {
            nextPiecePreview.piece = gameGrid.piece.nextPieceDesign;
            gameGrid.Update();
            //score.Update(1);
            //levelNumber.Update();
            lines.Update(lineCount);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            nextPiecePreview.Draw(spriteBatch);
            gameGrid.Draw(spriteBatch);
            score.Draw(spriteBatch);
            levelNumber.Draw(spriteBatch);
            lines.Draw(spriteBatch);
        }
    }
}
