using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Game1 : Game
    {
        SpriteBatch spriteBatch;


        // Statics
        public static GraphicsDeviceManager graphicsDeviceManager;
        public static ContentManager contentManager;

        private static Dictionary<string, IScene> scenes;

        private static string actualScene;

        public Game1()
        {
            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = WK.Desktop.Width;
            graphicsDeviceManager.PreferredBackBufferHeight = WK.Desktop.Height;
            graphicsDeviceManager.ApplyChanges();

            // FPS
            base.IsFixedTimeStep = true;
            base.TargetElapsedTime = TimeSpan.FromSeconds(1d / WK.Default.FPS);

            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            base.Content.RootDirectory = absolutePath;
            Game1.contentManager = base.Content;

            // Scenes
            scenes = new Dictionary<string, IScene>()
            {
                { WK.Scene.MenuScene, new MenuScene() },
                { WK.Scene.GameScene, new Escena_1() }
            };
            actualScene = WK.Scene.MenuScene;

            // others
            base.Window.Title = "Hello Window";
            base.IsMouseVisible = true;


            // Initialize objects (scores, values, items, etc)
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        protected override void Update(GameTime gameTime)
        {
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

        public static void ChangeToScene(string scene)
        {
            //scenes[actualScene] = null;

            actualScene = scene;
            scenes[actualScene].Initialize();
        }
    }
}
