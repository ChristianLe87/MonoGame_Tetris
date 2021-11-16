using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Escena_1 : IScene
    {
        GameGrid gameGrid;
        NextPiecePreview nextPiecePreview;
        Score score;
        //LevelNumber levelNumber;
        Lines lines;
        GameOver gameOver;

        public static int lineCount;
        public static int scoreCount;
        public static int levelCount;
        public static bool isGameOver;

        KeyboardState previousKeyboardState;

        public Escena_1()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.gameGrid = new GameGrid(new Vector2(10, 10));
            this.nextPiecePreview = new NextPiecePreview(new Rectangle(120, 10, 50, 50));
            this.score = new Score(new Rectangle(120, 70, 50, 50));
            //this.levelNumber = new LevelNumber(new Vector2(120,130));
            this.lines = new Lines(new Rectangle(120, 160, 50, 50));
            this.gameOver = new GameOver(new Rectangle(50, 80, 80, 30));

            lineCount = 0;
            scoreCount = 0;
            levelCount = 0;
            isGameOver = false;

            this.previousKeyboardState = Keyboard.GetState();
        }

        public void Update()
        {
            if (isGameOver == false)
            {
                gameGrid.Update();
                nextPiecePreview.Update(gameGrid.piece.nextPieceDesign);
                score.Update(scoreCount);
                Game1.gameData.score = scoreCount;
                //levelNumber.Update();
                lines.Update(lineCount);
            }

            gameOver.Update(isGameOver);


            KeyboardState keyboardState = Keyboard.GetState();

            if (isGameOver == true)
                if (keyboardState.IsKeyDown(Keys.Q) && previousKeyboardState.IsKeyUp(Keys.Q))
                {
                    JsonSerialization.Update(Game1.gameData, WK.Default.GameDataFileName);
                    Game1.ChangeToScene(WK.Scene.MenuScene);
                }
                    

            previousKeyboardState = keyboardState;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            gameGrid.Draw(spriteBatch);
            nextPiecePreview.Draw(spriteBatch);
            score.Draw(spriteBatch);
            //levelNumber.Draw(spriteBatch);
            lines.Draw(spriteBatch);
            gameOver.Draw(spriteBatch);
        }
    }
}
