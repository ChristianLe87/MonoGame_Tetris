using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Escena_1
    {
        GameGrid gameGrid;
        NextPiecePreview nextPiecePreview;
        //Score score;
        //LevelNumber levelNumber;
        Lines lines;
        GameOver gameOver;

        public static int lineCount;
        public static int scoreCount;
        public static int levelCount;
        public static bool isGameOver;

        public Escena_1()
        {
            gameGrid = new GameGrid(new Vector2(10, 10));
            nextPiecePreview = new NextPiecePreview(new Rectangle(120, 10, 50, 50));
            //score = new Score(new Rectangle(120, 70, 50, 50));
            //levelNumber = new LevelNumber(new Vector2(120,130));
            lines = new Lines(new Rectangle(120, 160, 50, 50));
            gameOver = new GameOver(new Rectangle(50, 80, 80, 30));
        }

        public void Update()
        {
            if(isGameOver == false)
            {
                gameGrid.Update();
                nextPiecePreview.Update(gameGrid.piece.nextPieceDesign);
                //score.Update(1);
                //levelNumber.Update();
                lines.Update(lineCount);
            }

            gameOver.Update(isGameOver);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            gameGrid.Draw(spriteBatch);
            nextPiecePreview.Draw(spriteBatch);
            //score.Draw(spriteBatch);
            //levelNumber.Draw(spriteBatch);
            lines.Draw(spriteBatch);
            gameOver.Draw(spriteBatch);
        }
    }
}
