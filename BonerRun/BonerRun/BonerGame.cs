using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using BonerRun.Core;
namespace BonerRun
{

    public class BonerGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        protected GameManager gameManager;

        public BonerGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 1024;
            graphics.IsFullScreen = true;

            graphics.ApplyChanges();

            base.Initialize();
        }


        protected override void LoadContent()
        {
            gameManager = new GameManager(this);
            gameManager.Initialize();
        }


        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            gameManager.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            gameManager.Draw();

            base.Draw(gameTime);
        }



    }
}