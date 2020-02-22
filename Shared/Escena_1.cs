using System;
namespace Shared
{
    public class Escena_1 :Scene
    {


        public Escena_1()
        {
        }


        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            int screenWidth = 500;
            int screenHeigh = 500;

            GameGrid gameGrid = new GameGrid(screenWidth, screenHeigh);
        }

    }
}
