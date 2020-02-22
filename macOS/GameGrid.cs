namespace Shared
{
    internal class GameGrid
    {
        char[,] grid = new char[10, 20];

        public GameGrid(int bla1, int bla2)
        {
            InitialiseGrid();
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