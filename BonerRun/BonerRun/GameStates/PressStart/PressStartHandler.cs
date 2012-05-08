using Microsoft.Xna.Framework.Input;
using BonerRun.Input;
using BonerRun.Core;
namespace BonerRun.GameStates.PressStart
{
    public class PressStartHandler : InputHandler
    {

        private InputManager parent;
        private GameManager mrg;

        public PressStartHandler(GameManager mrg)
        {
            this.parent = mrg.inputManager;
            this.mrg = mrg;
            name = "PressStartHandler";
        }

        public override void handlePad()
        {
            if (parent.padoldstate.Buttons.Start == ButtonState.Released && parent.padstate.Buttons.Start == ButtonState.Pressed)
            {
                this.parent.handels.Remove(name);
                mrg.renderCore.getRenderGroup("PressStart").hide();
                //TODO goto the MainMenue
            }
        }


        public override void handleKeyboard()
        {
            if (parent.oldstate.IsKeyUp(Keys.Enter) && parent.state.IsKeyDown(Keys.Enter))
            {
                parent.handels.Remove(name);
                //TODO goto the MainMenue
            }
        }
    }
}
