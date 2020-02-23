using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Escena_1 : IScene
    {
        GameGrid gameGrid;
        NextPiece nextPiece;
        Score score;
        Lines lines;
        LevelNumber levelNumber;

        public Escena_1()
        {
            gameGrid = new GameGrid(new Rectangle(
                                                (int)(WK.Desktop.Width / 100f * 6.25f), //10% = 10
                                                (int)(WK.Desktop.Height / 100f * 4.54545454545f),//10% = 10
                                                100,
                                                200
                                                ), 10, 20);
            nextPiece = new NextPiece(new Rectangle(120, 80, 30, 30));
            score = new Score(new Rectangle(120, 120, 30, 20));
            lines = new Lines(new Rectangle(120, 150, 30, 20));
            levelNumber = new LevelNumber(new Rectangle(120, 180, 30, 20));
        }

        public void Update()
        {
            gameGrid.Update();
            nextPiece.Update();
            score.Update();
            lines.Update();
            levelNumber.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            gameGrid.Draw(spriteBatch);
            nextPiece.Draw(spriteBatch);
            score.Draw(spriteBatch);
            lines.Draw(spriteBatch);
            levelNumber.Draw(spriteBatch);
        }

    }
}
