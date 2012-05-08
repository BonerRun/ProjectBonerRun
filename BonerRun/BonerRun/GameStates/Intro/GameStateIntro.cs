using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using BonerRun.Core;
using BonerRun.GameStates.PressStart;
namespace BonerRun.GameStates.Intro
{
    public class GameStateIntro:GameState
    {

        private Video video;
        private VideoPlayer player;
        private Texture2D videoTexture;

        private bool first = true;

        public GameStateIntro(GameManager mrg)
            : base(mrg)
        {

        }


        public override void Initialize()
        {
            video = parentManager.game.Content.Load<Video>("Videos/Intro");
            player = new VideoPlayer();
        }



        public override void Update()
        {
            if (player.State == MediaState.Stopped && first)
            {
                first = false;
                player.Play(video);
            }
        }

        public override void Draw()
        {
            if (player.State != MediaState.Stopped)
            {
                videoTexture = player.GetTexture();
            }
            else
            {
                parentManager.setGameState(new GameStatePressStart(parentManager), true, true);
            }
            // Drawing to the rectangle will stretch the 
            // video to fill the screen
            Rectangle screen = new Rectangle(0,
                0,
                (int)parentManager.renderCore.settings.screensize.X,
                (int)parentManager.renderCore.settings.screensize.X);

            // Draw the video, if we have a texture to draw.
            if (videoTexture != null)
            {
                parentManager.renderCore.spritebatch.Begin();
                parentManager.renderCore.spritebatch.Draw(videoTexture, screen, Color.White);
                parentManager.renderCore.spritebatch.End();
            }
        }

        public override void Destroy()
        {
            
        }

    }
}
