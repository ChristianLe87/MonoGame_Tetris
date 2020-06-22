using System;
using System.Collections.Generic;
using System.IO;
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

        string actualScene;

        public MyGame(string relativePath)
        {
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();
            this.Content.RootDirectory = absolutePath;
            contentManager = this.Content;

            graphicsDeviceManager = new GraphicsDeviceManager(this);

            // Window size
            graphicsDeviceManager.PreferredBackBufferWidth = 180;
            graphicsDeviceManager.PreferredBackBufferHeight = 220;
        }


        protected override void Initialize()
        {
            // code
            base.Initialize();
        }


        protected override void LoadContent()
        {
            actualScene = WK.Scene.GameScene;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            scenes = new Dictionary<string, IScene>()
            {
                { WK.Scene.MenuScene, new MenuScene() },
                { WK.Scene.GameScene, new Escena_1() }
            };
        }


        protected override void Update(GameTime gameTime)
        {
            // code
            scenes[actualScene].Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            // code
            scenes[actualScene].Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
