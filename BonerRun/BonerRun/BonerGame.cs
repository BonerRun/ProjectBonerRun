//________________#_________________________________
//________##______#################____####_________
//_________##___########_______##########___________
//__________######__________________#####_____##____
//__________###________________________####_####____
//________###____________________________####_______
//_______###_______________________________###______
//______##___________________________________##_____
//_____##_____#############____#############__##____
//____##______#############____##############_###___
//____##_______________________________________##___
//___##_________________________________________##__
//___##_____________________###_________________##__
//___##_____________________###_________________##__
//___##_____________________###_________________##__
//___##_____________________###_________________##__
//___##_____________________###_________________##__
//___##________________________________________##___
//____##_____________##############____________##___
//____###______#########################______##____
//_____###_____###___________________####____###____
//______###____##########################___###_____
//_______###________################_______###______
//_________###___________________________###________
//__________####______________________#####_________
//____________######_______________######___________
//_______________#####################______________
//____________________###########___________________
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BonerRun.Core;
namespace BonerRun
{
    public class BonerGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        GameManager gameManager;

        public BonerGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = false;

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
