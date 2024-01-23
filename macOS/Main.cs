using AppKit;

namespace macOS
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            //NSApplication.Init();
            //NSApplication.Main(args);
            using (var game = new Shared.Game1())
            {
                game.Run();
            }
        }
    }
}
