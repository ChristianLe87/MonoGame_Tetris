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

            this.grid = new char[unitsWidth, unitsHeight];

            backgrownd = Tools.CreateColorTexture(Color.LightBlue);

            this.rectangle = rectangle;
            //InitialiseGrid();
        }

     

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrownd, rectangle, Color.White);
        }

        public void InitialiseGrid()
        {
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid.Length; col++)
                {
                    grid[row, col] = ' ';
                }
            }
        }
    }
}
