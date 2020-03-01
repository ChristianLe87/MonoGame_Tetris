using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MyGame : Game
    {
        SpriteBatch spriteBatch;


        // Statics
        public static GraphicsDeviceManager graphicsDeviceManager;
        public static ContentManager contentManager;

        Dictionary<string, IScene> scenes;

        public MyGame()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            // Window size
            graphicsDeviceManager.PreferredBackBufferWidth = 100;
            graphicsDeviceManager.PreferredBackBufferHeight = 200;
        }


        protected override void Initialize()
        {
            // code
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            scenes = new Dictionary<string, IScene>()
            {
                { "Escena_1", new Escena_1() }
            };
        }


        protected override void Update(GameTime gameTime)
        {
            // code
            scenes["Escena_1"].Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            // code
            scenes["Escena_1"].Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}