using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoshiRendering.Core;
using BonerRun.Core;
namespace BonerRun.GameStates.PressStart
{
    public class GameStatePressStart:GameState
    {

        private RenderImage background;
        private RenderImage pressStart;


        public GameStatePressStart(GameManager mrg)
            : base(mrg)
        {
        }


        public override void Initialize()
        {
            RenderGroup group = new RenderGroup("PressStart");
            parentManager.renderCore.renderGroups.Add(group);

            background = new RenderImage(parentManager.renderCore, parentManager.game.Content.Load<Texture2D>("Graphic/PressStartScreen/BG"), group, 0,false, Vector2.Zero);
            pressStart = new RenderImage(parentManager.renderCore, parentManager.game.Content.Load<Texture2D>("Graphic/PressStartScreen/Message"), group, 1, false, new Vector2(500, 500));

            parentManager.renderCore.objects.Add(background);
            parentManager.renderCore.objects.Add(pressStart);

            parentManager.inputManager.registerHandler("PressStartHandler", new PressStartHandler(parentManager), true);
        }


        public override void Update()
        {

        }


        public override void Draw()
        {
            parentManager.renderCore.render();
        }

        public override void Destroy()
        {
            parentManager.renderCore.objects.Remove(background);
            parentManager.renderCore.objects.Remove(pressStart);

            parentManager.renderCore.renderGroups.Remove(parentManager.renderCore.getRenderGroup("PressStart"));           
        }
    }
}
