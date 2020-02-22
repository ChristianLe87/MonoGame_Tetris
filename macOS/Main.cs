using AppKit;
using Shared;

namespace macOS
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();

            using (var game = new MyGame())
            {
                game.Run();
            }
        }
    }
}
