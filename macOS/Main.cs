using AppKit;
using Shared;

namespace macOS
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();

            string relativePath = $"../../../../../../../MonoGame_Tetris/Shared/Assets/";

            using (var game = new MyGame(relativePath))
            {
                game.Run();
            }
        }
    }
}
