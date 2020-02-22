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

        public const int canvasWidth = 500;
        public const int canvasHeight = 500;

        Texture2D texture2D;

        public MyGame()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            // Window size
            graphicsDeviceManager.PreferredBackBufferWidth = canvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = canvasHeight;
        }


        protected override void Initialize()
        {
            // code
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture2D = Tools.CreateColorTexture(Color.Red);
        }


        protected override void Update(GameTime gameTime)
        {
            // code
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            // code
            spriteBatch.Draw(texture2D, new Rectangle(50, 50, 100, 100), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}