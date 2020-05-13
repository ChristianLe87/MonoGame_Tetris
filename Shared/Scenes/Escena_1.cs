using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Escena_1
    {
        GameGrid gameGrid;
        //NextPiecePreview nextPiecePreview;
        //Score score;
        //LevelNumber levelNumber;
        Lines lines;

        public static int lineCount;
        public static int scoreCount;
        public static int levelCount;

        public Escena_1()
        {
            gameGrid = new GameGrid(new Vector2(10, 10));
            //nextPiecePreview = new NextPiecePreview(new Rectangle(120, 10, 50, 50));
            //score = new Score(new Rectangle(120, 70, 50, 50));
            //levelNumber = new LevelNumber(new Vector2(120,130));
            lines = new Lines(new Rectangle(120, 160, 50, 50));
        }

        public void Update()
        {
            //nextPiecePreview.piece = gameGrid.piece.nextPieceDesign;
            gameGrid.Update();
            //score.Update(1);
            //levelNumber.Update();
            lines.Update(lineCount);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //nextPiecePreview.Draw(spriteBatch);
            gameGrid.Draw(spriteBatch);
            //score.Draw(spriteBatch);
            //levelNumber.Draw(spriteBatch);
            lines.Draw(spriteBatch);
        }
    }
}
