using System;
using Shared;

namespace Windows
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string relativePath = $"../../../../MonoGame_Tetris/Shared/Assets/";

            using (var game = new MyGame(relativePath))
            {
                game.Run();
            }
        }
    }
}
