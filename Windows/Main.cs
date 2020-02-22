using System;
using Shared;

namespace Windows
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            using (var game = new MyGame())
            {
                game.Run();
            }
        }
    }
}
