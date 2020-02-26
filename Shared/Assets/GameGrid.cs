using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameGrid
    {
        char[,] grid;

        Texture2D backgrownd;
        Rectangle rectangle;

        public GameGrid(Rectangle rectangle, int unitsWidth, int unitsHeight)
        {


            backgrownd = Tools.CreateColorTexture(Color.LightBlue);

            this.rectangle = rectangle;
            InitialiseGrid(unitsHeight, unitsWidth);
        }



        public void Update()
        {

        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, rectangle, Color.White);
        }

        public void InitialiseGrid(int unitsHeight, int unitsWidth)
        {
            this.grid = new char[unitsWidth, unitsHeight];

            for (int row = 0; row < unitsHeight; row++)
            {
                for (int col = 0; col < unitsWidth; col++)
                {
                    grid[col, row] = ' ';
                }
            }
        }
    }
}
